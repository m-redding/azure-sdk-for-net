# NUnit 4 Migration Guide

This guide provides precise, self-contained instructions for migrating the azure-sdk-for-net repository from NUnit 3.14.0 to NUnit 4.4.0. Each PR task is designed to be delegated to a subagent, a Copilot coding agent, or executed by a human — with no interactive decisions required.

## Background

NUnit 4.0 has two breaking changes vs NUnit 3.14.0:

1. **Classic Assert methods removed from `Assert`** — methods like `Assert.AreEqual`, `Assert.IsTrue`, `Assert.IsNull` etc. have been moved to `ClassicAssert` in `NUnit.Framework.Legacy`. The preferred path is to convert them to the constraint model (`Assert.That(...)`).
2. **`Assert.That` format specification and `params` overloads removed** — calls like `Assert.That(x, Is.EqualTo(y), "msg {0}", arg)` must become `Assert.That(x, Is.EqualTo(y), $"msg {arg}")`.

Both changes are handled automatically by NUnit.Analyzers code fixes (diagnostics NUnit2001–NUnit2050) via `dotnet format`.

Reference: https://docs.nunit.org/articles/nunit/release-notes/Nunit4.0-MigrationGuide.html

## Prerequisites

- .NET SDK (version matching `global.json`)
- PowerShell 7+ (for scripts; `pwsh` must be on PATH)
- Git repository on a clean working branch for the migration batch

## Scripts

All migration scripts live under `eng/scripts/nunitmigration/`:

| Script | Purpose |
|--------|---------|
| `setup.ps1` | One-time setup: adds `NUnit.Analyzers` to `eng/Packages.Data.props` and `eng/Directory.Build.Common.targets`, commits |
| `run-migration.ps1` | Core migration: finds test projects in given service dirs, temporarily adds `NUnit.Analyzers` to data plane projects, runs `dotnet format analyzers` with NUnit2xxx diagnostics, reverts `.csproj` changes |
| `post-migration.ps1` | Finalization: adds NUnit 4 conditional version overrides to `eng/Packages.Data.props` for migrated services, removes temporary `NUnit.Analyzers` from central files, verifies no `.csproj` drift |
| `test-run-builds.ps1` | Validation: builds all `.sln` files in given service dirs, parses and reports errors organized by project |

## Migration Process (Per PR)

Each PR migrates a batch of related service directories. The steps below are fully self-contained — a delegated agent should execute them in order.

### Step 1: Create a Branch and Run Setup

```powershell
git checkout -b nunit4-migration-<batch-name> main
.\eng\scripts\nunitmigration\setup.ps1
```

The setup script adds `NUnit.Analyzers` to the central package files so that both data plane and management plane test projects can use the analyzer during migration. This creates a commit automatically.

### Step 2: Run the Migration Script

Pass all service directories for this batch in a single invocation:

```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories <service1>, <service2>, ...
```

This script will:
1. Find all test projects (`*Tests.csproj`) in each `sdk/<service>/` directory
2. For data plane projects (those with an explicit `<PackageReference Include="NUnit" />`), temporarily add `NUnit.Analyzers` to the `.csproj`
3. Run `dotnet restore` then `dotnet format analyzers --diagnostics NUnit2001 NUnit2002 ... NUnit2050 --severity info --no-restore` on each test project
4. Revert all `.csproj` changes via `git checkout HEAD` to avoid whitespace-only diffs

Commit the code changes:
```powershell
git add sdk/
git commit -m "Migrate test assertions to NUnit 4 constraint model: <service-list>"
```

### Step 3: Run Post-Migration

```powershell
.\eng\scripts\nunitmigration\post-migration.ps1 -ServiceDirectories <service1>, <service2>, ...
```

This script will:
1. Add a conditional `ItemGroup` to `eng/Packages.Data.props` that overrides NUnit to 4.4.0, NUnit3TestAdapter to 4.6.0, and NUnit.Analyzers to 4.5.0 for the migrated service directories
2. Remove the temporary `NUnit.Analyzers` property and `PackageReference` from `eng/Packages.Data.props`
3. Remove the temporary `NUnit.Analyzers` from the management plane `ItemGroup` in `eng/Directory.Build.Common.targets`
4. Verify no `.csproj` files were accidentally modified; revert any that were
5. Commit the changes automatically

### Step 4: Build, Test, and Manual Fixup

Build all solutions for the migrated services:

```powershell
.\eng\scripts\nunitmigration\test-run-builds.ps1 -ServiceDirectories <service1>, <service2>, ...
```

