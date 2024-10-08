// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Quantum.Models
{
    /// <summary> Provisioning status field. </summary>
    public readonly partial struct QuantumProvisioningStatus : IEquatable<QuantumProvisioningStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="QuantumProvisioningStatus"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public QuantumProvisioningStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string SucceededValue = "Succeeded";
        private const string ProviderLaunchingValue = "ProviderLaunching";
        private const string ProviderUpdatingValue = "ProviderUpdating";
        private const string ProviderDeletingValue = "ProviderDeleting";
        private const string ProviderProvisioningValue = "ProviderProvisioning";
        private const string FailedValue = "Failed";

        /// <summary> Succeeded. </summary>
        public static QuantumProvisioningStatus Succeeded { get; } = new QuantumProvisioningStatus(SucceededValue);
        /// <summary> ProviderLaunching. </summary>
        public static QuantumProvisioningStatus ProviderLaunching { get; } = new QuantumProvisioningStatus(ProviderLaunchingValue);
        /// <summary> ProviderUpdating. </summary>
        public static QuantumProvisioningStatus ProviderUpdating { get; } = new QuantumProvisioningStatus(ProviderUpdatingValue);
        /// <summary> ProviderDeleting. </summary>
        public static QuantumProvisioningStatus ProviderDeleting { get; } = new QuantumProvisioningStatus(ProviderDeletingValue);
        /// <summary> ProviderProvisioning. </summary>
        public static QuantumProvisioningStatus ProviderProvisioning { get; } = new QuantumProvisioningStatus(ProviderProvisioningValue);
        /// <summary> Failed. </summary>
        public static QuantumProvisioningStatus Failed { get; } = new QuantumProvisioningStatus(FailedValue);
        /// <summary> Determines if two <see cref="QuantumProvisioningStatus"/> values are the same. </summary>
        public static bool operator ==(QuantumProvisioningStatus left, QuantumProvisioningStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="QuantumProvisioningStatus"/> values are not the same. </summary>
        public static bool operator !=(QuantumProvisioningStatus left, QuantumProvisioningStatus right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="QuantumProvisioningStatus"/>. </summary>
        public static implicit operator QuantumProvisioningStatus(string value) => new QuantumProvisioningStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is QuantumProvisioningStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(QuantumProvisioningStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
