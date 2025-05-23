// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    /// <summary>
    /// Resource status of the origin.
    /// Serialized Name: OriginResourceState
    /// </summary>
    public readonly partial struct OriginResourceState : IEquatable<OriginResourceState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="OriginResourceState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public OriginResourceState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string CreatingValue = "Creating";
        private const string ActiveValue = "Active";
        private const string DeletingValue = "Deleting";

        /// <summary>
        /// Creating
        /// Serialized Name: OriginResourceState.Creating
        /// </summary>
        public static OriginResourceState Creating { get; } = new OriginResourceState(CreatingValue);
        /// <summary>
        /// Active
        /// Serialized Name: OriginResourceState.Active
        /// </summary>
        public static OriginResourceState Active { get; } = new OriginResourceState(ActiveValue);
        /// <summary>
        /// Deleting
        /// Serialized Name: OriginResourceState.Deleting
        /// </summary>
        public static OriginResourceState Deleting { get; } = new OriginResourceState(DeletingValue);
        /// <summary> Determines if two <see cref="OriginResourceState"/> values are the same. </summary>
        public static bool operator ==(OriginResourceState left, OriginResourceState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="OriginResourceState"/> values are not the same. </summary>
        public static bool operator !=(OriginResourceState left, OriginResourceState right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="OriginResourceState"/>. </summary>
        public static implicit operator OriginResourceState(string value) => new OriginResourceState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is OriginResourceState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(OriginResourceState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
