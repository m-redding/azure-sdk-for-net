// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Relay.Models
{
    /// <summary> The tier of this SKU. </summary>
    public readonly partial struct RelaySkuTier : IEquatable<RelaySkuTier>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RelaySkuTier"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RelaySkuTier(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string StandardValue = "Standard";

        /// <summary> Standard. </summary>
        public static RelaySkuTier Standard { get; } = new RelaySkuTier(StandardValue);
        /// <summary> Determines if two <see cref="RelaySkuTier"/> values are the same. </summary>
        public static bool operator ==(RelaySkuTier left, RelaySkuTier right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RelaySkuTier"/> values are not the same. </summary>
        public static bool operator !=(RelaySkuTier left, RelaySkuTier right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="RelaySkuTier"/>. </summary>
        public static implicit operator RelaySkuTier(string value) => new RelaySkuTier(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RelaySkuTier other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RelaySkuTier other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
