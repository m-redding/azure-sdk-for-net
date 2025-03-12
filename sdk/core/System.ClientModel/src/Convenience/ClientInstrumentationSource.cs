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
    /// TODO.
    /// </summary>
    /// <param name="clientFullName"></param>
    /// <param name="enableDistributedTracing"></param>
    /// <param name="isStable"></param>
    public ClientInstrumentationSource(string clientFullName, bool enableDistributedTracing = true, bool isStable = false)
    {
        _activitySourceName = isStable ? clientFullName : $"Experimental.{clientFullName}";
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="kind"></param>
    /// <param name="context"></param>
    /// <param name="tags"></param>
    /// <returns></returns>
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
