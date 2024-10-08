// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Communication.Models
{
    /// <summary> Provisioning state of the resource. Unknown is the default state for Communication Services. </summary>
    public readonly partial struct CommunicationServiceProvisioningState : IEquatable<CommunicationServiceProvisioningState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CommunicationServiceProvisioningState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public CommunicationServiceProvisioningState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string UnknownValue = "Unknown";
        private const string SucceededValue = "Succeeded";
        private const string FailedValue = "Failed";
        private const string CanceledValue = "Canceled";
        private const string RunningValue = "Running";
        private const string CreatingValue = "Creating";
        private const string UpdatingValue = "Updating";
        private const string DeletingValue = "Deleting";
        private const string MovingValue = "Moving";

        /// <summary> Unknown. </summary>
        public static CommunicationServiceProvisioningState Unknown { get; } = new CommunicationServiceProvisioningState(UnknownValue);
        /// <summary> Succeeded. </summary>
        public static CommunicationServiceProvisioningState Succeeded { get; } = new CommunicationServiceProvisioningState(SucceededValue);
        /// <summary> Failed. </summary>
        public static CommunicationServiceProvisioningState Failed { get; } = new CommunicationServiceProvisioningState(FailedValue);
        /// <summary> Canceled. </summary>
        public static CommunicationServiceProvisioningState Canceled { get; } = new CommunicationServiceProvisioningState(CanceledValue);
        /// <summary> Running. </summary>
        public static CommunicationServiceProvisioningState Running { get; } = new CommunicationServiceProvisioningState(RunningValue);
        /// <summary> Creating. </summary>
        public static CommunicationServiceProvisioningState Creating { get; } = new CommunicationServiceProvisioningState(CreatingValue);
        /// <summary> Updating. </summary>
        public static CommunicationServiceProvisioningState Updating { get; } = new CommunicationServiceProvisioningState(UpdatingValue);
        /// <summary> Deleting. </summary>
        public static CommunicationServiceProvisioningState Deleting { get; } = new CommunicationServiceProvisioningState(DeletingValue);
        /// <summary> Moving. </summary>
        public static CommunicationServiceProvisioningState Moving { get; } = new CommunicationServiceProvisioningState(MovingValue);
        /// <summary> Determines if two <see cref="CommunicationServiceProvisioningState"/> values are the same. </summary>
        public static bool operator ==(CommunicationServiceProvisioningState left, CommunicationServiceProvisioningState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="CommunicationServiceProvisioningState"/> values are not the same. </summary>
        public static bool operator !=(CommunicationServiceProvisioningState left, CommunicationServiceProvisioningState right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="CommunicationServiceProvisioningState"/>. </summary>
        public static implicit operator CommunicationServiceProvisioningState(string value) => new CommunicationServiceProvisioningState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CommunicationServiceProvisioningState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CommunicationServiceProvisioningState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
