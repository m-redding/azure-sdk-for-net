// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ScVmm.Models
{
    /// <summary> The provisioning state of a resource. </summary>
    public readonly partial struct ScVmmProvisioningState : IEquatable<ScVmmProvisioningState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ScVmmProvisioningState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ScVmmProvisioningState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string SucceededValue = "Succeeded";
        private const string FailedValue = "Failed";
        private const string CanceledValue = "Canceled";
        private const string ProvisioningValue = "Provisioning";
        private const string UpdatingValue = "Updating";
        private const string DeletingValue = "Deleting";
        private const string AcceptedValue = "Accepted";
        private const string CreatedValue = "Created";

        /// <summary> Succeeded. </summary>
        public static ScVmmProvisioningState Succeeded { get; } = new ScVmmProvisioningState(SucceededValue);
        /// <summary> Failed. </summary>
        public static ScVmmProvisioningState Failed { get; } = new ScVmmProvisioningState(FailedValue);
        /// <summary> Canceled. </summary>
        public static ScVmmProvisioningState Canceled { get; } = new ScVmmProvisioningState(CanceledValue);
        /// <summary> Provisioning. </summary>
        public static ScVmmProvisioningState Provisioning { get; } = new ScVmmProvisioningState(ProvisioningValue);
        /// <summary> Updating. </summary>
        public static ScVmmProvisioningState Updating { get; } = new ScVmmProvisioningState(UpdatingValue);
        /// <summary> Deleting. </summary>
        public static ScVmmProvisioningState Deleting { get; } = new ScVmmProvisioningState(DeletingValue);
        /// <summary> Accepted. </summary>
        public static ScVmmProvisioningState Accepted { get; } = new ScVmmProvisioningState(AcceptedValue);
        /// <summary> Created. </summary>
        public static ScVmmProvisioningState Created { get; } = new ScVmmProvisioningState(CreatedValue);
        /// <summary> Determines if two <see cref="ScVmmProvisioningState"/> values are the same. </summary>
        public static bool operator ==(ScVmmProvisioningState left, ScVmmProvisioningState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ScVmmProvisioningState"/> values are not the same. </summary>
        public static bool operator !=(ScVmmProvisioningState left, ScVmmProvisioningState right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="ScVmmProvisioningState"/>. </summary>
        public static implicit operator ScVmmProvisioningState(string value) => new ScVmmProvisioningState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ScVmmProvisioningState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ScVmmProvisioningState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
