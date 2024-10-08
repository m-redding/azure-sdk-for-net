// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.CostManagement.Models
{
    /// <summary> Kind/type of the benefit. </summary>
    public readonly partial struct BillingAccountBenefitKind : IEquatable<BillingAccountBenefitKind>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="BillingAccountBenefitKind"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public BillingAccountBenefitKind(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string IncludedQuantityValue = "IncludedQuantity";
        private const string ReservationValue = "Reservation";
        private const string SavingsPlanValue = "SavingsPlan";

        /// <summary> Benefit is IncludedQuantity. </summary>
        public static BillingAccountBenefitKind IncludedQuantity { get; } = new BillingAccountBenefitKind(IncludedQuantityValue);
        /// <summary> Benefit is Reservation. </summary>
        public static BillingAccountBenefitKind Reservation { get; } = new BillingAccountBenefitKind(ReservationValue);
        /// <summary> Benefit is SavingsPlan. </summary>
        public static BillingAccountBenefitKind SavingsPlan { get; } = new BillingAccountBenefitKind(SavingsPlanValue);
        /// <summary> Determines if two <see cref="BillingAccountBenefitKind"/> values are the same. </summary>
        public static bool operator ==(BillingAccountBenefitKind left, BillingAccountBenefitKind right) => left.Equals(right);
        /// <summary> Determines if two <see cref="BillingAccountBenefitKind"/> values are not the same. </summary>
        public static bool operator !=(BillingAccountBenefitKind left, BillingAccountBenefitKind right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="BillingAccountBenefitKind"/>. </summary>
        public static implicit operator BillingAccountBenefitKind(string value) => new BillingAccountBenefitKind(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is BillingAccountBenefitKind other && Equals(other);
        /// <inheritdoc />
        public bool Equals(BillingAccountBenefitKind other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
