// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs.Tests;
using Microsoft.ApplicationInsights;

namespace Azure.Messaging.EventHubs.Stress;

/// <summary>
///   The role responsible for running a <see cref="EventHubProducerClient" \>, and testing its performance over
///   a long period of time. It collects metrics about the run and sends them to application insights using a
///   <see cref="TelemetryClient" \>. The metrics collected are garbage collection information, any exceptions
///   thrown or heard, and how many events are published. It stops sending events and cleans up resources
///   at the end of the test run.
/// </summary>
///
internal class PartitionPublisher
{
    /// <summary>The <see cref="Metrics" /> instance associated with this <see cref="PartitionPublisher" /> instance.</summary>
    private readonly Metrics _metrics;

    /// <summary>The <see cref="TestParameters" /> used to run this scenario.</summary>
    private readonly TestParameters _testParameters;

    /// <summary>The <see cref="PartitionPublisherConfiguration" /> used to configure the instance of this role.</summary>
    private readonly PartitionPublisherConfiguration _publisherconfiguration;

    /// <summary>The list of partitions that this publisher should publish to.</summary>
    private readonly List<string> _assignedPartitions;

    /// <summary>A dictionary mapping the partitionId to the last sent index number to that partition</summary>
    private ConcurrentDictionary<string, int> _lastSentPerPartition;

    /// <summary>The seed to use for initializing random number generated for a given thread-specific instance.</summary>
    private static int s_randomSeed = Environment.TickCount;

