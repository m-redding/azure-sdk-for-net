// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Quantum.Models
{
    /// <summary> Provisioning status field. </summary>
    public readonly partial struct ProviderProvisioningStatus : IEquatable<ProviderProvisioningStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ProviderProvisioningStatus"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ProviderProvisioningStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string SucceededValue = "Succeeded";
        private const string LaunchingValue = "Launching";
        private const string UpdatingValue = "Updating";
        private const string DeletingValue = "Deleting";
        private const string DeletedValue = "Deleted";
        private const string FailedValue = "Failed";

        /// <summary> Succeeded. </summary>
        public static ProviderProvisioningStatus Succeeded { get; } = new ProviderProvisioningStatus(SucceededValue);
        /// <summary> Launching. </summary>
        public static ProviderProvisioningStatus Launching { get; } = new ProviderProvisioningStatus(LaunchingValue);
        /// <summary> Updating. </summary>
        public static ProviderProvisioningStatus Updating { get; } = new ProviderProvisioningStatus(UpdatingValue);
        /// <summary> Deleting. </summary>
        public static ProviderProvisioningStatus Deleting { get; } = new ProviderProvisioningStatus(DeletingValue);
        /// <summary> Deleted. </summary>
        public static ProviderProvisioningStatus Deleted { get; } = new ProviderProvisioningStatus(DeletedValue);
        /// <summary> Failed. </summary>
        public static ProviderProvisioningStatus Failed { get; } = new ProviderProvisioningStatus(FailedValue);
        /// <summary> Determines if two <see cref="ProviderProvisioningStatus"/> values are the same. </summary>
        public static bool operator ==(ProviderProvisioningStatus left, ProviderProvisioningStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ProviderProvisioningStatus"/> values are not the same. </summary>
        public static bool operator !=(ProviderProvisioningStatus left, ProviderProvisioningStatus right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="ProviderProvisioningStatus"/>. </summary>
        public static implicit operator ProviderProvisioningStatus(string value) => new ProviderProvisioningStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ProviderProvisioningStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ProviderProvisioningStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
