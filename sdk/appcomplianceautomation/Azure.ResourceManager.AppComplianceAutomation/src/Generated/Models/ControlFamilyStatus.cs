// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AppComplianceAutomation.Models
{
    /// <summary> Indicates the control family status. </summary>
    public readonly partial struct ControlFamilyStatus : IEquatable<ControlFamilyStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ControlFamilyStatus"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ControlFamilyStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string PassedValue = "Passed";
        private const string FailedValue = "Failed";
        private const string NotApplicableValue = "NotApplicable";
        private const string PendingApprovalValue = "PendingApproval";

        /// <summary> The control family is passed. </summary>
        public static ControlFamilyStatus Passed { get; } = new ControlFamilyStatus(PassedValue);
        /// <summary> The control family is failed. </summary>
        public static ControlFamilyStatus Failed { get; } = new ControlFamilyStatus(FailedValue);
        /// <summary> The control family is not applicable. </summary>
        public static ControlFamilyStatus NotApplicable { get; } = new ControlFamilyStatus(NotApplicableValue);
        /// <summary> The control family is pending for approval. </summary>
        public static ControlFamilyStatus PendingApproval { get; } = new ControlFamilyStatus(PendingApprovalValue);
        /// <summary> Determines if two <see cref="ControlFamilyStatus"/> values are the same. </summary>
        public static bool operator ==(ControlFamilyStatus left, ControlFamilyStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ControlFamilyStatus"/> values are not the same. </summary>
        public static bool operator !=(ControlFamilyStatus left, ControlFamilyStatus right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="ControlFamilyStatus"/>. </summary>
        public static implicit operator ControlFamilyStatus(string value) => new ControlFamilyStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ControlFamilyStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ControlFamilyStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
