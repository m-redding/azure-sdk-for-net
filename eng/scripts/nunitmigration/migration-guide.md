# NUnit 4 Migration Guide

This guide provides precise, self-contained instructions for migrating the azure-sdk-for-net repository from NUnit 3.14.0 to NUnit 4.4.0. Each PR task is designed to be delegated to a subagent, a Copilot coding agent, or executed by a human — with no interactive decisions required.

## Background

NUnit 4.0 has several breaking changes vs NUnit 3.14.0:

1. **Classic Assert methods removed from `Assert`** — methods like `Assert.AreEqual`, `Assert.IsTrue`, `Assert.IsNull` etc. have been moved to `ClassicAssert` in `NUnit.Framework.Legacy`. The preferred path is to convert them to the constraint model (`Assert.That(...)`).
2. **Shorthand Assert methods removed** — `Assert.True`, `Assert.False`, `Assert.Null`, `Assert.NotNull` (without the `Is` prefix) are also removed and must be converted.
3. **`StringAssert` removed** — `StringAssert.Contains`, `StringAssert.StartsWith`, `StringAssert.EndsWith`, `StringAssert.IsMatch`, etc. must be converted to `Assert.That(str, Does.Contain(...))` style.
4. **`CollectionAssert` removed** — `CollectionAssert.AreEqual`, `CollectionAssert.Contains`, `CollectionAssert.IsEmpty`, etc. must be converted to `Assert.That(collection, Is.EqualTo(...))` style.
5. **`Assert.That` format specification and `params` overloads removed** — calls like `Assert.That(x, Is.EqualTo(y), "msg {0}", arg)` must become `Assert.That(x, Is.EqualTo(y), $"msg {arg}")`.

The NUnit.Analyzers code fixes (diagnostics NUnit2001–NUnit2050) via `dotnet format` automate a significant portion of these conversions. For complex projects with many shared/linked source files (like `core`), coverage may be as low as ~50%; for typical service directories with straightforward test projects, expect **80-90%** coverage. The remaining assertions are fixed manually by the delegated agent guided by build errors.

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
| `run-migration.ps1` | Automated migration: finds test projects in given service dirs, temporarily adds `NUnit.Analyzers` to data plane projects, runs `dotnet format analyzers` with NUnit2xxx diagnostics, reverts `.csproj` changes |
| `post-migration.ps1` | Finalization: adds NUnit 4 conditional version override (NUnit 4.4.0 **only**) to `eng/Packages.Data.props` for migrated services, removes temporary `NUnit.Analyzers` from central files, verifies no `.csproj` drift |
| `test-run-builds.ps1` | Validation: builds all `.sln` files in given service dirs with retry-on-restore-failure logic, parses and reports errors organized by project |

## Migration Process (Per PR)

Each PR migrates a batch of related service directories. The steps below are fully self-contained — a delegated agent should execute them in order.

### Step 1: Create a Branch and Run Setup

```powershell
git checkout -b nunit4-migration-<batch-name> main
.\eng\scripts\nunitmigration\setup.ps1
```

The setup script adds `NUnit.Analyzers` to the central package files so that both data plane and management plane test projects can use the analyzer during migration. This creates a commit automatically.

### Step 2: Run the Analyzer-Based Migration Script

Pass all service directories for this batch in a single invocation:

```powershell
.\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories <service1>, <service2>, ...
```

This script will:
1. Find all test projects (`*Tests.csproj`) in each `sdk/<service>/` directory
2. For data plane projects (those with an explicit `<PackageReference Include="NUnit" />`), temporarily add `NUnit.Analyzers` to the `.csproj`
3. Run `dotnet restore` then `dotnet format analyzers --diagnostics NUnit2001 NUnit2002 ... NUnit2050 --severity info --no-restore` on each test project
4. Revert all `.csproj` changes via `git checkout HEAD` to avoid whitespace-only diffs

> **⚠️ Important:** This step only processes test projects (`*Tests.csproj`) — it does **not** touch `src/` projects or shared/linked source files that may also contain Assert calls. For typical service directories, expect **80-90%** automated coverage. For complex projects like `core` with many shared files, coverage may be lower (~50%). All remaining assertions are fixed manually in Step 4.

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
1. Add a conditional `ItemGroup` to `eng/Packages.Data.props` that overrides **only NUnit to 4.4.0** for the migrated service directories
2. Remove the temporary `NUnit.Analyzers` property and `PackageReference` from `eng/Packages.Data.props`
3. Remove the temporary `NUnit.Analyzers` from the management plane `ItemGroup` in `eng/Directory.Build.Common.targets`
4. Verify no `.csproj` files were accidentally modified; revert any that were
5. Commit the changes automatically

