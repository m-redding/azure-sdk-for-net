// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace Microsoft.ClientModel.TestFramework.Shared.Attributes
{
    /// <summary>
    /// Attribute on test assemblies, classes, or methods that run only against live resources.
    /// This is a framework-agnostic version that works with any test framework that defines
    /// RecordedTestMode and a TestEnvironment.GlobalTestMode property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = false, Inherited = true)]
    public abstract class LiveOnlyAttributeBase : NUnitAttribute, IApplyToTest
    {
        private readonly bool _alwaysRunLocally;

        /// <summary>
        /// Optional reason that the test is marked LiveOnly.
        /// </summary>
        public string? Reason { get; set; }

        /// <summary>
        /// Creates a new LiveOnlyAttribute instance.
        /// </summary>
        /// <param name="alwaysRunLocally">If true, the test will still be run even if the Mode is not Live.
        /// This can be used to allow tests that do not depend on RecordedTestMode to run locally, while still being skipped in CI.</param>
        protected LiveOnlyAttributeBase(bool alwaysRunLocally = false)
        {
            _alwaysRunLocally = alwaysRunLocally;
        }

        /// <summary>
        /// Gets the current test mode from the framework-specific implementation.
        /// </summary>
        /// <returns>The current recorded test mode.</returns>
        protected abstract object GetCurrentTestMode();

        /// <summary>
        /// Checks if the current test mode is Live mode.
        /// </summary>
        /// <param name="mode">The test mode returned by GetCurrentTestMode().</param>
        /// <returns>True if the mode represents Live mode.</returns>
        protected abstract bool IsLiveMode(object mode);

        /// <summary>
        /// Gets the string representation of the test mode for error messages.
        /// </summary>
        /// <param name="mode">The test mode.</param>
        /// <returns>String representation of the mode.</returns>
        protected abstract string GetModeString(object mode);

        /// <summary>
        /// Modifies the <paramref name="test"/> by adding categories to it and changing the run state as needed.
        /// </summary>
        /// <param name="test">The <see cref="Test"/> to modify.</param>
        public void ApplyToTest(Test test)
        {
            test.Properties.Add("Category", "Live");

            if (test.RunState != RunState.NotRunnable)
            {
                var mode = GetCurrentTestMode();
                if (!IsLiveMode(mode) && !_alwaysRunLocally)
                {
                    test.RunState = RunState.Ignored;
                    test.Properties.Set("_SKIPREASON", $"Live tests will not run when test mode is {GetModeString(mode)}");
                }
            }
        }
    }
}