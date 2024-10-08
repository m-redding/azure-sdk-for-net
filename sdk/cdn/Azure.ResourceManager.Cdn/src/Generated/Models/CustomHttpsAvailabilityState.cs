// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    /// <summary> Provisioning substate shows the progress of custom HTTPS enabling/disabling process step by step. </summary>
    public readonly partial struct CustomHttpsAvailabilityState : IEquatable<CustomHttpsAvailabilityState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CustomHttpsAvailabilityState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public CustomHttpsAvailabilityState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string SubmittingDomainControlValidationRequestValue = "SubmittingDomainControlValidationRequest";
        private const string PendingDomainControlValidationREquestApprovalValue = "PendingDomainControlValidationREquestApproval";
        private const string DomainControlValidationRequestApprovedValue = "DomainControlValidationRequestApproved";
        private const string DomainControlValidationRequestRejectedValue = "DomainControlValidationRequestRejected";
        private const string DomainControlValidationRequestTimedOutValue = "DomainControlValidationRequestTimedOut";
        private const string IssuingCertificateValue = "IssuingCertificate";
        private const string DeployingCertificateValue = "DeployingCertificate";
        private const string CertificateDeployedValue = "CertificateDeployed";
        private const string DeletingCertificateValue = "DeletingCertificate";
        private const string CertificateDeletedValue = "CertificateDeleted";

        /// <summary> SubmittingDomainControlValidationRequest. </summary>
        public static CustomHttpsAvailabilityState SubmittingDomainControlValidationRequest { get; } = new CustomHttpsAvailabilityState(SubmittingDomainControlValidationRequestValue);
        /// <summary> PendingDomainControlValidationREquestApproval. </summary>
        public static CustomHttpsAvailabilityState PendingDomainControlValidationREquestApproval { get; } = new CustomHttpsAvailabilityState(PendingDomainControlValidationREquestApprovalValue);
        /// <summary> DomainControlValidationRequestApproved. </summary>
        public static CustomHttpsAvailabilityState DomainControlValidationRequestApproved { get; } = new CustomHttpsAvailabilityState(DomainControlValidationRequestApprovedValue);
        /// <summary> DomainControlValidationRequestRejected. </summary>
        public static CustomHttpsAvailabilityState DomainControlValidationRequestRejected { get; } = new CustomHttpsAvailabilityState(DomainControlValidationRequestRejectedValue);
        /// <summary> DomainControlValidationRequestTimedOut. </summary>
        public static CustomHttpsAvailabilityState DomainControlValidationRequestTimedOut { get; } = new CustomHttpsAvailabilityState(DomainControlValidationRequestTimedOutValue);
        /// <summary> IssuingCertificate. </summary>
        public static CustomHttpsAvailabilityState IssuingCertificate { get; } = new CustomHttpsAvailabilityState(IssuingCertificateValue);
        /// <summary> DeployingCertificate. </summary>
        public static CustomHttpsAvailabilityState DeployingCertificate { get; } = new CustomHttpsAvailabilityState(DeployingCertificateValue);
        /// <summary> CertificateDeployed. </summary>
        public static CustomHttpsAvailabilityState CertificateDeployed { get; } = new CustomHttpsAvailabilityState(CertificateDeployedValue);
        /// <summary> DeletingCertificate. </summary>
        public static CustomHttpsAvailabilityState DeletingCertificate { get; } = new CustomHttpsAvailabilityState(DeletingCertificateValue);
        /// <summary> CertificateDeleted. </summary>
        public static CustomHttpsAvailabilityState CertificateDeleted { get; } = new CustomHttpsAvailabilityState(CertificateDeletedValue);
        /// <summary> Determines if two <see cref="CustomHttpsAvailabilityState"/> values are the same. </summary>
        public static bool operator ==(CustomHttpsAvailabilityState left, CustomHttpsAvailabilityState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="CustomHttpsAvailabilityState"/> values are not the same. </summary>
        public static bool operator !=(CustomHttpsAvailabilityState left, CustomHttpsAvailabilityState right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="CustomHttpsAvailabilityState"/>. </summary>
        public static implicit operator CustomHttpsAvailabilityState(string value) => new CustomHttpsAvailabilityState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CustomHttpsAvailabilityState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CustomHttpsAvailabilityState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