> **⚠️ Critical:** The conditional override must contain **only** the NUnit 4.4.0 `PackageReference`. Do **not** include `NUnit3TestAdapter` (already at 4.6.0 centrally and compatible with both NUnit 3 and 4) or `NUnit.Analyzers` (including it in the override causes analyzer diagnostics to surface as build errors, breaking the build).

Correct override format:
```xml
<!-- NUnit 4 migration: <service-list> -->
<ItemGroup Condition="$(MSBuildProjectDirectory.Contains('\sdk\<service>\'))">
  <PackageReference Update="NUnit" Version="4.4.0" />
</ItemGroup>
```

### Step 4: Build, Fix Remaining Errors, Iterate

Build all solutions for the migrated services:

```powershell
.\eng\scripts\nunitmigration\test-run-builds.ps1 -ServiceDirectories <service1>, <service2>, ...
```

This script builds each `.sln` file (first with `--no-restore` for speed, retrying with full restore on failure) and reports errors organized by project.

The build errors are your TODO list. Fix each one manually (or delegate to a subagent), then rebuild. **Iterate**: fix errors → rebuild → repeat until all solutions build cleanly.

To run tests manually:
```powershell
# For each test project in sdk/<service-name>/**/tests/*.csproj:
dotnet test <test-project.csproj>
```

#### Conversion Reference

The build errors from `test-run-builds.ps1` tell you exactly which assertions still need converting. Use this reference for the correct conversions:

**Classic Assert → Assert.That:**
| Before | After |
|--------|-------|
| `Assert.AreEqual(expected, actual)` | `Assert.That(actual, Is.EqualTo(expected))` |
| `Assert.AreNotEqual(expected, actual)` | `Assert.That(actual, Is.Not.EqualTo(expected))` |
| `Assert.IsTrue(expr)` / `Assert.True(expr)` | `Assert.That(expr, Is.True)` |
| `Assert.IsFalse(expr)` / `Assert.False(expr)` | `Assert.That(expr, Is.False)` |
| `Assert.IsNull(expr)` / `Assert.Null(expr)` | `Assert.That(expr, Is.Null)` |
| `Assert.IsNotNull(expr)` / `Assert.NotNull(expr)` | `Assert.That(expr, Is.Not.Null)` |
| `Assert.IsEmpty(expr)` | `Assert.That(expr, Is.Empty)` |
| `Assert.IsNotEmpty(expr)` | `Assert.That(expr, Is.Not.Empty)` |
| `Assert.Greater(a, b)` | `Assert.That(a, Is.GreaterThan(b))` |
| `Assert.Less(a, b)` | `Assert.That(a, Is.LessThan(b))` |
| `Assert.GreaterOrEqual(a, b)` | `Assert.That(a, Is.GreaterThanOrEqualTo(b))` |
| `Assert.LessOrEqual(a, b)` | `Assert.That(a, Is.LessThanOrEqualTo(b))` |
| `Assert.Contains(expected, collection)` | `Assert.That(collection, Does.Contain(expected))` |
| `Assert.AreSame(expected, actual)` | `Assert.That(actual, Is.SameAs(expected))` |
| `Assert.AreNotSame(expected, actual)` | `Assert.That(actual, Is.Not.SameAs(expected))` |
| `Assert.IsInstanceOf<T>(expr)` | `Assert.That(expr, Is.InstanceOf<T>())` |

**StringAssert → Assert.That:**
| Before | After |
|--------|-------|
| `StringAssert.Contains(expected, actual)` | `Assert.That(actual, Does.Contain(expected))` |
| `StringAssert.StartsWith(expected, actual)` | `Assert.That(actual, Does.StartWith(expected))` |
| `StringAssert.EndsWith(expected, actual)` | `Assert.That(actual, Does.EndWith(expected))` |
| `StringAssert.IsMatch(pattern, actual)` | `Assert.That(actual, Does.Match(pattern))` |
| `StringAssert.DoesNotContain(expected, actual)` | `Assert.That(actual, Does.Not.Contain(expected))` |
| `StringAssert.DoesNotMatch(pattern, actual)` | `Assert.That(actual, Does.Not.Match(pattern))` |

