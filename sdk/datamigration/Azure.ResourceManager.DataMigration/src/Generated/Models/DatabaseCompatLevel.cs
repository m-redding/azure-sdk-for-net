// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.DataMigration.Models
{
    /// <summary> An enumeration of SQL Server database compatibility levels. </summary>
    public readonly partial struct DatabaseCompatLevel : IEquatable<DatabaseCompatLevel>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DatabaseCompatLevel"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public DatabaseCompatLevel(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string CompatLevel80Value = "CompatLevel80";
        private const string CompatLevel90Value = "CompatLevel90";
        private const string CompatLevel100Value = "CompatLevel100";
        private const string CompatLevel110Value = "CompatLevel110";
        private const string CompatLevel120Value = "CompatLevel120";
        private const string CompatLevel130Value = "CompatLevel130";
        private const string CompatLevel140Value = "CompatLevel140";

        /// <summary> CompatLevel80. </summary>
        public static DatabaseCompatLevel CompatLevel80 { get; } = new DatabaseCompatLevel(CompatLevel80Value);
        /// <summary> CompatLevel90. </summary>
        public static DatabaseCompatLevel CompatLevel90 { get; } = new DatabaseCompatLevel(CompatLevel90Value);
        /// <summary> CompatLevel100. </summary>
        public static DatabaseCompatLevel CompatLevel100 { get; } = new DatabaseCompatLevel(CompatLevel100Value);
        /// <summary> CompatLevel110. </summary>
        public static DatabaseCompatLevel CompatLevel110 { get; } = new DatabaseCompatLevel(CompatLevel110Value);
        /// <summary> CompatLevel120. </summary>
        public static DatabaseCompatLevel CompatLevel120 { get; } = new DatabaseCompatLevel(CompatLevel120Value);
        /// <summary> CompatLevel130. </summary>
        public static DatabaseCompatLevel CompatLevel130 { get; } = new DatabaseCompatLevel(CompatLevel130Value);
        /// <summary> CompatLevel140. </summary>
        public static DatabaseCompatLevel CompatLevel140 { get; } = new DatabaseCompatLevel(CompatLevel140Value);
        /// <summary> Determines if two <see cref="DatabaseCompatLevel"/> values are the same. </summary>
        public static bool operator ==(DatabaseCompatLevel left, DatabaseCompatLevel right) => left.Equals(right);
        /// <summary> Determines if two <see cref="DatabaseCompatLevel"/> values are not the same. </summary>
        public static bool operator !=(DatabaseCompatLevel left, DatabaseCompatLevel right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="DatabaseCompatLevel"/>. </summary>
        public static implicit operator DatabaseCompatLevel(string value) => new DatabaseCompatLevel(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is DatabaseCompatLevel other && Equals(other);
        /// <inheritdoc />
        public bool Equals(DatabaseCompatLevel other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
