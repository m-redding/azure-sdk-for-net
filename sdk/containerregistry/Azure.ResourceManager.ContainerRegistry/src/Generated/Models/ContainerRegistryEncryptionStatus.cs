// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ContainerRegistry.Models
{
    /// <summary> Indicates whether or not the encryption is enabled for container registry. </summary>
    public readonly partial struct ContainerRegistryEncryptionStatus : IEquatable<ContainerRegistryEncryptionStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ContainerRegistryEncryptionStatus"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ContainerRegistryEncryptionStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string EnabledValue = "enabled";
        private const string DisabledValue = "disabled";

        /// <summary> enabled. </summary>
        public static ContainerRegistryEncryptionStatus Enabled { get; } = new ContainerRegistryEncryptionStatus(EnabledValue);
        /// <summary> disabled. </summary>
        public static ContainerRegistryEncryptionStatus Disabled { get; } = new ContainerRegistryEncryptionStatus(DisabledValue);
        /// <summary> Determines if two <see cref="ContainerRegistryEncryptionStatus"/> values are the same. </summary>
        public static bool operator ==(ContainerRegistryEncryptionStatus left, ContainerRegistryEncryptionStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ContainerRegistryEncryptionStatus"/> values are not the same. </summary>
        public static bool operator !=(ContainerRegistryEncryptionStatus left, ContainerRegistryEncryptionStatus right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="ContainerRegistryEncryptionStatus"/>. </summary>
        public static implicit operator ContainerRegistryEncryptionStatus(string value) => new ContainerRegistryEncryptionStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ContainerRegistryEncryptionStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ContainerRegistryEncryptionStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