**CollectionAssert → Assert.That:**
| Before | After |
|--------|-------|
| `CollectionAssert.AreEqual(expected, actual)` | `Assert.That(actual, Is.EqualTo(expected))` |
| `CollectionAssert.AreEquivalent(expected, actual)` | `Assert.That(actual, Is.EquivalentTo(expected))` |
| `CollectionAssert.Contains(collection, item)` | `Assert.That(collection, Does.Contain(item))` |
| `CollectionAssert.DoesNotContain(collection, item)` | `Assert.That(collection, Does.Not.Contain(item))` |
| `CollectionAssert.IsEmpty(collection)` | `Assert.That(collection, Is.Empty)` |
| `CollectionAssert.IsNotEmpty(collection)` | `Assert.That(collection, Is.Not.Empty)` |
| `CollectionAssert.AllItemsAreNotNull(collection)` | `Assert.That(collection, Has.None.Null)` |
| `CollectionAssert.AllItemsAreUnique(collection)` | `Assert.That(collection, Is.Unique)` |
| `CollectionAssert.IsOrdered(collection)` | `Assert.That(collection, Is.Ordered)` |
| `CollectionAssert.IsSubsetOf(subset, superset)` | `Assert.That(subset, Is.SubsetOf(superset))` |

**Other patterns:**
| Before | After |
|--------|-------|
| `FileAssert.Exists(path)` | `Assert.That(File.Exists(path), Is.True)` |
| `DirectoryAssert.Exists(path)` | `Assert.That(Directory.Exists(path), Is.True)` |
| `Assert.That(x, constraint, "msg {0}", arg)` | `Assert.That(x, constraint, $"msg {arg}")` |
| `Assert.That(val, Is.EqualTo(null))` *(ambiguous)* | `Assert.That(val, Is.EqualTo((string?)null))` |

> **Note on `Assert.That` message arguments:** Any assertion with `params`-style format strings like `"Expected {0}", arg` must be converted to interpolated strings `$"Expected {arg}"`. The `params` overload was removed in NUnit 4.

#### Additional Patterns to Watch For

1. **`Assert.True(x == y)` converted to `Assert.That(x, Is.EqualTo(y))`** — `dotnet format` sometimes decomposes `Assert.True(x == y)` into `Assert.That(x, Is.EqualTo(y))`. This silently changes the semantics: `Is.EqualTo` calls `.Equals()`, NOT the `==` operator. For types that define custom `==` (e.g., `ETag`, `HttpRange`, `DynamicData`), the test is no longer testing what it was intended to test. The correct conversion is `Assert.That(x == y, Is.True)`. **After each migration, grep for this pattern:**
   ```powershell
   # Find Is.EqualTo lines that may have been == operator tests
   git diff main -- "sdk/<service>/**/*.cs" | Select-String "Assert\.(True|IsTrue|False|IsFalse)\s*\(.*(==|!=)" -Context 0,3
   ```

2. **`src/` projects containing Assert calls** — Some source projects (not test projects) contain NUnit assertions (e.g., `TestActivitySourceListener.cs` in `Azure.Core`). These are not processed by `run-migration.ps1`. Search:
   ```powershell
   Get-ChildItem -Recurse -Filter "*.cs" sdk/<service>/*/src | Select-String 'Assert\.|StringAssert\.|CollectionAssert\.'
   ```

3. **`TestContext.CurrentContext.Result`** — Removed in NUnit 4. Search and remove or replace:
   ```powershell
   Get-ChildItem -Recurse -Filter "*.cs" sdk/<service> | Select-String "TestContext.CurrentContext.Result"
   ```

3. **Custom assertion helpers / extension methods** — If the service has wrapper methods around classic asserts, those wrappers need updates too.

