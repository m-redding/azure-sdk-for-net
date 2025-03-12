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
    /// TODO.
    /// </summary>
    /// <param name="clientFullName"></param>
    /// <param name="enableDistributedTracing"></param>
    /// <param name="isStable"></param>
    public ClientInstrumentationSource(string clientFullName, bool enableDistributedTracing = true, bool isStable = false)
    {
        _telemetryName = isStable ? clientFullName : $"Experimental.{clientFullName}";
        _durationMetricName = $"{_telemetryName.ToLower()}.duration";
    }

    /// <summary>
    /// Creates a <see cref="ClientInstrumentationScope"/> and starts it.
    /// </summary>
    /// <param name="name">The name of the scope, this will be used as the name of the created <see cref="Activity"/>./></param>
    /// <param name="kind">The <see cref="ActivityKind"/> for the scope, this will be used for the created <see cref="Activity"/>.</param>
    /// <param name="context">The <see cref="ActivityContext"/> to use for the scope, this will be used for the created <see cref="Activity"/>.</param>
    /// <param name="tags">The tags to use when creating and starting the <see cref="Activity"/>.</param>
    /// <returns></returns>
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