    /// <summary>The random number generator to use for a specific thread.</summary>
    private static readonly ThreadLocal<Random> RandomNumberGenerator = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref s_randomSeed)), false);

    /// <summary>
    ///   Initializes a new <see cref="PartitionPublisher" \> instance.
    /// </summary>
    ///
    /// <param name="testParameters">The <see cref="TestParameters" /> used to run the processor test scenario.</param>
    /// <param name="publisherConfiguration">The <see cref="PartitionPublisherConfiguration" /> instance used to configure this instance of <see cref="PartitionPublisher" />.</param>
    /// <param name="metrics">The <see cref="Metrics" /> instance used to send metrics to Application Insights.</param>
    /// <param name="assignedPartitions">The <see cref="List" /> of partition Id's that this publisher should send to.</param>
    ///
    public PartitionPublisher(PartitionPublisherConfiguration publisherConfiguration,
                              TestParameters testParameters,
                              Metrics metrics,
                              List<string> assignedPartitions)
    {
        _testParameters = testParameters;
        _publisherconfiguration = publisherConfiguration;
        _metrics = metrics;
        _assignedPartitions = assignedPartitions;
        _lastSentPerPartition = new ConcurrentDictionary<string, int>();
    }

    /// <summary>
    ///   Starts an instance of a <see cref="PartitionPublisher"/> role. This role creates an <see cref="EventHubProducerClient"/>
    ///   and monitors it while it sends events to the assigned partitions of this test's dedicated Event Hub.
    /// </summary>
    ///
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
    ///
    public async Task RunAsync(CancellationToken cancellationToken)
    {
        using var azureEventListener = new AzureEventSourceListener((args, level) => metrics.Client.TrackTrace($"EventWritten: {args.ToString()} Level: {level}."), EventLevel.Warning);
        var producersRunning = new List<Task>();

        while (!cancellationToken.IsCancellationRequested)
        {
            using var backgroundCancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

            foreach (var partition in _assignedPartitions)
            {
                Console.WriteLine($"Starting Publisher for {partition}.");
                producersRunning.Add(RunPartitionSpecificProducerAsync(partition, backgroundCancellationSource.Token));

                // Add a little delay between starting so that all the producers aren't sending at the exact same time every time

                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken).ConfigureAwait(false);
            }

            Console.WriteLine("All partition publishers started.");
            await Task.WhenAll(producersRunning).ConfigureAwait(false);
            Console.WriteLine("All partition publishers completed.");
        }
    }

    /// <summary>
    ///   Starts an instance of a <see cref="PartitionPublisher"/> role. This role creates an <see cref="EventHubProducerClient"/>
    ///   and monitors it while it sends events to the assigned partitions of this test's dedicated Event Hub.
    /// </summary>
    ///
    /// <param name="partitionId">The Id of the partition to send events to.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
    ///
    private async Task RunPartitionSpecificProducerAsync(string partitionId, CancellationToken cancellationToken)
    {
        int maxNumBreaks = RandomNumberGenerator.Value.Next(6, 24);

        while (!cancellationToken.IsCancellationRequested)
        {
            var options = new EventHubProducerClientOptions
            {
                RetryOptions = new EventHubsRetryOptions
                {
                    TryTimeout = _publisherconfiguration.SendTimeout
                }
            };
            var producer = new EventHubProducerClient(_testParameters.EventHubsConnectionString, _testParameters.EventHub, options);
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    using var invokeInactivityLinkedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                    if (_publisherconfiguration.IncludeInactivity && maxNumBreaks > 0)
                    {
                        int numMinutesActive = RandomNumberGenerator.Value.Next(15, 360);
                        Console.WriteLine($"Starting publishing for {numMinutesActive} minutes");
                        invokeInactivityLinkedCts.CancelAfter(TimeSpan.FromMinutes(numMinutesActive));
                        maxNumBreaks--;
                    }
                    while (!invokeInactivityLinkedCts.IsCancellationRequested)
                    {
                        // send
                        await PerformSend(producer, partitionId, cancellationToken).ConfigureAwait(false);
                        if (_publisherconfiguration.ProducerPublishingDelay.Value > TimeSpan.Zero)
                        {
                            await Task.Delay(_publisherconfiguration.ProducerPublishingDelay.Value, cancellationToken).ConfigureAwait(false);
                        }
                    }
                    if (_publisherconfiguration.IncludeInactivity)
                    {
                        if (cancellationToken.IsCancellationRequested)
                        {
                            break;
                        }
                        int numMinutesInactive = RandomNumberGenerator.Value.Next(15, 120);
                        Console.WriteLine($"Going inactive for {numMinutesInactive} minutes");
                        await Task.Delay(TimeSpan.FromMinutes(numMinutesInactive), cancellationToken).ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                _metrics.Client.GetMetric(Metrics.ProducerRestarted).TrackValue(1);
                _metrics.Client.TrackException(ex);
            }
            finally
            {
                await producer.CloseAsync(cancellationToken).ConfigureAwait(false);
            }
        }
    }

    /// <summary>
    ///   Performs the actual sends to the Event Hub for this particular test, using the <see cref="EventHubProducerClient" /> parameter.
    ///   This method generates events using the <see cref="PartitionPublisherConfiguration" />  configurations.
    /// </summary>
    ///
    /// <param name="producer">The <see cref="EventHubProducerClient" /> to send events to.</param>
    /// <param name="partitionId">The Id of the partition within the Event Hub to send events to.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
    ///
    private async Task PerformSend(EventHubProducerClient producer,
                                   string partitionId,
                                   CancellationToken cancellationToken)
    {
        // Create the batch and generate a set of random events, keeping only those that were able to fit into the batch.
        // Because there is a side-effect of TryAdd in the statement, ensure that ToList is called to materialize the set
        // or the batch will be empty at send.

        var batchOptions = new CreateBatchOptions
        {
            PartitionId = partitionId
        };

        using var batch = await producer.CreateBatchAsync(batchOptions).ConfigureAwait(false);

        //var observableBatch = new List<EventData>();

        var events = EventGenerator.CreateEvents(batch.MaximumSizeInBytes,
                                                 _publisherconfiguration.PublishBatchSize,
                                                 _publisherconfiguration.LargeMessageRandomFactorPercent,
                                                 _publisherconfiguration.PublishingBodyMinBytes,
                                                 _publisherconfiguration.PublishingBodyRegularMaxBytes);

        foreach (var currentEvent in events)
        {
            var currentIndexNumber = _lastSentPerPartition.AddOrUpdate(partitionId, -1, (k,v) => v + 1);
            EventTracking.AugmentEvent(currentEvent, _testParameters.Sha256Hash, currentIndexNumber, partitionId);

            if (!batch.TryAdd(currentEvent))
            {
                _lastSentPerPartition.AddOrUpdate(partitionId, -1, (k,v) => v--);
                break;
            }

            //observableBatch.Add(currentEvent);
        }
        Console.WriteLine($"Sent {events.Count()} events to partition {partitionId}.");

        // Publish the events and report them, capturing any failures specific to the send operation.

        try
        {
            if (batch.Count > 0)
            {
                _metrics.Client.GetMetric(Metrics.PublishAttempts).TrackValue(1);

                await producer.SendAsync(batch, cancellationToken).ConfigureAwait(false);
            }

            _metrics.Client.GetMetric(Metrics.EventsPublished).TrackValue(batch.Count);
            _metrics.Client.GetMetric(Metrics.BatchesPublished).TrackValue(1);
            _metrics.Client.GetMetric(Metrics.TotalPublishedSizeBytes).TrackValue(batch.SizeInBytes);
        }
        catch (TaskCanceledException)
        {
            _metrics.Client.GetMetric(Metrics.PublishAttempts).TrackValue(-1);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            var exceptionProperties = new Dictionary<String, String>();
            exceptionProperties.Add("Process", "Send");

            _metrics.Client.TrackException(ex, exceptionProperties);

            // foreach (var failedEvent in observableBatch)
            // {
            //     failedEvent.Properties.TryGetValue(EventTracking.IndexNumberPropertyName, out var failedIndexNumber);
            //     var eventProperties = new Dictionary<String, String>();
            //     eventProperties.Add(Metrics.PartitionId, partitionId);
            //     eventProperties.Add(Metrics.PublisherAssignedIndex, failedIndexNumber.ToString());

            //     _metrics.Client.TrackEvent(Metrics.EventsFailedToPublish, eventProperties);
            // }
        }
    }
}