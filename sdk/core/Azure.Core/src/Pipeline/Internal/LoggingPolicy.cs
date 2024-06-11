// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;

namespace Azure.Core.Pipeline
{
    internal class LoggingPolicy : HttpPipelinePolicy
    {
        private readonly LoggingPolicyAdapter _clientModelPolicy;

        private static readonly string[] MainEventSourceTraits =
        {
            AzureEventSourceListener.TraitName,
            AzureEventSourceListener.TraitValue
        };

        public LoggingPolicy(bool isEnabled, bool logContent, int maxLength, string[] allowedHeaderNames, string[] allowedQueryParameters, string? assemblyName)
        {
            LoggingOptions loggingOptions = new()
            {
                LoggedContentSizeLimit = maxLength,
                IsLoggingContentEnabled = logContent,
                LoggedClientAssemblyName = assemblyName,
                RequestIdHeaderName = "x-ms-client-request-id",
                IsLoggingEnabled = isEnabled
            };

            // Don't use the client model sanitization defaults because:
            //   1. Azure.Core has its own defaults that are a superset and include Azure specific values
            //   2. Avoid adding back a value that is a shared default between Azure.Core
            //      and System.ClientModel. ex: "ETag" is in both defaults, if an Azure library
            //      removes that, we don't want to add it back here through System.ClientModel defaults.
            //   3. Also avoids duplicates.
            loggingOptions.AllowedHeaderNames.Clear();
            loggingOptions.AllowedQueryParameters.Clear();
            foreach (var header in allowedHeaderNames)
            {
                loggingOptions.AllowedHeaderNames.Add(header);
            }
            foreach (var query in allowedQueryParameters)
            {
                loggingOptions.AllowedQueryParameters.Add(query);
            }
            _clientModelPolicy = new LoggingPolicyAdapter(this, loggingOptions);
        }

        private static readonly AzureCoreEventSource s_eventSource = AzureCoreEventSource.Singleton;

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            => ProcessSyncOrAsync(message, pipeline, false).EnsureCompleted();

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            => await ProcessSyncOrAsync(message, pipeline, true).ConfigureAwait(false);

        private async ValueTask ProcessSyncOrAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            HttpPipelineAdapter httpPipeline = new(pipeline);
            if (async)
            {
                await _clientModelPolicy.ProcessAsync(message, httpPipeline, -1).ConfigureAwait(false);
            }
            else
            {
                _clientModelPolicy.Process(message, httpPipeline, -1);
            }
        }

        private sealed class LoggingPolicyAdapter : ClientLoggingPolicy
        {
            private readonly LoggingPolicy _azureCorePolicy;

            public LoggingPolicyAdapter(LoggingPolicy azureCorePolicy, LoggingOptions options) : base("Azure-Core", MainEventSourceTraits, options)
            {
                _azureCorePolicy = azureCorePolicy;
            }
        }
    }
}
