// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.HybridContainerService.Models
{
    /// <summary> If not specified, the default is 'random'. See [expanders](https://github.com/kubernetes/autoscaler/blob/master/cluster-autoscaler/FAQ.md#what-are-expanders) for more information. </summary>
    public readonly partial struct HybridContainerServiceExpander : IEquatable<HybridContainerServiceExpander>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="HybridContainerServiceExpander"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public HybridContainerServiceExpander(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string LeastWasteValue = "least-waste";
        private const string MostPodsValue = "most-pods";
        private const string PriorityValue = "priority";
        private const string RandomValue = "random";

        /// <summary> Selects the node group that will have the least idle CPU (if tied, unused memory) after scale-up. This is useful when you have different classes of nodes, for example, high CPU or high memory nodes, and only want to expand those when there are pending pods that need a lot of those resources. </summary>
        public static HybridContainerServiceExpander LeastWaste { get; } = new HybridContainerServiceExpander(LeastWasteValue);
        /// <summary> Selects the node group that would be able to schedule the most pods when scaling up. This is useful when you are using nodeSelector to make sure certain pods land on certain nodes. Note that this won't cause the autoscaler to select bigger nodes vs. smaller, as it can add multiple smaller nodes at once. </summary>
        public static HybridContainerServiceExpander MostPods { get; } = new HybridContainerServiceExpander(MostPodsValue);
        /// <summary> Selects the node group that has the highest priority assigned by the user. It's configuration is described in more details [here](https://github.com/kubernetes/autoscaler/blob/master/cluster-autoscaler/expander/priority/readme.md). </summary>
        public static HybridContainerServiceExpander Priority { get; } = new HybridContainerServiceExpander(PriorityValue);
        /// <summary> Used when you don't have a particular need for the node groups to scale differently. </summary>
        public static HybridContainerServiceExpander Random { get; } = new HybridContainerServiceExpander(RandomValue);
        /// <summary> Determines if two <see cref="HybridContainerServiceExpander"/> values are the same. </summary>
        public static bool operator ==(HybridContainerServiceExpander left, HybridContainerServiceExpander right) => left.Equals(right);
        /// <summary> Determines if two <see cref="HybridContainerServiceExpander"/> values are not the same. </summary>
        public static bool operator !=(HybridContainerServiceExpander left, HybridContainerServiceExpander right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="HybridContainerServiceExpander"/>. </summary>
        public static implicit operator HybridContainerServiceExpander(string value) => new HybridContainerServiceExpander(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is HybridContainerServiceExpander other && Equals(other);
        /// <inheritdoc />
        public bool Equals(HybridContainerServiceExpander other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
