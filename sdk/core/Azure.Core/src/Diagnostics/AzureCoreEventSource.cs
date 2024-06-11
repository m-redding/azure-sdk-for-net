// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Azure.Core.Diagnostics
{
    [EventSource(Name = EventSourceName)]
    internal sealed class AzureCoreEventSource : AzureEventSource
    {
        private const string EventSourceName = "Azure-Core-ext";

        private const int BackgroundRefreshFailedEvent = 19;
        private const int RequestRedirectEvent = 20;
        private const int RequestRedirectBlockedEvent = 21;
        private const int RequestRedirectCountExceededEvent = 22;
        private const int PipelineTransportOptionsNotAppliedEvent = 23;

        private AzureCoreEventSource() : base(EventSourceName) { }

        public static AzureCoreEventSource Singleton { get; } = new AzureCoreEventSource();

        [Event(BackgroundRefreshFailedEvent, Level = EventLevel.Informational, Message = "Background token refresh [{0}] failed with exception {1}")]
        public void BackgroundRefreshFailed(string requestId, string exception)
        {
            WriteEvent(BackgroundRefreshFailedEvent, requestId, exception);
        }

        [NonEvent]
        public void RequestRedirect(Request request, Uri redirectUri, Response response)
        {
            if (IsEnabled(EventLevel.Verbose, EventKeywords.None))
            {
                RequestRedirect(request.ClientRequestId, request.Uri.ToString(), redirectUri.ToString(), response.Status);
            }
        }

        [Event(RequestRedirectEvent, Level = EventLevel.Verbose, Message = "Request [{0}] Redirecting from {1} to {2} in response to status code {3}")]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "WriteEvent is used with primitive types.")]
        public void RequestRedirect(string requestId, string from, string to, int status)
        {
            WriteEvent(RequestRedirectEvent, requestId, from, to, status);
        }

        [Event(RequestRedirectBlockedEvent, Level = EventLevel.Warning, Message = "Request [{0}] Insecure HTTPS to HTTP redirect from {1} to {2} was blocked.")]
        public void RequestRedirectBlocked(string requestId, string from, string to)
        {
            WriteEvent(RequestRedirectBlockedEvent, requestId, from, to);
        }

        [Event(RequestRedirectCountExceededEvent, Level = EventLevel.Warning, Message = "Request [{0}] Exceeded max number of redirects. Redirect from {1} to {2} blocked.")]
        public void RequestRedirectCountExceeded(string requestId, string from, string to)
        {
            WriteEvent(RequestRedirectCountExceededEvent, requestId, from, to);
        }

        [NonEvent]
        public void PipelineTransportOptionsNotApplied(Type optionsType)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                PipelineTransportOptionsNotApplied(optionsType.FullName ?? string.Empty);
            }
        }

        [Event(PipelineTransportOptionsNotAppliedEvent, Level = EventLevel.Informational, Message = "The client requires transport configuration but it was not applied because custom transport was provided. Type: {0}")]
        public void PipelineTransportOptionsNotApplied(string optionsType)
        {
            WriteEvent(PipelineTransportOptionsNotAppliedEvent, optionsType);
        }

        [NonEvent]
        private static string FormatHeaders(IEnumerable<HttpHeader> headers, HttpMessageSanitizer sanitizer)
        {
            var stringBuilder = new StringBuilder();
            foreach (HttpHeader header in headers)
            {
                stringBuilder.Append(header.Name);
                stringBuilder.Append(':');
                stringBuilder.Append(sanitizer.SanitizeHeader(header.Name, header.Value));
                stringBuilder.Append(Environment.NewLine);
            }
            return stringBuilder.ToString();
        }
    }
}
