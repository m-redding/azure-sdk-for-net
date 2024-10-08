// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.TextAnalytics.Legacy.Models
{
    /// <summary> Error code. </summary>
    internal readonly partial struct InnerErrorCodeValue : IEquatable<InnerErrorCodeValue>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="InnerErrorCodeValue"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public InnerErrorCodeValue(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string InvalidParameterValueValue = "InvalidParameterValue";
        private const string InvalidRequestBodyFormatValue = "InvalidRequestBodyFormat";
        private const string EmptyRequestValue = "EmptyRequest";
        private const string MissingInputRecordsValue = "MissingInputRecords";
        private const string InvalidDocumentValue = "InvalidDocument";
        private const string ModelVersionIncorrectValue = "ModelVersionIncorrect";
        private const string InvalidDocumentBatchValue = "InvalidDocumentBatch";
        private const string UnsupportedLanguageCodeValue = "UnsupportedLanguageCode";
        private const string InvalidCountryHintValue = "InvalidCountryHint";

        /// <summary> InvalidParameterValue. </summary>
        public static InnerErrorCodeValue InvalidParameterValue { get; } = new InnerErrorCodeValue(InvalidParameterValueValue);
        /// <summary> InvalidRequestBodyFormat. </summary>
        public static InnerErrorCodeValue InvalidRequestBodyFormat { get; } = new InnerErrorCodeValue(InvalidRequestBodyFormatValue);
        /// <summary> EmptyRequest. </summary>
        public static InnerErrorCodeValue EmptyRequest { get; } = new InnerErrorCodeValue(EmptyRequestValue);
        /// <summary> MissingInputRecords. </summary>
        public static InnerErrorCodeValue MissingInputRecords { get; } = new InnerErrorCodeValue(MissingInputRecordsValue);
        /// <summary> InvalidDocument. </summary>
        public static InnerErrorCodeValue InvalidDocument { get; } = new InnerErrorCodeValue(InvalidDocumentValue);
        /// <summary> ModelVersionIncorrect. </summary>
        public static InnerErrorCodeValue ModelVersionIncorrect { get; } = new InnerErrorCodeValue(ModelVersionIncorrectValue);
        /// <summary> InvalidDocumentBatch. </summary>
        public static InnerErrorCodeValue InvalidDocumentBatch { get; } = new InnerErrorCodeValue(InvalidDocumentBatchValue);
        /// <summary> UnsupportedLanguageCode. </summary>
        public static InnerErrorCodeValue UnsupportedLanguageCode { get; } = new InnerErrorCodeValue(UnsupportedLanguageCodeValue);
        /// <summary> InvalidCountryHint. </summary>
        public static InnerErrorCodeValue InvalidCountryHint { get; } = new InnerErrorCodeValue(InvalidCountryHintValue);
        /// <summary> Determines if two <see cref="InnerErrorCodeValue"/> values are the same. </summary>
        public static bool operator ==(InnerErrorCodeValue left, InnerErrorCodeValue right) => left.Equals(right);
        /// <summary> Determines if two <see cref="InnerErrorCodeValue"/> values are not the same. </summary>
        public static bool operator !=(InnerErrorCodeValue left, InnerErrorCodeValue right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="InnerErrorCodeValue"/>. </summary>
        public static implicit operator InnerErrorCodeValue(string value) => new InnerErrorCodeValue(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InnerErrorCodeValue other && Equals(other);
        /// <inheritdoc />
        public bool Equals(InnerErrorCodeValue other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
