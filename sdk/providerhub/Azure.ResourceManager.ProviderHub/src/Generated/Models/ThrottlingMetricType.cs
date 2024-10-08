// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ProviderHub.Models
{
    /// <summary> The ThrottlingMetricType. </summary>
    public readonly partial struct ThrottlingMetricType : IEquatable<ThrottlingMetricType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ThrottlingMetricType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ThrottlingMetricType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NotSpecifiedValue = "NotSpecified";
        private const string NumberOfRequestsValue = "NumberOfRequests";
        private const string NumberOfResourcesValue = "NumberOfResources";

        /// <summary> NotSpecified. </summary>
        public static ThrottlingMetricType NotSpecified { get; } = new ThrottlingMetricType(NotSpecifiedValue);
        /// <summary> NumberOfRequests. </summary>
        public static ThrottlingMetricType NumberOfRequests { get; } = new ThrottlingMetricType(NumberOfRequestsValue);
        /// <summary> NumberOfResources. </summary>
        public static ThrottlingMetricType NumberOfResources { get; } = new ThrottlingMetricType(NumberOfResourcesValue);
        /// <summary> Determines if two <see cref="ThrottlingMetricType"/> values are the same. </summary>
        public static bool operator ==(ThrottlingMetricType left, ThrottlingMetricType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ThrottlingMetricType"/> values are not the same. </summary>
        public static bool operator !=(ThrottlingMetricType left, ThrottlingMetricType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="ThrottlingMetricType"/>. </summary>
        public static implicit operator ThrottlingMetricType(string value) => new ThrottlingMetricType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ThrottlingMetricType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ThrottlingMetricType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
