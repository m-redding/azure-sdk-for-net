// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework.Shared.Utilities
{
    /// <summary>
    /// Extension methods for working with Task and ValueTask in test scenarios.
    /// Provides timeout functionality and reflection-based task utilities.
    /// </summary>
    public static class TaskExtensions
    {
        /// <summary>
        /// Default timeout for test operations.
        /// </summary>
        public static TimeSpan DefaultTimeout { get; } = TimeSpan.FromSeconds(10);

        /// <summary>
        /// Applies the default timeout to a task.
        /// </summary>
        public static Task<T> TimeoutAfterDefault<T>(this Task<T> task,
            [CallerFilePath] string? filePath = null,
            [CallerLineNumber] int lineNumber = default)
        {
            return task.TimeoutAfter(DefaultTimeout, filePath, lineNumber);
        }

        /// <summary>
        /// Applies the default timeout to a task.
        /// </summary>
        public static Task TimeoutAfterDefault(this Task task,
            [CallerFilePath] string? filePath = null,
            [CallerLineNumber] int lineNumber = default)
        {
            return task.TimeoutAfter(DefaultTimeout, filePath, lineNumber);
        }

        /// <summary>
        /// Applies the default timeout to a value task.
        /// </summary>
        public static ValueTask<T> TimeoutAfterDefault<T>(this ValueTask<T> task,
            [CallerFilePath] string? filePath = null,
            [CallerLineNumber] int lineNumber = default)
        {
            return task.TimeoutAfter(DefaultTimeout, filePath, lineNumber);
        }

        /// <summary>
        /// Applies the default timeout to a value task.
        /// </summary>
        public static ValueTask TimeoutAfterDefault(this ValueTask task,
            [CallerFilePath] string? filePath = null,
            [CallerLineNumber] int lineNumber = default)
        {
            return task.TimeoutAfter(DefaultTimeout, filePath, lineNumber);
        }

        /// <summary>
        /// Adds a timeout to a task with optional file path and line number for better error messages.
        /// </summary>
        public static async Task<T> TimeoutAfter<T>(this Task<T> task, TimeSpan timeout,
            [CallerFilePath] string? filePath = null,
            [CallerLineNumber] int lineNumber = default)
        {
            // Don't create a timer if the task is already completed
            // or the debugger is attached
            if (task.IsCompleted || Debugger.IsAttached)
            {
                return await task;
            }

            var cts = new CancellationTokenSource();
            if (task == await Task.WhenAny(task, Task.Delay(timeout, cts.Token)))
            {
                cts.Cancel();
                return await task;
            }
            else
            {
                throw new TimeoutException(CreateMessage(timeout, filePath, lineNumber));
            }
        }

        /// <summary>
        /// Adds a timeout to a task with optional file path and line number for better error messages.
        /// </summary>
        public static async Task TimeoutAfter(this Task task, TimeSpan timeout,
            [CallerFilePath] string? filePath = null,
            [CallerLineNumber] int lineNumber = default)
        {
            // Don't create a timer if the task is already completed
            // or the debugger is attached
            if (task.IsCompleted || Debugger.IsAttached)
            {
                await task;
                return;
            }

            var cts = new CancellationTokenSource();
            if (task == await Task.WhenAny(task, Task.Delay(timeout, cts.Token)))
            {
                cts.Cancel();
                await task;
            }
            else
            {
                throw new TimeoutException(CreateMessage(timeout, filePath, lineNumber));
            }
        }

        /// <summary>
        /// Adds a timeout to a value task with optional file path and line number for better error messages.
        /// </summary>
        public static ValueTask<T> TimeoutAfter<T>(this ValueTask<T> task, TimeSpan timeout,
            [CallerFilePath] string? filePath = null,
            [CallerLineNumber] int lineNumber = default)
        {
            return new(TimeoutAfter(task.AsTask(), timeout, filePath, lineNumber));
        }

        /// <summary>
        /// Adds a timeout to a value task with optional file path and line number for better error messages.
        /// </summary>
        public static ValueTask TimeoutAfter(this ValueTask task, TimeSpan timeout,
            [CallerFilePath] string? filePath = null,
            [CallerLineNumber] int lineNumber = default)
        {
            return new(TimeoutAfter(task.AsTask(), timeout, filePath, lineNumber));
        }

        private static string CreateMessage(TimeSpan timeout, string? filePath, int lineNumber)
            => string.IsNullOrEmpty(filePath)
                ? $"The operation timed out after reaching the limit of {timeout.TotalMilliseconds}ms."
                : $"The operation at {filePath}:{lineNumber} timed out after reaching the limit of {timeout.TotalMilliseconds}ms.";

        /// <summary>
        /// Determines if a task object is in a faulted state using reflection.
        /// </summary>
        public static bool IsTaskFaulted(object taskObj)
        {
            return (bool)taskObj.GetType().GetProperty("IsFaulted")!.GetValue(taskObj)!;
        }

        /// <summary>
        /// Gets the result from a task object using reflection.
        /// </summary>
        public static object GetResultFromTask(object returnValue)
        {
            try
            {
                Type returnType = returnValue.GetType();
                return IsTaskType(returnType)
                    ? returnType.GetProperty("Result")!.GetValue(returnValue)!
                    : returnValue;
            }
            catch (TargetInvocationException e)
            {
                if (e.InnerException is AggregateException aggException)
                {
                    throw aggException.InnerExceptions.First();
                }
                else
                {
                    throw e.InnerException!;
                }
            }
        }

        /// <summary>
        /// Determines if a type represents a Task or ValueTask.
        /// </summary>
        public static bool IsTaskType(Type type)
        {
            string name = type.Name;
            return name.StartsWith("ValueTask", StringComparison.Ordinal) ||
                   name.StartsWith("Task", StringComparison.Ordinal) ||
                   name.StartsWith("AsyncStateMachineBox", StringComparison.Ordinal); //in .net 5 the type is not task here
        }

        /// <summary>
        /// Creates a Task.FromResult using reflection for the specified type and value.
        /// </summary>
        public static object GetValueFromTask(Type taskResultType, object instrumentedResult)
        {
            var method = typeof(Task).GetMethod("FromResult", BindingFlags.Public | BindingFlags.Static);
            var genericMethod = method!.MakeGenericMethod(taskResultType);
            return genericMethod.Invoke(null, new object[] { instrumentedResult })!;
        }
    }
}