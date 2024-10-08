// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    /// <summary> A description of why the `status` has its value. </summary>
    public readonly partial struct JitNetworkAccessPortStatusReason : IEquatable<JitNetworkAccessPortStatusReason>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="JitNetworkAccessPortStatusReason"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public JitNetworkAccessPortStatusReason(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ExpiredValue = "Expired";
        private const string UserRequestedValue = "UserRequested";
        private const string NewerRequestInitiatedValue = "NewerRequestInitiated";

        /// <summary> Expired. </summary>
        public static JitNetworkAccessPortStatusReason Expired { get; } = new JitNetworkAccessPortStatusReason(ExpiredValue);
        /// <summary> UserRequested. </summary>
        public static JitNetworkAccessPortStatusReason UserRequested { get; } = new JitNetworkAccessPortStatusReason(UserRequestedValue);
        /// <summary> NewerRequestInitiated. </summary>
        public static JitNetworkAccessPortStatusReason NewerRequestInitiated { get; } = new JitNetworkAccessPortStatusReason(NewerRequestInitiatedValue);
        /// <summary> Determines if two <see cref="JitNetworkAccessPortStatusReason"/> values are the same. </summary>
        public static bool operator ==(JitNetworkAccessPortStatusReason left, JitNetworkAccessPortStatusReason right) => left.Equals(right);
        /// <summary> Determines if two <see cref="JitNetworkAccessPortStatusReason"/> values are not the same. </summary>
        public static bool operator !=(JitNetworkAccessPortStatusReason left, JitNetworkAccessPortStatusReason right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="JitNetworkAccessPortStatusReason"/>. </summary>
        public static implicit operator JitNetworkAccessPortStatusReason(string value) => new JitNetworkAccessPortStatusReason(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is JitNetworkAccessPortStatusReason other && Equals(other);
        /// <inheritdoc />
        public bool Equals(JitNetworkAccessPortStatusReason other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
