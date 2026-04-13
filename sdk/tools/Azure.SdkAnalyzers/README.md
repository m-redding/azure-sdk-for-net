# Azure SDK Analyzers

Roslyn analyzers that enforce [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) for .NET library authors.

This package is automatically included in all Azure SDK libraries in this repository to ensure consistent code quality and adherence to Azure SDK conventions.

## Implemented Rules

### Unsuppressible (Error severity)

These rules enforce internal implementation correctness and **cannot be suppressed** via `#pragma`, `<NoWarn>`, or `.editorconfig`.

| Rule | Description | Fix |
|------|-------------|-----|
| [**AZC0108**](docs/AZC0108.md) | Incorrect `async` parameter value | ✅* |

\* Fix only offered when containing method has a `bool async` parameter to forward.

### Suppressible (Warning severity)

| Rule | Description |
|------|-------------|
| [**AZC0012**](docs/list-of-diagnostics.md#azc0012) | Avoid single word type names |
| [**AZC0020**](docs/AZC0020.md) | Propagate CancellationToken to RequestContext |

## For Library Authors

These analyzers run automatically during build and will produce warnings when your code doesn't follow Azure SDK conventions. Review the [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) for detailed guidance on all rules.

For detailed information about each diagnostic rule, see the [list of diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/tools/Azure.SdkAnalyzers/docs/list-of-diagnostics.md).