This script builds each `.sln` file and reports errors organized by project. For any failures, apply manual fixes per the checklist below, then re-run until builds are clean.

To run tests manually:
```powershell
# For each test project in sdk/<service-name>/**/tests/*.csproj:
dotnet test <test-project.csproj>
```

#### Manual Fixup Checklist

The automated `dotnet format` pass handles ~95% of assertions. The following patterns require manual intervention:

1. **`FileAssert` and `DirectoryAssert`**: NUnit.Analyzers has no code fixer for these. Convert manually:
   ```csharp
   // Before (NUnit 3)
   FileAssert.Exists(path);
   DirectoryAssert.Exists(path);
   // After (NUnit 4)
   Assert.That(File.Exists(path), Is.True);
   Assert.That(Directory.Exists(path), Is.True);
   ```

2. **`StringAssert` edge cases**: Most are auto-fixed, but review any complex `StringAssert` calls with custom messages.

3. **`CollectionAssert` edge cases**: Most are auto-fixed. Watch for `CollectionAssert.AreEquivalent` with custom comparers — these may need manual `Assert.That(collection, Is.EquivalentTo(...).Using(...))`.

4. **`TestContext.CurrentContext.Result`**: The `Result` property was removed in NUnit 4. Search for usages:
   ```powershell
   Get-ChildItem -Recurse -Filter "*.cs" sdk/<service-name> | Select-String "TestContext.CurrentContext.Result"
   ```

5. **`Assert.That` with `params` format strings not caught by the fixer**: Search for remaining format-style messages:
   ```powershell
   Get-ChildItem -Recurse -Filter "*.cs" sdk/<service-name> | Select-String 'Assert\.That\(.*,\s*"[^"]*\{[0-9]'
   ```

6. **Custom assertion helpers / extension methods**: If the service has wrapper methods around classic asserts, those wrappers need manual updates. Check for any methods that call `Assert.AreEqual`, etc. internally.

7. **Assertion message format changes**: NUnit 4 may format failure messages differently. Tests that assert on exception messages or test output strings may need adjustment.

After fixing, commit:
```powershell
git add .
git commit -m "Fix build/test issues for <service-list>"
```

### Step 5: Submit PR

```powershell
git push origin nunit4-migration-<batch-name>
```

Create a PR targeting `main`. The PR description should list:
- Which services were migrated
- Whether all tests pass
- Any manual fixups that were applied

---

## Ordering Constraint

**PR 1.1 (Core Libraries) MUST be merged first.** The `Azure.Core.TestFramework` project in `sdk/core/` is referenced by nearly all test projects via `$(AzureCoreTestFramework)`. It must compile cleanly against NUnit 4 before downstream services are migrated. All other PRs are independent and can be submitted in parallel.

## Repository Upgrade Plan

The following plan breaks down the migration into manageable PRs. Each PR is independent (except PR 1.1 which must merge first) and can be delegated to a separate agent or contributor.

**For each PR below, follow the complete "Migration Process (Per PR)" workflow above:**
1. Create a branch and run `setup.ps1`
2. Run `run-migration.ps1` with the listed service directories
3. Commit the code changes, then run `post-migration.ps1` with the same service directories
4. Build with `test-run-builds.ps1`, apply manual fixups
5. Submit PR

The service directories for each batch are listed below.

### Phase 1: Core Infrastructure (3 PRs) ⚠️ PR 1.1 must merge before all others

**PR 1.1 - Core Libraries** (MUST BE FIRST — other PRs depend on this)
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories core, template
```

**PR 1.2 - Storage**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories storage, storagecache, storageactions, storagemover, storagepool, storagesync, storagediscovery
```

**PR 1.3 - Identity & Key Vault**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories identity, keyvault, entra
```

### Phase 2: Messaging & Events (2 PRs)

**PR 2.1 - Event & Service Bus**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories eventhub, servicebus, eventgrid, relay
```

**PR 2.2 - Messaging Extensions**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories schemaregistry, signalr, webpubsub, notificationhubs
```

### Phase 3: AI & Cognitive Services (3 PRs)

**PR 3.1 - AI Core**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories ai, openai, cognitiveservices
```

**PR 3.2 - AI Language & Vision**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories cognitivelanguage, textanalytics, vision, face, formrecognizer, documentintelligence
```

**PR 3.3 - AI Specialized**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories anomalydetector, personalizer, metricsadvisor, healthinsights, contentsafety, contentunderstanding
```

### Phase 4: Data & Analytics (3 PRs)

