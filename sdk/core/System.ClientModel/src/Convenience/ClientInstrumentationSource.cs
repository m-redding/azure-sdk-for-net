// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;

namespace System.ClientModel.Primitives;

/// <summary>
/// A common abstraction for instrumenting client libraries with
/// Open Telemetry distributed tracing using <see cref="System.Diagnostics.Activity"/>
/// and <see cref="System.Diagnostics.ActivitySource"/>.
/// </summary>
public class ClientInstrumentationSource
{
    private readonly string _activitySourceName;
    private static ConcurrentDictionary<string, ActivitySource> _activitySources = new();

    /// <summary>
    /// Creates an instance of <see cref="ClientInstrumentationSource"/>.
    /// </summary>
    /// <param name="clientFullName">The full name of the client, including the namespace.</param>
    /// <param name="enableDistributedTracing">Whether distributed tracing is enabled in the client.</param>
    /// <param name="isStable">If the Open Telemetry distributed tracing is stable in the client.</param>
    public ClientInstrumentationSource(string clientFullName, bool enableDistributedTracing = true, bool isStable = false)
    {
        _activitySourceName = isStable ? clientFullName : $"Experimental.{clientFullName}";
    }

    /// <summary>
    /// Creates an instance of <see cref="ClientInstrumentationScope"/> and starts it.
    /// </summary>
    /// <param name="name">The name to use for the scope, this will be used when creating the <see cref="Activity"/>.</param>
    /// <param name="kind">The <see cref="ActivityKind"/> to use for the scope, this will be used when creating the <see cref="Activity"/></param>
    /// <param name="context">The <see cref="ActivityContext"/> to use for the scope, this will be used when creating the <see cref="Activity"/>.</param>
    /// <param name="tags">The tags to use for the scope, this will be used when creating the <see cref="Activity"/>.</param>
    public ClientInstrumentationScope? CreateAndStartScope(string name, ActivityKind kind = ActivityKind.Internal, ActivityContext context = default, IEnumerable<KeyValuePair<string, object?>>? tags = null)
    {
        _activitySources.TryGetValue(_activitySourceName, out var activitySource);
        if (activitySource == null)
        {
            activitySource = new ActivitySource(_activitySourceName);
            _activitySources.TryAdd(_activitySourceName, activitySource);
        }

        return new ClientInstrumentationScope(activitySource, name, kind, context, tags);
    }
}
