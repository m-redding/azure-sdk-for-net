// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.SecurityInsights.Models
{
    /// <summary> The type of the label. </summary>
    public readonly partial struct SecurityInsightsIncidentLabelType : IEquatable<SecurityInsightsIncidentLabelType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="SecurityInsightsIncidentLabelType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SecurityInsightsIncidentLabelType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string UserValue = "User";
        private const string AutoAssignedValue = "AutoAssigned";

        /// <summary> Label manually created by a user. </summary>
        public static SecurityInsightsIncidentLabelType User { get; } = new SecurityInsightsIncidentLabelType(UserValue);
        /// <summary> Label automatically created by the system. </summary>
        public static SecurityInsightsIncidentLabelType AutoAssigned { get; } = new SecurityInsightsIncidentLabelType(AutoAssignedValue);
        /// <summary> Determines if two <see cref="SecurityInsightsIncidentLabelType"/> values are the same. </summary>
        public static bool operator ==(SecurityInsightsIncidentLabelType left, SecurityInsightsIncidentLabelType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SecurityInsightsIncidentLabelType"/> values are not the same. </summary>
        public static bool operator !=(SecurityInsightsIncidentLabelType left, SecurityInsightsIncidentLabelType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="SecurityInsightsIncidentLabelType"/>. </summary>
        public static implicit operator SecurityInsightsIncidentLabelType(string value) => new SecurityInsightsIncidentLabelType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SecurityInsightsIncidentLabelType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SecurityInsightsIncidentLabelType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
