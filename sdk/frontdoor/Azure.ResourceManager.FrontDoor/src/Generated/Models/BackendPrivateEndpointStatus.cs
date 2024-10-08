// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.FrontDoor.Models
{
    /// <summary> The Approval status for the connection to the Private Link. </summary>
    public readonly partial struct BackendPrivateEndpointStatus : IEquatable<BackendPrivateEndpointStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="BackendPrivateEndpointStatus"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public BackendPrivateEndpointStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string PendingValue = "Pending";
        private const string ApprovedValue = "Approved";
        private const string RejectedValue = "Rejected";
        private const string DisconnectedValue = "Disconnected";
        private const string TimeoutValue = "Timeout";

        /// <summary> Pending. </summary>
        public static BackendPrivateEndpointStatus Pending { get; } = new BackendPrivateEndpointStatus(PendingValue);
        /// <summary> Approved. </summary>
        public static BackendPrivateEndpointStatus Approved { get; } = new BackendPrivateEndpointStatus(ApprovedValue);
        /// <summary> Rejected. </summary>
        public static BackendPrivateEndpointStatus Rejected { get; } = new BackendPrivateEndpointStatus(RejectedValue);
        /// <summary> Disconnected. </summary>
        public static BackendPrivateEndpointStatus Disconnected { get; } = new BackendPrivateEndpointStatus(DisconnectedValue);
        /// <summary> Timeout. </summary>
        public static BackendPrivateEndpointStatus Timeout { get; } = new BackendPrivateEndpointStatus(TimeoutValue);
        /// <summary> Determines if two <see cref="BackendPrivateEndpointStatus"/> values are the same. </summary>
        public static bool operator ==(BackendPrivateEndpointStatus left, BackendPrivateEndpointStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="BackendPrivateEndpointStatus"/> values are not the same. </summary>
        public static bool operator !=(BackendPrivateEndpointStatus left, BackendPrivateEndpointStatus right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="BackendPrivateEndpointStatus"/>. </summary>
        public static implicit operator BackendPrivateEndpointStatus(string value) => new BackendPrivateEndpointStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is BackendPrivateEndpointStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(BackendPrivateEndpointStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
