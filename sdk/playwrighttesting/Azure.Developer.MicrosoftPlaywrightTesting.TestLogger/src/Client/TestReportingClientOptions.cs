// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Client
{
    /// <summary> Client options for TestReporting library clients. </summary>
    public partial class TestReportingClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2024_05_20_Preview;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2024-05-20-preview". </summary>
            V2024_05_20_Preview = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of TestReportingClientOptions. </summary>
        public TestReportingClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2024_05_20_Preview => "2024-05-20-preview",
                _ => throw new NotSupportedException()
            };
        }
    }
}
