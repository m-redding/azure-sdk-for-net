// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.Language.Text
{
    /// <summary> The length unit of measurement. </summary>
    public readonly partial struct LengthUnit : IEquatable<LengthUnit>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="LengthUnit"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public LengthUnit(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string UnspecifiedValue = "Unspecified";
        private const string KilometerValue = "Kilometer";
        private const string HectometerValue = "Hectometer";
        private const string DecameterValue = "Decameter";
        private const string MeterValue = "Meter";
        private const string DecimeterValue = "Decimeter";
        private const string CentimeterValue = "Centimeter";
        private const string MillimeterValue = "Millimeter";
        private const string MicrometerValue = "Micrometer";
        private const string NanometerValue = "Nanometer";
        private const string PicometerValue = "Picometer";
        private const string MileValue = "Mile";
        private const string YardValue = "Yard";
        private const string InchValue = "Inch";
        private const string FootValue = "Foot";
        private const string LightYearValue = "LightYear";
        private const string PointValue = "Point";

        /// <summary> Unspecified length unit. </summary>
        public static LengthUnit Unspecified { get; } = new LengthUnit(UnspecifiedValue);
        /// <summary> Length unit in kilometers. </summary>
        public static LengthUnit Kilometer { get; } = new LengthUnit(KilometerValue);
        /// <summary> Length unit in hectometers. </summary>
        public static LengthUnit Hectometer { get; } = new LengthUnit(HectometerValue);
        /// <summary> Length unit in decameters. </summary>
        public static LengthUnit Decameter { get; } = new LengthUnit(DecameterValue);
        /// <summary> Length unit in meters. </summary>
        public static LengthUnit Meter { get; } = new LengthUnit(MeterValue);
        /// <summary> Length unit in decimeters. </summary>
        public static LengthUnit Decimeter { get; } = new LengthUnit(DecimeterValue);
        /// <summary> Length unit in centimeters. </summary>
        public static LengthUnit Centimeter { get; } = new LengthUnit(CentimeterValue);
        /// <summary> Length unit in millimeters. </summary>
        public static LengthUnit Millimeter { get; } = new LengthUnit(MillimeterValue);
        /// <summary> Length unit in micrometers. </summary>
        public static LengthUnit Micrometer { get; } = new LengthUnit(MicrometerValue);
        /// <summary> Length unit in nanometers. </summary>
        public static LengthUnit Nanometer { get; } = new LengthUnit(NanometerValue);
        /// <summary> Length unit in picometers. </summary>
        public static LengthUnit Picometer { get; } = new LengthUnit(PicometerValue);
        /// <summary> Length unit in miles. </summary>
        public static LengthUnit Mile { get; } = new LengthUnit(MileValue);
        /// <summary> Length unit in yards. </summary>
        public static LengthUnit Yard { get; } = new LengthUnit(YardValue);
        /// <summary> Length unit in inches. </summary>
        public static LengthUnit Inch { get; } = new LengthUnit(InchValue);
        /// <summary> Length unit in feet. </summary>
        public static LengthUnit Foot { get; } = new LengthUnit(FootValue);
        /// <summary> Length unit in light years. </summary>
        public static LengthUnit LightYear { get; } = new LengthUnit(LightYearValue);
        /// <summary> Length unit in points. </summary>
        public static LengthUnit Point { get; } = new LengthUnit(PointValue);
        /// <summary> Determines if two <see cref="LengthUnit"/> values are the same. </summary>
        public static bool operator ==(LengthUnit left, LengthUnit right) => left.Equals(right);
        /// <summary> Determines if two <see cref="LengthUnit"/> values are not the same. </summary>
        public static bool operator !=(LengthUnit left, LengthUnit right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="LengthUnit"/>. </summary>
        public static implicit operator LengthUnit(string value) => new LengthUnit(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is LengthUnit other && Equals(other);
        /// <inheritdoc />
        public bool Equals(LengthUnit other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
