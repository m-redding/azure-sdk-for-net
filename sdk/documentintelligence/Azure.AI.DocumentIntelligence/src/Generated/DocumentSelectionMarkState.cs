// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.DocumentIntelligence
{
    /// <summary> State of the selection mark. </summary>
    public readonly partial struct DocumentSelectionMarkState : IEquatable<DocumentSelectionMarkState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DocumentSelectionMarkState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public DocumentSelectionMarkState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string SelectedValue = "selected";
        private const string UnselectedValue = "unselected";

        /// <summary>
        /// The selection mark is selected, often indicated by a check ✓ or cross X inside
        /// the selection mark.
        /// </summary>
        public static DocumentSelectionMarkState Selected { get; } = new DocumentSelectionMarkState(SelectedValue);
        /// <summary> The selection mark is not selected. </summary>
        public static DocumentSelectionMarkState Unselected { get; } = new DocumentSelectionMarkState(UnselectedValue);
        /// <summary> Determines if two <see cref="DocumentSelectionMarkState"/> values are the same. </summary>
        public static bool operator ==(DocumentSelectionMarkState left, DocumentSelectionMarkState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="DocumentSelectionMarkState"/> values are not the same. </summary>
        public static bool operator !=(DocumentSelectionMarkState left, DocumentSelectionMarkState right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="DocumentSelectionMarkState"/>. </summary>
        public static implicit operator DocumentSelectionMarkState(string value) => new DocumentSelectionMarkState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is DocumentSelectionMarkState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(DocumentSelectionMarkState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
