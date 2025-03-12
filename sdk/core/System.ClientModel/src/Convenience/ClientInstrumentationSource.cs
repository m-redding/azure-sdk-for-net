// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace System.ClientModel.Primitives;

/// <summary>
/// A common abstraction for instrumenting client libraries with
/// Open Telemetry distributed tracing using <see cref="System.Diagnostics.Activity"/>
/// and <see cref="System.Diagnostics.ActivitySource"/>.
/// </summary>
public class ClientInstrumentationSource
{
    private readonly string _telemetryName;

    // Tracing
    private static ConcurrentDictionary<string, ActivitySource> _activitySources = new();

    // Metrics
    private readonly string _durationMetricName;
    private static ConcurrentDictionary<string, Meter> _meters = new();
    private readonly ConcurrentDictionary<string, Histogram<double>> _durationCounters = new();

    /// <summary>
    /// Creates an instance of <see cref="ClientInstrumentationSource"/>.
    /// </summary>
    /// <param name="clientFullName">The full name of the client, including the namespace.</param>
    /// <param name="enableDistributedTracing">Whether distributed tracing is enabled in the client.</param>
    /// <param name="isStable">If the Open Telemetry distributed tracing is stable in the client.</param>
    public ClientInstrumentationSource(string clientFullName, bool enableDistributedTracing = true, bool isStable = false)
    {
        _telemetryName = isStable ? clientFullName : $"Experimental.{clientFullName}";
        _durationMetricName = $"{_telemetryName.ToLower()}.duration";
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
        // Tracing
        _activitySources.TryGetValue(_telemetryName, out var activitySource);
        if (activitySource == null)
        {
            activitySource = new ActivitySource(_telemetryName);
            _activitySources.TryAdd(_telemetryName, activitySource);
        }

        // Metrics
        _durationCounters.TryGetValue(_durationMetricName, out var durationCounter);
        if (durationCounter == null)
        {
            _meters.TryGetValue(_telemetryName, out var meter);
            if (meter == null)
            {
                meter = new Meter(_telemetryName);
                _meters.TryAdd(_telemetryName, meter);
            }
            durationCounter = meter.CreateHistogram<double>(_durationMetricName);
            _durationCounters.TryAdd(_durationMetricName, durationCounter);
        }

        ClientInstrumentationScope scope = new(activitySource, durationCounter, name, kind, context, tags);
        scope.Start();

        return scope;
    }
}
