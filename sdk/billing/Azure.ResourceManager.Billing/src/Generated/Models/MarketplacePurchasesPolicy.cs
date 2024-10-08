// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Billing.Models
{
    /// <summary> The policy that controls whether Azure marketplace purchases are allowed. </summary>
    public readonly partial struct MarketplacePurchasesPolicy : IEquatable<MarketplacePurchasesPolicy>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MarketplacePurchasesPolicy"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MarketplacePurchasesPolicy(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string OtherValue = "Other";
        private const string AllAllowedValue = "AllAllowed";
        private const string DisabledValue = "Disabled";
        private const string NotAllowedValue = "NotAllowed";
        private const string OnlyFreeAllowedValue = "OnlyFreeAllowed";

        /// <summary> Other. </summary>
        public static MarketplacePurchasesPolicy Other { get; } = new MarketplacePurchasesPolicy(OtherValue);
        /// <summary> AllAllowed. </summary>
        public static MarketplacePurchasesPolicy AllAllowed { get; } = new MarketplacePurchasesPolicy(AllAllowedValue);
        /// <summary> Disabled. </summary>
        public static MarketplacePurchasesPolicy Disabled { get; } = new MarketplacePurchasesPolicy(DisabledValue);
        /// <summary> NotAllowed. </summary>
        public static MarketplacePurchasesPolicy NotAllowed { get; } = new MarketplacePurchasesPolicy(NotAllowedValue);
        /// <summary> OnlyFreeAllowed. </summary>
        public static MarketplacePurchasesPolicy OnlyFreeAllowed { get; } = new MarketplacePurchasesPolicy(OnlyFreeAllowedValue);
        /// <summary> Determines if two <see cref="MarketplacePurchasesPolicy"/> values are the same. </summary>
        public static bool operator ==(MarketplacePurchasesPolicy left, MarketplacePurchasesPolicy right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MarketplacePurchasesPolicy"/> values are not the same. </summary>
        public static bool operator !=(MarketplacePurchasesPolicy left, MarketplacePurchasesPolicy right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="MarketplacePurchasesPolicy"/>. </summary>
        public static implicit operator MarketplacePurchasesPolicy(string value) => new MarketplacePurchasesPolicy(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MarketplacePurchasesPolicy other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MarketplacePurchasesPolicy other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
