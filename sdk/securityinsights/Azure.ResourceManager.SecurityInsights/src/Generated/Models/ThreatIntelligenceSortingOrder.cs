// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.SecurityInsights.Models
{
    /// <summary> Sorting order (ascending/descending/unsorted). </summary>
    public readonly partial struct ThreatIntelligenceSortingOrder : IEquatable<ThreatIntelligenceSortingOrder>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ThreatIntelligenceSortingOrder"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ThreatIntelligenceSortingOrder(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string UnsortedValue = "unsorted";
        private const string AscendingValue = "ascending";
        private const string DescendingValue = "descending";

        /// <summary> unsorted. </summary>
        public static ThreatIntelligenceSortingOrder Unsorted { get; } = new ThreatIntelligenceSortingOrder(UnsortedValue);
        /// <summary> ascending. </summary>
        public static ThreatIntelligenceSortingOrder Ascending { get; } = new ThreatIntelligenceSortingOrder(AscendingValue);
        /// <summary> descending. </summary>
        public static ThreatIntelligenceSortingOrder Descending { get; } = new ThreatIntelligenceSortingOrder(DescendingValue);
        /// <summary> Determines if two <see cref="ThreatIntelligenceSortingOrder"/> values are the same. </summary>
        public static bool operator ==(ThreatIntelligenceSortingOrder left, ThreatIntelligenceSortingOrder right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ThreatIntelligenceSortingOrder"/> values are not the same. </summary>
        public static bool operator !=(ThreatIntelligenceSortingOrder left, ThreatIntelligenceSortingOrder right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="ThreatIntelligenceSortingOrder"/>. </summary>
        public static implicit operator ThreatIntelligenceSortingOrder(string value) => new ThreatIntelligenceSortingOrder(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ThreatIntelligenceSortingOrder other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ThreatIntelligenceSortingOrder other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
