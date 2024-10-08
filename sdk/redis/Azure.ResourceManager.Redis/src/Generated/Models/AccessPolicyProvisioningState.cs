// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Redis.Models
{
    /// <summary> Provisioning state of access policy. </summary>
    public readonly partial struct AccessPolicyProvisioningState : IEquatable<AccessPolicyProvisioningState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="AccessPolicyProvisioningState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public AccessPolicyProvisioningState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string UpdatingValue = "Updating";
        private const string SucceededValue = "Succeeded";
        private const string DeletingValue = "Deleting";
        private const string DeletedValue = "Deleted";
        private const string CanceledValue = "Canceled";
        private const string FailedValue = "Failed";

        /// <summary> Updating. </summary>
        public static AccessPolicyProvisioningState Updating { get; } = new AccessPolicyProvisioningState(UpdatingValue);
        /// <summary> Succeeded. </summary>
        public static AccessPolicyProvisioningState Succeeded { get; } = new AccessPolicyProvisioningState(SucceededValue);
        /// <summary> Deleting. </summary>
        public static AccessPolicyProvisioningState Deleting { get; } = new AccessPolicyProvisioningState(DeletingValue);
        /// <summary> Deleted. </summary>
        public static AccessPolicyProvisioningState Deleted { get; } = new AccessPolicyProvisioningState(DeletedValue);
        /// <summary> Canceled. </summary>
        public static AccessPolicyProvisioningState Canceled { get; } = new AccessPolicyProvisioningState(CanceledValue);
        /// <summary> Failed. </summary>
        public static AccessPolicyProvisioningState Failed { get; } = new AccessPolicyProvisioningState(FailedValue);
        /// <summary> Determines if two <see cref="AccessPolicyProvisioningState"/> values are the same. </summary>
        public static bool operator ==(AccessPolicyProvisioningState left, AccessPolicyProvisioningState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="AccessPolicyProvisioningState"/> values are not the same. </summary>
        public static bool operator !=(AccessPolicyProvisioningState left, AccessPolicyProvisioningState right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="AccessPolicyProvisioningState"/>. </summary>
        public static implicit operator AccessPolicyProvisioningState(string value) => new AccessPolicyProvisioningState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AccessPolicyProvisioningState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(AccessPolicyProvisioningState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