After fixing, commit:
```powershell
git add .
git commit -m "Fix remaining assertion patterns for <service-list>"
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

## Lessons Learned (PR 1.1 Trial Run)

The following findings were discovered during the PR 1.1 trial run (core + template, 13 projects, 230 files changed, ~7,500 assertions converted):

### Key Findings

1. **`dotnet format` effectiveness varies by project complexity.** For `core` — which has many shared/linked source files and src/ projects containing assertions — coverage was ~50%. For typical service directories with self-contained test projects, expect **80-90%** coverage. The remainder must be fixed manually.

2. **The post-migration override must contain only `NUnit 4.4.0`.** Including `NUnit.Analyzers` in the override causes every analyzer suggestion to become a build error. `NUnit3TestAdapter` is already at a compatible version (4.6.0) centrally and doesn't need overriding.

3. **`StringAssert` and `CollectionAssert` are completely removed**, not just deprecated. `dotnet format` does not always catch these. They affected 96 call sites in core alone.

4. **Shorthand Assert methods (`True`, `False`, `Null`, `NotNull`)** are separate API entries from `IsTrue`, `IsFalse`, etc. and are also removed. They must be handled as a distinct pattern.

5. **`--no-restore` builds can fail with CS1705 version mismatches** when the NuGet cache has stale NUnit 3 assemblies. The `test-run-builds.ps1` script handles this with automatic retry-with-restore logic.

6. **`src/` projects can contain Assert calls** (e.g., `TestActivitySourceListener.cs` in `Azure.Core`). These are not processed by `run-migration.ps1` and will show up as build errors.

7. **`Is.EqualTo(null)` can become ambiguous** after conversion — add an explicit cast like `(string?)null` or `(object?)null`.

8. **Format string message args (`"msg {0}", arg`)** must be converted to interpolated strings (`$"msg {arg}"`). The `params` overload was removed in NUnit 4.

### Recommended Workflow for Delegated Agents

When delegating a PR to a subagent or coding agent, provide these explicit instructions:

1. Run `setup.ps1` (creates a commit)
2. Run `run-migration.ps1 -ServiceDirectories <list>`
3. Commit code changes
4. Run `post-migration.ps1 -ServiceDirectories <list>` (creates a commit)
5. Run `test-run-builds.ps1 -ServiceDirectories <list>`
6. Fix all remaining build errors manually using the Conversion Reference in Step 4
7. Commit fixes and re-run `test-run-builds.ps1` until clean
8. Push and create PR

---

## Repository Upgrade Plan

The full list of PR batches (Phases 1–21) and the Final Cleanup PR are in **[migration-phases.md](migration-phases.md)**.

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
| CS0117: `Assert` does not contain `AreEqual` / `IsTrue` / etc. | `dotnet format` missed this file (shared file, src/ project, or complex expression) | Manually convert to `Assert.That(...)` using the Conversion Reference |
| CS0117: `StringAssert` does not exist | `StringAssert` was completely removed in NUnit 4; `dotnet format` doesn't always catch these | Convert to `Assert.That(str, Does.Contain(...))` / `Does.StartWith(...)` / etc. |
| CS0117: `CollectionAssert` does not exist | `CollectionAssert` was completely removed in NUnit 4; `dotnet format` doesn't always catch these | Convert to `Assert.That(collection, Is.EqualTo(...))` / `Is.Empty` / etc. |
| CS0117: `Assert.True` / `Assert.False` / `Assert.Null` / `Assert.NotNull` | Shorthand forms (without `Is` prefix) are also removed in NUnit 4 | Convert to `Assert.That(x, Is.True)` / `Is.False` / `Is.Null` / `Is.Not.Null` |
| CS0117: `Assert.IsInstanceOf` | `dotnet format` doesn't always handle the generic form | Manually convert `Assert.IsInstanceOf<T>(x)` → `Assert.That(x, Is.InstanceOf<T>())` |
| CS0121: Ambiguous call `Is.EqualTo(null)` | NUnit 4 has multiple `Is.EqualTo` overloads that both accept `null` | Add explicit cast: `Is.EqualTo((string?)null)` or `Is.EqualTo((object?)null)` |
| CS1501: No overload for `Assert.That` takes N arguments | Format string message args (`"msg {0}", arg`) — the `params` overload was removed | Convert to interpolated string: `$"msg {arg}"` |
| CS1705: Assembly version mismatch (NUnit 3 vs 4) | Stale NuGet cache from `--no-restore` builds | Run `dotnet restore` explicitly, or use `test-run-builds.ps1` which retries with full restore |
| Hundreds of analyzer warnings as errors | `NUnit.Analyzers` was included in the post-migration override | **Remove** `NUnit.Analyzers` from the override `ItemGroup`. Only `NUnit 4.4.0` should be in the override. |
| `FileAssert` / `DirectoryAssert` does not exist | No code fixer or regex rule exists for these | Manually convert: `Assert.That(File.Exists(path), Is.True)` |
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
