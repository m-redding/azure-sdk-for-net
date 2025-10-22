// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace Microsoft.ClientModel.TestFramework.Shared.Attributes
{
    /// <summary>
    /// Attribute on test assemblies, classes, or methods that run only against playback resources.
    /// This is a framework-agnostic version that works with any test framework that defines
    /// RecordedTestMode and a TestEnvironment.GlobalTestMode property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = true, Inherited = true)]
    public abstract class PlaybackOnlyAttributeBase : NUnitAttribute, IApplyToTest
    {
        private readonly string _reason;

        /// <summary>
        /// Constructs the attribute giving a reason the associated tests is playback only.
        /// </summary>
        protected PlaybackOnlyAttributeBase(string reason)
        {
            _reason = reason;
        }

        /// <summary>
        /// Gets the current test mode from the framework-specific implementation.
        /// </summary>
        /// <returns>The current recorded test mode.</returns>
        protected abstract object GetCurrentTestMode();

        /// <summary>
        /// Checks if the current test mode is Playback mode.
        /// </summary>
        /// <param name="mode">The test mode returned by GetCurrentTestMode().</param>
        /// <returns>True if the mode represents Playback mode.</returns>
        protected abstract bool IsPlaybackMode(object mode);

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
            if (test.RunState != RunState.NotRunnable)
            {
                var mode = GetCurrentTestMode();
                if (!IsPlaybackMode(mode))
                {
                    test.RunState = RunState.Ignored;
                    test.Properties.Set("_SKIPREASON", $"Playback tests will not run when test mode is {GetModeString(mode)}. This test was skipped for the following reason: {_reason}");
                }
            }
        }
    }
}