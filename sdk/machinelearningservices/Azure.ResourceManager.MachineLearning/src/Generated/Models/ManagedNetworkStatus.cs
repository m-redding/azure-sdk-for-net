// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> Status for the managed network of a machine learning workspace. </summary>
    public readonly partial struct ManagedNetworkStatus : IEquatable<ManagedNetworkStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ManagedNetworkStatus"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ManagedNetworkStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string InactiveValue = "Inactive";
        private const string ActiveValue = "Active";

        /// <summary> Inactive. </summary>
        public static ManagedNetworkStatus Inactive { get; } = new ManagedNetworkStatus(InactiveValue);
        /// <summary> Active. </summary>
        public static ManagedNetworkStatus Active { get; } = new ManagedNetworkStatus(ActiveValue);
        /// <summary> Determines if two <see cref="ManagedNetworkStatus"/> values are the same. </summary>
        public static bool operator ==(ManagedNetworkStatus left, ManagedNetworkStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ManagedNetworkStatus"/> values are not the same. </summary>
        public static bool operator !=(ManagedNetworkStatus left, ManagedNetworkStatus right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="ManagedNetworkStatus"/>. </summary>
        public static implicit operator ManagedNetworkStatus(string value) => new ManagedNetworkStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ManagedNetworkStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ManagedNetworkStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
