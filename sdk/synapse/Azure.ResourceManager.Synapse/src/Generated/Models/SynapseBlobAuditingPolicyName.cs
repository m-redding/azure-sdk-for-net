// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Synapse.Models
{
    /// <summary> The SynapseBlobAuditingPolicyName. </summary>
    public readonly partial struct SynapseBlobAuditingPolicyName : IEquatable<SynapseBlobAuditingPolicyName>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="SynapseBlobAuditingPolicyName"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SynapseBlobAuditingPolicyName(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string DefaultValue = "default";

        /// <summary> default. </summary>
        public static SynapseBlobAuditingPolicyName Default { get; } = new SynapseBlobAuditingPolicyName(DefaultValue);
        /// <summary> Determines if two <see cref="SynapseBlobAuditingPolicyName"/> values are the same. </summary>
        public static bool operator ==(SynapseBlobAuditingPolicyName left, SynapseBlobAuditingPolicyName right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SynapseBlobAuditingPolicyName"/> values are not the same. </summary>
        public static bool operator !=(SynapseBlobAuditingPolicyName left, SynapseBlobAuditingPolicyName right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="SynapseBlobAuditingPolicyName"/>. </summary>
        public static implicit operator SynapseBlobAuditingPolicyName(string value) => new SynapseBlobAuditingPolicyName(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SynapseBlobAuditingPolicyName other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SynapseBlobAuditingPolicyName other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
