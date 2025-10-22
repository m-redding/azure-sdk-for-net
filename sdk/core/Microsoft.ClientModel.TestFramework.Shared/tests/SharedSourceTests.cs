// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework.Shared.Attributes;
using Microsoft.ClientModel.TestFramework.Shared.Core;
using Microsoft.ClientModel.TestFramework.Shared.Utilities;
using NUnit.Framework;
using System;

namespace Microsoft.ClientModel.TestFramework.Shared.Tests
{
    /// <summary>
    /// Basic tests to validate the shared source project structure and compilation.
    /// </summary>
    [TestFixture]
    public class SharedSourceTests
    {
        [Test]
        public void RecordedTestMode_HasExpectedValues()
        {
            // Arrange & Act
            var liveMode = RecordedTestMode.Live;
            var recordMode = RecordedTestMode.Record;
            var playbackMode = RecordedTestMode.Playback;
            var noneMode = RecordedTestMode.None;

            // Assert
            Assert.That(liveMode, Is.EqualTo(RecordedTestMode.Live));
            Assert.That(recordMode, Is.EqualTo(RecordedTestMode.Record));
            Assert.That(playbackMode, Is.EqualTo(RecordedTestMode.Playback));
            Assert.That(noneMode, Is.EqualTo(RecordedTestMode.Live)); // None is an alias for Live
        }

        [Test]
        public void TestRandom_CreatesInstancesWithDifferentModes()
        {
            // Arrange & Act
            var liveRandom = new TestRandom(RecordedTestMode.Live);
            var recordRandom = new TestRandom(RecordedTestMode.Record, 42);
            var playbackRandom = new TestRandom(RecordedTestMode.Playback, 42);

            // Assert
            Assert.That(liveRandom, Is.Not.Null);
            Assert.That(recordRandom, Is.Not.Null);
            Assert.That(playbackRandom, Is.Not.Null);

            // Test that seeded randoms produce consistent results
            var guid1 = recordRandom.NewGuid();
            var guid2 = playbackRandom.NewGuid();
            Assert.That(guid1, Is.EqualTo(guid2)); // Same seed should produce same GUID
        }

        [Test]
        public void TestRandom_LiveModeProducesRandomGuids()
        {
            // Arrange
            var liveRandom = new TestRandom(RecordedTestMode.Live);

            // Act
            var guid1 = liveRandom.NewGuid();
            var guid2 = liveRandom.NewGuid();

            // Assert
            Assert.That(guid1, Is.Not.EqualTo(guid2));
            Assert.That(guid1, Is.Not.EqualTo(Guid.Empty));
            Assert.That(guid2, Is.Not.EqualTo(Guid.Empty));
        }

        [Test]
        public void Attributes_CanBeInstantiated()
        {
            // Arrange & Act
            var syncOnly = new SyncOnlyAttribute();
            var asyncOnly = new AsyncOnlyAttribute();

            // Assert
            Assert.That(syncOnly, Is.Not.Null);
            Assert.That(asyncOnly, Is.Not.Null);
        }

        [Test]
        public void TaskExtensions_DefaultTimeoutIsSet()
        {
            // Arrange & Act
            var timeout = TaskExtensions.DefaultTimeout;

            // Assert
            Assert.That(timeout, Is.EqualTo(TimeSpan.FromSeconds(10)));
        }
    }
}