**PR 4.1 - Cosmos DB & Search**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories cosmosdb, cosmosdbforpostgresql, search, tables
```

**PR 4.2 - SQL & Database Services**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories sqlmanagement, sqlvirtualmachine, mysql, postgresql, databasewatcher
```

**PR 4.3 - Analytics & Monitoring**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories monitor, operationalinsights, applicationinsights, streamanalytics, synapse, kusto
```

### Phase 5: Compute & Containers (3 PRs)

**PR 5.1 - Compute**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories compute, computefleet, computelimit, computerecommender, computeschedule, batch
```

**PR 5.2 - Container Services**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories containerregistry, containerservice, containerapps, containerinstance, containerorchestratorruntime
```

**PR 5.3 - Kubernetes & Orchestration**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories kubernetesconfiguration, hybridkubernetes, hybridaks, fleet
```

### Phase 6: Networking (2 PRs)

**PR 6.1 - Core Networking**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories network, frontdoor, cdn, trafficmanager, dns, privatedns, dnsresolver
```

**PR 6.2 - Advanced Networking**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories networkanalytics, networkcloud, networkfunction, servicenetworking, managednetwork, managednetworkfabric, peering
```

### Phase 7: IoT & Edge (2 PRs)

**PR 7.1 - IoT Core**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories iot, iothub, iotcentral, iotoperations, deviceprovisioningservices, deviceupdate, deviceregistry
```

**PR 7.2 - Edge Services**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories edgeactions, edgeorder, edgezones, databox, databoxedge
```

### Phase 8: Security & Governance (2 PRs)

**PR 8.1 - Security Services**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories securitycenter, securityinsights, securitydevops, attestation, confidentialledger, hardwaresecuritymodules, trustedsigning
```

**PR 8.2 - Governance & Compliance**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories policyinsights, authorization, blueprint, appcomplianceautomation, guestconfiguration
```

### Phase 9: Management & Operations (3 PRs)

**PR 9.1 - Resource Management**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories resourcemanager, resources, resourcegraph, resourcehealth, resourcemover, resourceconnector
```

**PR 9.2 - Recovery & Backup**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories recoveryservices, recoveryservices-backup, recoveryservices-datareplication, recoveryservices-siterecovery, dataprotection
```

**PR 9.3 - Management Tools**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories automation, automanage, maintenance, changeanalysis, chaos, selfhelp, support
```

### Phase 10: Application Services (3 PRs)

**PR 10.1 - App Platform & Functions**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories appplatform, appconfiguration, websites, extension-wcf, extensions
```

**PR 10.2 - Integration & Messaging**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories logic, apimanagement, servicelinker, servicefabric, servicefabricmanagedclusters
```

**PR 10.3 - Dev Services**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories devcenter, devopsinfrastructure, devspaces, devtestlabs, labservices
```

### Phase 11: Communication & Media (2 PRs)

**PR 11.1 - Communication Services**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories communication, voiceservices, botservice
```

**PR 11.2 - Media & Mixed Reality**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories mediaservices, videoanalyzer, mixedreality, objectanchors, remoterendering, digitaltwins
```

### Phase 12: Data Services (2 PRs)

**PR 12.1 - Data Lake & Migration**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories datalake-analytics, datalake-store, datamigration, datashare, datafactory
```

**PR 12.2 - Data Platform Services**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories purview, openenergyplatform, modelsrepository, healthdataaiservices
```

### Phase 13: Hybrid & Arc (2 PRs)

**PR 13.1 - Hybrid Services**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories hybridcompute, hybridconnectivity, hybridnetwork, extendedlocation
```

**PR 13.2 - Arc Services**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories arc-scvmm, connectedvmwarevsphere, azurestackhci
```

### Phase 14: Specialized Services A (3 PRs)

**PR 14.1 - Healthcare & Life Sciences**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories healthcareapis, healthbot, agrifood, agricultureplatform
```

**PR 14.2 - Desktop & Gaming**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories desktopvirtualization, playwright, loadtestservice, onlineexperimentation
```

**PR 14.3 - Machine Learning**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories machinelearningservices, machinelearningcompute, quantum
```

### Phase 15: Specialized Services B (3 PRs)

**PR 15.1 - Observability**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories grafana, dynatrace, elastic, datadog, newrelicobservability
```

**PR 15.2 - Marketplace & Billing**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories marketplace, marketplaceordering, billing, billingbenefits, costmanagement, consumption, reservations, quota
```

**PR 15.3 - Partner Services**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories confluent, oracle, informaticadatamanagement, qumulo, dellstorage, purestorageblock, paloaltonetworks.ngfw
```

