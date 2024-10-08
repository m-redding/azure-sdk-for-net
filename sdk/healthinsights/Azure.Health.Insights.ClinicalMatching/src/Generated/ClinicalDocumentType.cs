// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Health.Insights.ClinicalMatching
{
    /// <summary> The type of the clinical document. </summary>
    public readonly partial struct ClinicalDocumentType : IEquatable<ClinicalDocumentType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ClinicalDocumentType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ClinicalDocumentType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ConsultationValue = "consultation";
        private const string DischargeSummaryValue = "dischargeSummary";
        private const string HistoryAndPhysicalValue = "historyAndPhysical";
        private const string ProcedureValue = "procedure";
        private const string ProgressValue = "progress";
        private const string ImagingValue = "imaging";
        private const string LaboratoryValue = "laboratory";
        private const string PathologyValue = "pathology";

        /// <summary> consultation. </summary>
        public static ClinicalDocumentType Consultation { get; } = new ClinicalDocumentType(ConsultationValue);
        /// <summary> dischargeSummary. </summary>
        public static ClinicalDocumentType DischargeSummary { get; } = new ClinicalDocumentType(DischargeSummaryValue);
        /// <summary> historyAndPhysical. </summary>
        public static ClinicalDocumentType HistoryAndPhysical { get; } = new ClinicalDocumentType(HistoryAndPhysicalValue);
        /// <summary> procedure. </summary>
        public static ClinicalDocumentType Procedure { get; } = new ClinicalDocumentType(ProcedureValue);
        /// <summary> progress. </summary>
        public static ClinicalDocumentType Progress { get; } = new ClinicalDocumentType(ProgressValue);
        /// <summary> imaging. </summary>
        public static ClinicalDocumentType Imaging { get; } = new ClinicalDocumentType(ImagingValue);
        /// <summary> laboratory. </summary>
        public static ClinicalDocumentType Laboratory { get; } = new ClinicalDocumentType(LaboratoryValue);
        /// <summary> pathology. </summary>
        public static ClinicalDocumentType Pathology { get; } = new ClinicalDocumentType(PathologyValue);
        /// <summary> Determines if two <see cref="ClinicalDocumentType"/> values are the same. </summary>
        public static bool operator ==(ClinicalDocumentType left, ClinicalDocumentType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ClinicalDocumentType"/> values are not the same. </summary>
        public static bool operator !=(ClinicalDocumentType left, ClinicalDocumentType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="ClinicalDocumentType"/>. </summary>
        public static implicit operator ClinicalDocumentType(string value) => new ClinicalDocumentType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ClinicalDocumentType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ClinicalDocumentType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
