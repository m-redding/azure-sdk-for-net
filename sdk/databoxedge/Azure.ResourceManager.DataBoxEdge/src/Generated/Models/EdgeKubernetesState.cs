// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.DataBoxEdge.Models
{
    /// <summary> State of Kubernetes deployment. </summary>
    public readonly partial struct EdgeKubernetesState : IEquatable<EdgeKubernetesState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="EdgeKubernetesState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public EdgeKubernetesState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string InvalidValue = "Invalid";
        private const string CreatingValue = "Creating";
        private const string CreatedValue = "Created";
        private const string UpdatingValue = "Updating";
        private const string ReconfiguringValue = "Reconfiguring";
        private const string FailedValue = "Failed";
        private const string DeletingValue = "Deleting";

        /// <summary> Invalid. </summary>
        public static EdgeKubernetesState Invalid { get; } = new EdgeKubernetesState(InvalidValue);
        /// <summary> Creating. </summary>
        public static EdgeKubernetesState Creating { get; } = new EdgeKubernetesState(CreatingValue);
        /// <summary> Created. </summary>
        public static EdgeKubernetesState Created { get; } = new EdgeKubernetesState(CreatedValue);
        /// <summary> Updating. </summary>
        public static EdgeKubernetesState Updating { get; } = new EdgeKubernetesState(UpdatingValue);
        /// <summary> Reconfiguring. </summary>
        public static EdgeKubernetesState Reconfiguring { get; } = new EdgeKubernetesState(ReconfiguringValue);
        /// <summary> Failed. </summary>
        public static EdgeKubernetesState Failed { get; } = new EdgeKubernetesState(FailedValue);
        /// <summary> Deleting. </summary>
        public static EdgeKubernetesState Deleting { get; } = new EdgeKubernetesState(DeletingValue);
        /// <summary> Determines if two <see cref="EdgeKubernetesState"/> values are the same. </summary>
        public static bool operator ==(EdgeKubernetesState left, EdgeKubernetesState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="EdgeKubernetesState"/> values are not the same. </summary>
        public static bool operator !=(EdgeKubernetesState left, EdgeKubernetesState right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="EdgeKubernetesState"/>. </summary>
        public static implicit operator EdgeKubernetesState(string value) => new EdgeKubernetesState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is EdgeKubernetesState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(EdgeKubernetesState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
