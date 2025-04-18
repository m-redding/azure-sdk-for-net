// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.Projects
{
    /// <summary> WeekDay of the schedule - Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday. </summary>
    public readonly partial struct WeekDays : IEquatable<WeekDays>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="WeekDays"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public WeekDays(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string MondayValue = "Monday";
        private const string TuesdayValue = "Tuesday";
        private const string WednesdayValue = "Wednesday";
        private const string ThursdayValue = "Thursday";
        private const string FridayValue = "Friday";
        private const string SaturdayValue = "Saturday";
        private const string SundayValue = "Sunday";

        /// <summary> Monday. </summary>
        public static WeekDays Monday { get; } = new WeekDays(MondayValue);
        /// <summary> Tuesday. </summary>
        public static WeekDays Tuesday { get; } = new WeekDays(TuesdayValue);
        /// <summary> Wednesday. </summary>
        public static WeekDays Wednesday { get; } = new WeekDays(WednesdayValue);
        /// <summary> Thursday. </summary>
        public static WeekDays Thursday { get; } = new WeekDays(ThursdayValue);
        /// <summary> Friday. </summary>
        public static WeekDays Friday { get; } = new WeekDays(FridayValue);
        /// <summary> Saturday. </summary>
        public static WeekDays Saturday { get; } = new WeekDays(SaturdayValue);
        /// <summary> Sunday. </summary>
        public static WeekDays Sunday { get; } = new WeekDays(SundayValue);
        /// <summary> Determines if two <see cref="WeekDays"/> values are the same. </summary>
        public static bool operator ==(WeekDays left, WeekDays right) => left.Equals(right);
        /// <summary> Determines if two <see cref="WeekDays"/> values are not the same. </summary>
        public static bool operator !=(WeekDays left, WeekDays right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="WeekDays"/>. </summary>
        public static implicit operator WeekDays(string value) => new WeekDays(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is WeekDays other && Equals(other);
        /// <inheritdoc />
        public bool Equals(WeekDays other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
