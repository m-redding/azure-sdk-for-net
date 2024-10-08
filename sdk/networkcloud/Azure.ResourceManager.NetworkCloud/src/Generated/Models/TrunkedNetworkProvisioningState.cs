// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    /// <summary> The provisioning state of the trunked network. </summary>
    public readonly partial struct TrunkedNetworkProvisioningState : IEquatable<TrunkedNetworkProvisioningState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="TrunkedNetworkProvisioningState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public TrunkedNetworkProvisioningState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string SucceededValue = "Succeeded";
        private const string FailedValue = "Failed";
        private const string CanceledValue = "Canceled";
        private const string ProvisioningValue = "Provisioning";
        private const string AcceptedValue = "Accepted";

        /// <summary> Succeeded. </summary>
        public static TrunkedNetworkProvisioningState Succeeded { get; } = new TrunkedNetworkProvisioningState(SucceededValue);
        /// <summary> Failed. </summary>
        public static TrunkedNetworkProvisioningState Failed { get; } = new TrunkedNetworkProvisioningState(FailedValue);
        /// <summary> Canceled. </summary>
        public static TrunkedNetworkProvisioningState Canceled { get; } = new TrunkedNetworkProvisioningState(CanceledValue);
        /// <summary> Provisioning. </summary>
        public static TrunkedNetworkProvisioningState Provisioning { get; } = new TrunkedNetworkProvisioningState(ProvisioningValue);
        /// <summary> Accepted. </summary>
        public static TrunkedNetworkProvisioningState Accepted { get; } = new TrunkedNetworkProvisioningState(AcceptedValue);
        /// <summary> Determines if two <see cref="TrunkedNetworkProvisioningState"/> values are the same. </summary>
        public static bool operator ==(TrunkedNetworkProvisioningState left, TrunkedNetworkProvisioningState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="TrunkedNetworkProvisioningState"/> values are not the same. </summary>
        public static bool operator !=(TrunkedNetworkProvisioningState left, TrunkedNetworkProvisioningState right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="TrunkedNetworkProvisioningState"/>. </summary>
        public static implicit operator TrunkedNetworkProvisioningState(string value) => new TrunkedNetworkProvisioningState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is TrunkedNetworkProvisioningState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(TrunkedNetworkProvisioningState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
