// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> The transport protocol for the endpoint. </summary>
    public readonly partial struct LoadBalancingTransportProtocol : IEquatable<LoadBalancingTransportProtocol>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="LoadBalancingTransportProtocol"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public LoadBalancingTransportProtocol(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string UdpValue = "Udp";
        private const string TcpValue = "Tcp";
        private const string AllValue = "All";

        /// <summary> Udp. </summary>
        public static LoadBalancingTransportProtocol Udp { get; } = new LoadBalancingTransportProtocol(UdpValue);
        /// <summary> Tcp. </summary>
        public static LoadBalancingTransportProtocol Tcp { get; } = new LoadBalancingTransportProtocol(TcpValue);
        /// <summary> All. </summary>
        public static LoadBalancingTransportProtocol All { get; } = new LoadBalancingTransportProtocol(AllValue);
        /// <summary> Determines if two <see cref="LoadBalancingTransportProtocol"/> values are the same. </summary>
        public static bool operator ==(LoadBalancingTransportProtocol left, LoadBalancingTransportProtocol right) => left.Equals(right);
        /// <summary> Determines if two <see cref="LoadBalancingTransportProtocol"/> values are not the same. </summary>
        public static bool operator !=(LoadBalancingTransportProtocol left, LoadBalancingTransportProtocol right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="LoadBalancingTransportProtocol"/>. </summary>
        public static implicit operator LoadBalancingTransportProtocol(string value) => new LoadBalancingTransportProtocol(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is LoadBalancingTransportProtocol other && Equals(other);
        /// <inheritdoc />
        public bool Equals(LoadBalancingTransportProtocol other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
