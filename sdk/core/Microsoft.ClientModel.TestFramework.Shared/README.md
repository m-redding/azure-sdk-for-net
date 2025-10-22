# Microsoft.ClientModel.TestFramework.Shared

This is a shared source project that contains common code shared between:
- `Microsoft.ClientModel.TestFramework` - Test framework for System.ClientModel-based libraries
- `Azure.Core.TestFramework` - Test framework for Azure.Core-based libraries

## Structure

The shared source is organized into logical groups:

- **Attributes** - Common test attributes like `LiveOnlyAttribute`, `PlaybackOnlyAttribute`, etc.
- **Core** - Core utilities, enums, and base classes
- **Utilities** - Helper classes like `TestRandom`, retry helpers, etc.
- **Recording** - Common recording infrastructure and abstractions

## Usage

This project uses MSBuild shared source projects (`.projitems` files) to share code between the two test frameworks without creating assembly dependencies. Each consuming project imports the relevant `.projitems` files they need.

## Design Principles

- Framework agnostic - code here should not depend on Azure.Core or System.ClientModel directly
- Uses generic type parameters and interfaces for extensibility
- Maintains type safety while enabling code reuse
- Supports the "perma beta" nature of the test frameworks (breaking changes allowed)