### Phase 16: Specialized Services C (3 PRs)

**PR 16.1 - Maps & Spatial**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories maps, orbital, planetarycomputer, sphere
```

**PR 16.2 - Specialized Databases**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories redis, redisenterprise, mongocluster, mongodbatlas, neonpostgres, pineconevectordb
```

**PR 16.3 - Infrastructure Services**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories netapp, elasticsan, fileshares, fluidrelay, standbypool
```

### Phase 17: Remaining SDK Services (3 PRs)

**PR 17.1 - Migration & Discovery**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories migrationassessment, migrationdiscoverysap, springappdiscovery, dependencymap
```

**PR 17.2 - Workload Services**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories workloadmonitor, workloadorchestration, workloads, workloadssapvirtualinstance, sitemanager
```

**PR 17.3 - Miscellaneous A**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories advisor, alertsmanagement, analysisservices, apicenter, astronomer, avs, azurelargeinstance
```

### Phase 18: Final SDK Services (3 PRs)

**PR 18.1 - Miscellaneous B**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories carbon, cloudhealth, cloudmachine, connectedcache, customer-insights, defendereasm, disconnectedoperations, durabletask, easm
```

**PR 18.2 - Miscellaneous C**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories fabric, graphrbac, graphservices, impactreporting, lambdatesthyperexecute, managementpartner, managedserviceidentity, managedservices, mobilenetwork
```

**PR 18.3 - Miscellaneous D**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories nginx, portalservices, powerbidedicated, providerhub, provisioning, secretsstoreextension, subscription, terraform, timeseriesinsights, translation, virtualenclaves, weightsandbiases
```

### Phase 19: Agent Server (1 PR)

**PR 19.1 - Agent Server**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories agentserver, arizeaiobservabilityeval
```

### Phase 20: Generator Projects (1 PR)

**PR 20.1 - Azure Generator**

The generator projects are outside `sdk/` and cannot use `run-migration.ps1`. Migrate manually:

1. **Find test projects**:
   ```powershell
   Get-ChildItem -Recurse -Filter "*.csproj" eng\packages\http-client-csharp | Select-String "NUnit" | Select-Object -ExpandProperty Path -Unique
   Get-ChildItem -Recurse -Filter "*.csproj" eng\packages\http-client-csharp-mgmt | Select-String "NUnit" | Select-Object -ExpandProperty Path -Unique
   ```

2. **Temporarily add NUnit.Analyzers** to each test `.csproj`:
   ```xml
   <PackageReference Include="NUnit.Analyzers" Version="4.5.0" PrivateAssets="All" />
   ```

3. **Run dotnet format** for each test project:
   ```powershell
   dotnet restore <test-project.csproj>
   dotnet format analyzers <test-project.csproj> --diagnostics NUnit2001 NUnit2002 NUnit2003 NUnit2004 NUnit2005 NUnit2006 NUnit2007 NUnit2008 NUnit2009 NUnit2010 NUnit2011 NUnit2012 NUnit2013 NUnit2014 NUnit2015 NUnit2016 NUnit2017 NUnit2018 NUnit2019 NUnit2020 NUnit2021 NUnit2022 NUnit2023 NUnit2024 NUnit2025 NUnit2026 NUnit2027 NUnit2028 NUnit2029 NUnit2030 NUnit2031 NUnit2032 NUnit2033 NUnit2034 NUnit2035 NUnit2036 NUnit2037 NUnit2038 NUnit2039 NUnit2040 NUnit2041 NUnit2042 NUnit2043 NUnit2044 NUnit2045 NUnit2046 NUnit2047 NUnit2048 NUnit2049 NUnit2050 --severity info --no-restore
   ```

4. **Remove the temporary NUnit.Analyzers reference** from each `.csproj`

5. **Add NUnit 4 override** to `eng/Packages.Data.props`:
   ```xml
   <!-- NUnit 4 migration: Azure Generator -->
   <ItemGroup Condition="$(MSBuildProjectDirectory.Contains('\eng\packages\http-client-csharp\'))">
     <PackageReference Update="NUnit" Version="4.4.0" />
     <PackageReference Update="NUnit3TestAdapter" Version="4.6.0" />
     <PackageReference Update="NUnit.Analyzers" Version="4.5.0" />
   </ItemGroup>
   ```

6. **Build and test**:
   ```powershell
   dotnet build eng\packages\http-client-csharp\Azure.Generator.sln
   dotnet test eng\packages\http-client-csharp\Azure.Generator.sln
   ```

7. **Apply manual fixups** per the checklist in Step 4 of the Migration Process

