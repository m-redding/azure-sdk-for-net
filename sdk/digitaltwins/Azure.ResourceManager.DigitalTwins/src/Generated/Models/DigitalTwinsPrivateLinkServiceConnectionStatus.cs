// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.DigitalTwins.Models
{
    /// <summary> The status of a private endpoint connection. </summary>
    public readonly partial struct DigitalTwinsPrivateLinkServiceConnectionStatus : IEquatable<DigitalTwinsPrivateLinkServiceConnectionStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DigitalTwinsPrivateLinkServiceConnectionStatus"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public DigitalTwinsPrivateLinkServiceConnectionStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string PendingValue = "Pending";
        private const string ApprovedValue = "Approved";
        private const string RejectedValue = "Rejected";
        private const string DisconnectedValue = "Disconnected";

        /// <summary> Pending. </summary>
        public static DigitalTwinsPrivateLinkServiceConnectionStatus Pending { get; } = new DigitalTwinsPrivateLinkServiceConnectionStatus(PendingValue);
        /// <summary> Approved. </summary>
        public static DigitalTwinsPrivateLinkServiceConnectionStatus Approved { get; } = new DigitalTwinsPrivateLinkServiceConnectionStatus(ApprovedValue);
        /// <summary> Rejected. </summary>
        public static DigitalTwinsPrivateLinkServiceConnectionStatus Rejected { get; } = new DigitalTwinsPrivateLinkServiceConnectionStatus(RejectedValue);
        /// <summary> Disconnected. </summary>
        public static DigitalTwinsPrivateLinkServiceConnectionStatus Disconnected { get; } = new DigitalTwinsPrivateLinkServiceConnectionStatus(DisconnectedValue);
        /// <summary> Determines if two <see cref="DigitalTwinsPrivateLinkServiceConnectionStatus"/> values are the same. </summary>
        public static bool operator ==(DigitalTwinsPrivateLinkServiceConnectionStatus left, DigitalTwinsPrivateLinkServiceConnectionStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="DigitalTwinsPrivateLinkServiceConnectionStatus"/> values are not the same. </summary>
        public static bool operator !=(DigitalTwinsPrivateLinkServiceConnectionStatus left, DigitalTwinsPrivateLinkServiceConnectionStatus right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="DigitalTwinsPrivateLinkServiceConnectionStatus"/>. </summary>
        public static implicit operator DigitalTwinsPrivateLinkServiceConnectionStatus(string value) => new DigitalTwinsPrivateLinkServiceConnectionStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is DigitalTwinsPrivateLinkServiceConnectionStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(DigitalTwinsPrivateLinkServiceConnectionStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
