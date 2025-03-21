// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace System.ClientModel.Primitives;

/// <summary>
/// A common abstraction for instrumenting client libraries with
/// Open Telemetry distributed tracing using <see cref="System.Diagnostics.Activity"/>
/// and <see cref="System.Diagnostics.ActivitySource"/>.
/// </summary>
public class ClientInstrumentationScope : IDisposable
{
    private const string ScmScopeLabel = "scm.sdk.scope";
    private static readonly object ScmScopeValue = bool.TrueString;

    private readonly ActivitySource _activitySource;
    private readonly string _name;
    private readonly ActivityKind _kind;
    private readonly ActivityContext _context;
    private readonly IEnumerable<KeyValuePair<string, object?>>? _tags;

    private Activity? _activity;
    private Activity? _sampledOutActivity;

    internal ClientInstrumentationScope(ActivitySource activitySource, string name, ActivityKind kind, ActivityContext context, IEnumerable<KeyValuePair<string, object?>>? tags)
    {
        _activitySource = activitySource;
        _name = name;
        _kind = kind;
        _context = context;
        _tags = tags;
    }

    internal void Start()
    {
        // If this is an inner span (e.g. a protocol method), suppress it
        bool isInnerSpan = ScmScopeValue.Equals(Activity.Current?.GetCustomProperty(ScmScopeLabel));
        if (isInnerSpan)
        {
            return;
        }

        Activity? activity = _activitySource.StartActivity(_name, _kind, _context, _tags);

        // If IsAllDataRequested is false, this activity is sampled out
        if (activity?.IsAllDataRequested == true)
        {
            activity.SetCustomProperty(ScmScopeLabel, ScmScopeValue);
            _activity = activity;
        }
        else
        {
            _sampledOutActivity = activity;
        }
    }

    /// <summary>
    /// Marks the scope as failed.
    /// </summary>
    /// <param name="exception"></param>
    public void Failed(Exception exception)
    {
        _activity?.SetStatus(ActivityStatusCode.Error, exception.ToString());
    }

    /// <summary>
    /// If this scope has been started, stops it.
    /// </summary>
    public void Dispose()
    {
        _activity?.Dispose();
        _sampledOutActivity?.Dispose();
        _activity = null;
        _sampledOutActivity = null;
    }
}
