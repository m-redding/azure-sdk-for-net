// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core.GeoJson;
using Azure.Maps.Common;

namespace Azure.Maps.Weather.Models
{
    /// <summary> Displayed when details=true or radiiGeometry=true in the request. </summary>
    public partial class StormWindRadiiSummary
    {
        /// <summary> Initializes a new instance of <see cref="StormWindRadiiSummary"/>. </summary>
        internal StormWindRadiiSummary()
        {
            RadiusSectorData = new ChangeTrackingList<RadiusSector>();
        }

        /// <summary> DateTime for which the wind radii summary data is valid, displayed in ISO8601 format. </summary>
        public string Timestamp { get; }
        /// <summary> Wind speed associated with the radiusSectorData. </summary>
        public WeatherValue WindSpeed { get; }
        /// <summary> Contains the information needed to plot wind radius quadrants. Bearing 0–90 = NE quadrant; 90–180 = SE quadrant; 180–270 = SW quadrant; 270–360 = NW quadrant. </summary>
        public IReadOnlyList<RadiusSector> RadiusSectorData { get; }
    }
}
