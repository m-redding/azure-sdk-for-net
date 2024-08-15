// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO;
using System.Runtime.InteropServices;
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

        public LoggingPolicy(bool logContent, int maxLength, string[] allowedHeaderNames, string[] allowedQueryParameters, string? assemblyName)
        {
            LoggingOptions loggingOptions = new()
            {
                LoggedContentSizeLimit = maxLength,
                IsLoggingContentEnabled = logContent,
                CorrelationIdHeaderName = "x-ms-client-request-id"
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
            _clientModelPolicy = new LoggingPolicyAdapter(this, assemblyName ?? "Azure.Core", new HttpMessageSanitizer(allowedQueryParameters, allowedHeaderNames), loggingOptions);
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            => ProcessSyncOrAsync(message, pipeline, false).EnsureCompleted();

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            => await ProcessSyncOrAsync(message, pipeline, true).ConfigureAwait(false);

        private async ValueTask ProcessSyncOrAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            try
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
            catch (Exception ex)
            {
                AzureCoreEventSource.Singleton.ExceptionResponse(message.Request.ClientRequestId, ex.ToString());
                throw;
            }
        }

        private sealed class LoggingPolicyAdapter : ClientLoggingPolicy
        {
            private readonly LoggingPolicy _azureCorePolicy;
            private readonly string _assembly;
            private readonly HttpMessageSanitizer _sanitizer;
            private readonly LoggingOptions _options;

            public LoggingPolicyAdapter(LoggingPolicy azureCorePolicy, string assembly, HttpMessageSanitizer sanitizer, LoggingOptions options) : base(assembly, true, options)
            {
                _azureCorePolicy = azureCorePolicy;
                _assembly = assembly;
                _sanitizer = sanitizer;
                _options = options;
            }

            protected override void OnSendingRequest(PipelineMessage message, byte[]? bytes, Encoding? encoding)
                => LogRequest(message, bytes, encoding);

            protected override async ValueTask OnSendingRequestAsync(PipelineMessage message, byte[]? bytes, Encoding? encoding)
            {
                LogRequest(message, bytes, encoding);
                await Task.Yield();
            }

            private void LogRequest(PipelineMessage message, byte[]? bytes, Encoding? encoding)
            {
                AzureCoreEventSource.Singleton.Request(message.Request, _assembly, _sanitizer);

                if (bytes != null)
                {
                    AzureCoreEventSource.Singleton.RequestContent(message.Request, bytes, encoding);
                }
            }

            protected override void OnLogResponse(PipelineMessage message, double secondsElapsed)
                => LogResponse(message, secondsElapsed);

            protected override async ValueTask OnLogResponseAsync(PipelineMessage message, double secondsElapsed)
            {
                LogResponse(message, secondsElapsed);
                await Task.Yield();
            }

            private void LogResponse(PipelineMessage message, double secondsElapsed)
            {
                PipelineResponse? response = message.Response;
                if (response == null)
                {
                    return;
                }
                if (response.IsError)
                {
                    AzureCoreEventSource.Singleton.ErrorResponse(response, _sanitizer, secondsElapsed);
                }
                else
                {
                    AzureCoreEventSource.Singleton.Response(response, _sanitizer, secondsElapsed);
                }
            }

            protected override void OnLogResponseContent(PipelineMessage message, byte[] bytes, Encoding? textEncoding, int? block)
                => LogResponseContent(message, bytes, textEncoding, block);

            protected override async ValueTask OnLogResponseContentAsync(PipelineMessage message, byte[] bytes, Encoding? textEncoding, int? block)
            {
                LogResponseContent(message, bytes, textEncoding, block);
                await Task.Yield();
            }

            private void LogResponseContent(PipelineMessage message, byte[] bytes, Encoding? textEncoding, int? block)
            {
                PipelineResponse? response = message.Response;
                if (response == null)
                {
                    return;
                }

                switch (response.IsError, block)
                {
                    case (true, null):
                        AzureCoreEventSource.Singleton.ErrorResponseContent(response, bytes, textEncoding);
                        break;
                    case (true, _):
                        AzureCoreEventSource.Singleton.ErrorResponseContentBlock(response, block.Value, bytes, textEncoding);
                        break;
                    case (false, null):
                        AzureCoreEventSource.Singleton.ResponseContent(response, bytes, textEncoding);
                        break;
                    case (false, _):
                        AzureCoreEventSource.Singleton.ResponseContentBlock(response, block.Value, bytes, textEncoding);
                        break;
                }
            }
        }
    }
}
