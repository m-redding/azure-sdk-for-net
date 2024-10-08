// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    /// <summary> Disk redundancy enum. </summary>
    public readonly partial struct CloudVmClusterDiskRedundancy : IEquatable<CloudVmClusterDiskRedundancy>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CloudVmClusterDiskRedundancy"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public CloudVmClusterDiskRedundancy(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string HighValue = "High";
        private const string NormalValue = "Normal";

        /// <summary> High redundancy. </summary>
        public static CloudVmClusterDiskRedundancy High { get; } = new CloudVmClusterDiskRedundancy(HighValue);
        /// <summary> Normal redundancy. </summary>
        public static CloudVmClusterDiskRedundancy Normal { get; } = new CloudVmClusterDiskRedundancy(NormalValue);
        /// <summary> Determines if two <see cref="CloudVmClusterDiskRedundancy"/> values are the same. </summary>
        public static bool operator ==(CloudVmClusterDiskRedundancy left, CloudVmClusterDiskRedundancy right) => left.Equals(right);
        /// <summary> Determines if two <see cref="CloudVmClusterDiskRedundancy"/> values are not the same. </summary>
        public static bool operator !=(CloudVmClusterDiskRedundancy left, CloudVmClusterDiskRedundancy right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="CloudVmClusterDiskRedundancy"/>. </summary>
        public static implicit operator CloudVmClusterDiskRedundancy(string value) => new CloudVmClusterDiskRedundancy(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CloudVmClusterDiskRedundancy other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CloudVmClusterDiskRedundancy other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
