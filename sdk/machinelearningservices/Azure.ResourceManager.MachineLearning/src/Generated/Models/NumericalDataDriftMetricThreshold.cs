// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> The NumericalDataDriftMetricThreshold. </summary>
    public partial class NumericalDataDriftMetricThreshold : DataDriftMetricThresholdBase
    {
        /// <summary> Initializes a new instance of <see cref="NumericalDataDriftMetricThreshold"/>. </summary>
        /// <param name="metric"> [Required] The numerical data drift metric to calculate. </param>
        public NumericalDataDriftMetricThreshold(NumericalDataDriftMetric metric)
        {
            Metric = metric;
            DataType = MonitoringFeatureDataType.Numerical;
        }

        /// <summary> Initializes a new instance of <see cref="NumericalDataDriftMetricThreshold"/>. </summary>
        /// <param name="dataType"> [Required] Specifies the data type of the metric threshold. </param>
        /// <param name="threshold"> The threshold value. If null, a default value will be set depending on the selected metric. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="metric"> [Required] The numerical data drift metric to calculate. </param>
        internal NumericalDataDriftMetricThreshold(MonitoringFeatureDataType dataType, MonitoringThreshold threshold, IDictionary<string, BinaryData> serializedAdditionalRawData, NumericalDataDriftMetric metric) : base(dataType, threshold, serializedAdditionalRawData)
        {
            Metric = metric;
            DataType = dataType;
        }

        /// <summary> Initializes a new instance of <see cref="NumericalDataDriftMetricThreshold"/> for deserialization. </summary>
        internal NumericalDataDriftMetricThreshold()
        {
        }

        /// <summary> [Required] The numerical data drift metric to calculate. </summary>
        [WirePath("metric")]
        public NumericalDataDriftMetric Metric { get; set; }
    }
}
