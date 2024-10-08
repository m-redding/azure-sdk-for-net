// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.InformaticaDataManagement.Models
{
    /// <summary> Various types of the Platform types. </summary>
    public readonly partial struct InformaticaPlatformType : IEquatable<InformaticaPlatformType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="InformaticaPlatformType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public InformaticaPlatformType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AzureValue = "AZURE";

        /// <summary> Azure platform type. </summary>
        public static InformaticaPlatformType Azure { get; } = new InformaticaPlatformType(AzureValue);
        /// <summary> Determines if two <see cref="InformaticaPlatformType"/> values are the same. </summary>
        public static bool operator ==(InformaticaPlatformType left, InformaticaPlatformType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="InformaticaPlatformType"/> values are not the same. </summary>
        public static bool operator !=(InformaticaPlatformType left, InformaticaPlatformType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="InformaticaPlatformType"/>. </summary>
        public static implicit operator InformaticaPlatformType(string value) => new InformaticaPlatformType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InformaticaPlatformType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(InformaticaPlatformType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
