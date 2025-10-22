// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Microsoft.ClientModel.TestFramework.Shared.Attributes
{
    /// <summary>
    /// Marks that a test should only be executed synchronously (in a test
    /// fixture derived from test base classes that support sync/async test variations).
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = false, Inherited = true)]
    public class SyncOnlyAttribute : NUnitAttribute
    {
    }
}