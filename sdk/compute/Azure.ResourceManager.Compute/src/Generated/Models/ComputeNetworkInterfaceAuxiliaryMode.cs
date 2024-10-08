// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> Specifies whether the Auxiliary mode is enabled for the Network Interface resource. </summary>
    public readonly partial struct ComputeNetworkInterfaceAuxiliaryMode : IEquatable<ComputeNetworkInterfaceAuxiliaryMode>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ComputeNetworkInterfaceAuxiliaryMode"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ComputeNetworkInterfaceAuxiliaryMode(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NoneValue = "None";
        private const string AcceleratedConnectionsValue = "AcceleratedConnections";
        private const string FloatingValue = "Floating";

        /// <summary> None. </summary>
        public static ComputeNetworkInterfaceAuxiliaryMode None { get; } = new ComputeNetworkInterfaceAuxiliaryMode(NoneValue);
        /// <summary> AcceleratedConnections. </summary>
        public static ComputeNetworkInterfaceAuxiliaryMode AcceleratedConnections { get; } = new ComputeNetworkInterfaceAuxiliaryMode(AcceleratedConnectionsValue);
        /// <summary> Floating. </summary>
        public static ComputeNetworkInterfaceAuxiliaryMode Floating { get; } = new ComputeNetworkInterfaceAuxiliaryMode(FloatingValue);
        /// <summary> Determines if two <see cref="ComputeNetworkInterfaceAuxiliaryMode"/> values are the same. </summary>
        public static bool operator ==(ComputeNetworkInterfaceAuxiliaryMode left, ComputeNetworkInterfaceAuxiliaryMode right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ComputeNetworkInterfaceAuxiliaryMode"/> values are not the same. </summary>
        public static bool operator !=(ComputeNetworkInterfaceAuxiliaryMode left, ComputeNetworkInterfaceAuxiliaryMode right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="ComputeNetworkInterfaceAuxiliaryMode"/>. </summary>
        public static implicit operator ComputeNetworkInterfaceAuxiliaryMode(string value) => new ComputeNetworkInterfaceAuxiliaryMode(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ComputeNetworkInterfaceAuxiliaryMode other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ComputeNetworkInterfaceAuxiliaryMode other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
