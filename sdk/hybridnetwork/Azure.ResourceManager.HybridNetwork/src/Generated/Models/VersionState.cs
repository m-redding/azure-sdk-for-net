// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.HybridNetwork.Models
{
    /// <summary> The configuration group schema state. </summary>
    public readonly partial struct VersionState : IEquatable<VersionState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="VersionState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public VersionState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string UnknownValue = "Unknown";
        private const string PreviewValue = "Preview";
        private const string ActiveValue = "Active";
        private const string DeprecatedValue = "Deprecated";
        private const string ValidatingValue = "Validating";
        private const string ValidationFailedValue = "ValidationFailed";

        /// <summary> Unknown. </summary>
        public static VersionState Unknown { get; } = new VersionState(UnknownValue);
        /// <summary> Preview. </summary>
        public static VersionState Preview { get; } = new VersionState(PreviewValue);
        /// <summary> Active. </summary>
        public static VersionState Active { get; } = new VersionState(ActiveValue);
        /// <summary> Deprecated. </summary>
        public static VersionState Deprecated { get; } = new VersionState(DeprecatedValue);
        /// <summary> Validating. </summary>
        public static VersionState Validating { get; } = new VersionState(ValidatingValue);
        /// <summary> ValidationFailed. </summary>
        public static VersionState ValidationFailed { get; } = new VersionState(ValidationFailedValue);
        /// <summary> Determines if two <see cref="VersionState"/> values are the same. </summary>
        public static bool operator ==(VersionState left, VersionState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="VersionState"/> values are not the same. </summary>
        public static bool operator !=(VersionState left, VersionState right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="VersionState"/>. </summary>
        public static implicit operator VersionState(string value) => new VersionState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is VersionState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(VersionState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