### Phase 21: Other Common Test Projects (1 PR)

**PR 21.1 - Common Test Infrastructure**

These projects are outside `sdk/` and cannot use `run-migration.ps1`. Follow the same manual process as PR 20.1:

Directories to check for test projects:
- `common/ManagementTestShared`
- `common/Perf`
- `common/SmokeTests`

For each directory:
1. Find `.csproj` files that reference NUnit: `Get-ChildItem -Recurse -Filter "*.csproj" <dir> | Select-String "NUnit"`
2. If found, temporarily add `NUnit.Analyzers`, run `dotnet format analyzers`, and remove the temporary reference
3. Add a conditional `ItemGroup` override to `eng/Packages.Data.props` for the path
4. Build and test

---

## Final Cleanup PR

After **all** phase PRs are merged, submit one final PR:

1. **Update the central NUnit version** in `eng/Packages.Data.props`: change `<NUnitVersion>3.14.0</NUnitVersion>` to `<NUnitVersion>4.4.0</NUnitVersion>` (around line 24)
2. **Remove all conditional NUnit 4 override `ItemGroup` blocks** added during migration (they are no longer needed since the central version is now 4.4.0)
3. **Remove the existing NUnit 4 override** for `Microsoft.ClientModel.TestFramework` (around line 595 — this was the early adopter and will now use the central version)
4. **Delete the migration scripts**: `eng/scripts/nunitmigration/`
5. **Build the full repo** to verify: `dotnet build eng/service.proj`
6. Commit and submit PR

---

## Architecture Notes

### How NUnit Dependencies Flow

There are two paths by which test projects get NUnit:

1. **Data plane test projects**: declare `<PackageReference Include="NUnit" />` explicitly in their `.csproj`. The version comes from `eng/Packages.Data.props` via central package management.
2. **Management plane test projects**: get NUnit injected automatically via `eng/Directory.Build.Common.targets` (the `IsMgmtLibrary` + `IsTestProject` condition). They do NOT declare NUnit in their `.csproj`.

The `run-migration.ps1` script handles both paths: for data plane projects, it temporarily adds `NUnit.Analyzers` to the `.csproj`; for management plane projects, it relies on the central injection in `Directory.Build.Common.targets`.

### Why Conditional ItemGroups

The conditional `ItemGroup` pattern in `eng/Packages.Data.props` allows migrated services to use NUnit 4 while unmigrated services stay on NUnit 3. The `MSBuildProjectDirectory.Contains('\sdk\<service>\')` condition scopes the override to only projects under that service directory. This is the same pattern already used for `Microsoft.ClientModel.TestFramework` (the first NUnit 4 adopter in the repo).

---

## Troubleshooting

### Build Errors After Migration

| Symptom | Cause | Fix |
|---------|-------|-----|
| `Assert.AreEqual` does not exist | Migration script missed this file, or file was not compiled when analyzers ran | Re-run `dotnet format analyzers` on the specific project, or manually convert to `Assert.That(x, Is.EqualTo(y))` |
| `FileAssert` / `DirectoryAssert` does not exist | No code fixer exists for these | Manually convert (see Manual Fixup Checklist) |
| `StringAssert` does not exist | Code fixer missed this call | Manually convert to `Assert.That(str, Does.StartWith(...))` etc. |
| `Assert.That` overload not found (params) | Format spec overload was removed in NUnit 4 | Convert `Assert.That(x, constraint, "msg {0}", arg)` to `Assert.That(x, constraint, $"msg {arg}")` |
| `TestContext.CurrentContext.Result` does not exist | Removed in NUnit 4 | Remove or replace with alternative test introspection |
| Conditional ItemGroup not taking effect | Path condition doesn't match | Verify `MSBuildProjectDirectory` path uses backslashes and matches the actual directory structure |

### Test Failures After Migration

| Symptom | Cause | Fix |
|---------|-------|-----|
| Assertion message text changed | NUnit 4 formats constraint model messages differently than classic asserts | Update any tests that assert on exact failure message text |
| `MissingMethodException` at runtime | A dependency still targets NUnit 3 classic asserts | Ensure all `ProjectReference`d test support libraries are also migrated |
| Tests pass locally but fail in CI | CI may not pick up the conditional ItemGroup | Verify the `eng/Packages.Data.props` change is committed and pushed |

### Recovery from Partial Migration

If a migration batch is interrupted:
1. Ensure Step 3 (version override in `eng/Packages.Data.props`) is complete for any services whose code was already modified
2. Commit all changes
3. The partial batch can still be submitted as a PR — unmigrated services in the batch can be moved to a later PR
