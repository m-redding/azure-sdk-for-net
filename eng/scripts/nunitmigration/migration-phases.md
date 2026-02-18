# NUnit 4 Migration — Repository Upgrade Plan

This file lists all PR batches for the NUnit 3 → NUnit 4 migration. For the complete workflow, scripts, troubleshooting, and lessons learned, see [migration-guide.md](migration-guide.md).

## Ordering Constraint

**PR 1.1 (Core Libraries) MUST be merged first.** The `Azure.Core.TestFramework` project in `sdk/core/` is referenced by nearly all test projects via `$(AzureCoreTestFramework)`. It must compile cleanly against NUnit 4 before downstream services are migrated. All other PRs are independent and can be submitted in parallel.

## Workflow Per PR

**For each PR below, follow the complete "Migration Process (Per PR)" workflow in [migration-guide.md](migration-guide.md):**
1. Create a branch and run `setup.ps1`
2. Run `run-migration.ps1` with the listed service directories
3. Commit the code changes, then run `post-migration.ps1` with the same service directories
4. Build with `test-run-builds.ps1`, manually fix all remaining build errors, iterate until clean
5. Submit PR

The service directories for each batch are listed below.

---

## Phase 1: Core Infrastructure (3 PRs) ⚠️ PR 1.1 must merge before all others

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

## Phase 2: Messaging & Events (2 PRs)

**PR 2.1 - Event & Service Bus**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories eventhub, servicebus, eventgrid, relay
```

**PR 2.2 - Messaging Extensions**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories schemaregistry, signalr, webpubsub, notificationhubs
```

## Phase 3: AI & Cognitive Services (3 PRs)

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

## Phase 4: Data & Analytics (3 PRs)

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

## Phase 5: Compute & Containers (3 PRs)

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

## Phase 6: Networking (2 PRs)

**PR 6.1 - Core Networking**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories network, frontdoor, cdn, trafficmanager, dns, privatedns, dnsresolver
```

**PR 6.2 - Advanced Networking**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories networkanalytics, networkcloud, networkfunction, servicenetworking, managednetwork, managednetworkfabric, peering
```

## Phase 7: IoT & Edge (2 PRs)

**PR 7.1 - IoT Core**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories iot, iothub, iotcentral, iotoperations, deviceprovisioningservices, deviceupdate, deviceregistry
```

**PR 7.2 - Edge Services**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories edgeactions, edgeorder, edgezones, databox, databoxedge
```

## Phase 8: Security & Governance (2 PRs)

**PR 8.1 - Security Services**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories securitycenter, securityinsights, securitydevops, attestation, confidentialledger, hardwaresecuritymodules, trustedsigning
```

**PR 8.2 - Governance & Compliance**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories policyinsights, authorization, blueprint, appcomplianceautomation, guestconfiguration
```

## Phase 9: Management & Operations (3 PRs)

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

## Phase 10: Application Services (3 PRs)

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

## Phase 11: Communication & Media (2 PRs)

**PR 11.1 - Communication Services**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories communication, voiceservices, botservice
```

**PR 11.2 - Media & Mixed Reality**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories mediaservices, videoanalyzer, mixedreality, objectanchors, remoterendering, digitaltwins
```

## Phase 12: Data Services (2 PRs)

**PR 12.1 - Data Lake & Migration**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories datalake-analytics, datalake-store, datamigration, datashare, datafactory
```

**PR 12.2 - Data Platform Services**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories purview, openenergyplatform, modelsrepository, healthdataaiservices
```

## Phase 13: Hybrid & Arc (2 PRs)

**PR 13.1 - Hybrid Services**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories hybridcompute, hybridconnectivity, hybridnetwork, extendedlocation
```

**PR 13.2 - Arc Services**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories arc-scvmm, connectedvmwarevsphere, azurestackhci
```

## Phase 14: Specialized Services A (3 PRs)

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

## Phase 15: Specialized Services B (3 PRs)

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

## Phase 16: Specialized Services C (3 PRs)

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

## Phase 17: Remaining SDK Services (3 PRs)

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

## Phase 18: Final SDK Services (3 PRs)

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

## Phase 19: Agent Server (1 PR)

**PR 19.1 - Agent Server**
```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories agentserver, arizeaiobservabilityeval
```

## Phase 20: Generator Projects (1 PR)

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

5. **Add NUnit 4 override** to `eng/Packages.Data.props` (only NUnit — do **not** include NUnit3TestAdapter or NUnit.Analyzers):
   ```xml
   <!-- NUnit 4 migration: Azure Generator -->
   <ItemGroup Condition="$(MSBuildProjectDirectory.Contains('\eng\packages\http-client-csharp\'))">
     <PackageReference Update="NUnit" Version="4.4.0" />
   </ItemGroup>
   ```

6. **Build and test**:
   ```powershell
   dotnet build eng\packages\http-client-csharp\Azure.Generator.sln
   dotnet test eng\packages\http-client-csharp\Azure.Generator.sln
   ```

7. **Apply manual fixups** per the checklist in Step 4 of the [migration guide](migration-guide.md)

## Phase 21: Other Common Test Projects (1 PR)

**PR 21.1 - Common Test Infrastructure**

These projects are outside `sdk/` and cannot use `run-migration.ps1`. Follow the same manual process as PR 20.1.

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
