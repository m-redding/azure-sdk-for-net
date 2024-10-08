// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.ContainerRegistry.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ContainerRegistry
{
    /// <summary>
    /// A class representing the ContainerRegistryReplication data model.
    /// An object that represents a replication for a container registry.
    /// </summary>
    public partial class ContainerRegistryReplicationData : TrackedResourceData
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ContainerRegistryReplicationData"/>. </summary>
        /// <param name="location"> The location. </param>
        public ContainerRegistryReplicationData(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of <see cref="ContainerRegistryReplicationData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="provisioningState"> The provisioning state of the replication at the time the operation was called. </param>
        /// <param name="status"> The status of the replication at the time the operation was called. </param>
        /// <param name="isRegionEndpointEnabled"> Specifies whether the replication's regional endpoint is enabled. Requests will not be routed to a replication whose regional endpoint is disabled, however its data will continue to be synced with other replications. </param>
        /// <param name="zoneRedundancy"> Whether or not zone redundancy is enabled for this container registry replication. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ContainerRegistryReplicationData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ContainerRegistryProvisioningState? provisioningState, ContainerRegistryResourceStatus status, bool? isRegionEndpointEnabled, ContainerRegistryZoneRedundancy? zoneRedundancy, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData, tags, location)
        {
            ProvisioningState = provisioningState;
            Status = status;
            IsRegionEndpointEnabled = isRegionEndpointEnabled;
            ZoneRedundancy = zoneRedundancy;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ContainerRegistryReplicationData"/> for deserialization. </summary>
        internal ContainerRegistryReplicationData()
        {
        }

        /// <summary> The provisioning state of the replication at the time the operation was called. </summary>
        [WirePath("properties.provisioningState")]
        public ContainerRegistryProvisioningState? ProvisioningState { get; }
        /// <summary> The status of the replication at the time the operation was called. </summary>
        [WirePath("properties.status")]
        public ContainerRegistryResourceStatus Status { get; }
        /// <summary> Specifies whether the replication's regional endpoint is enabled. Requests will not be routed to a replication whose regional endpoint is disabled, however its data will continue to be synced with other replications. </summary>
        [WirePath("properties.regionEndpointEnabled")]
        public bool? IsRegionEndpointEnabled { get; set; }
        /// <summary> Whether or not zone redundancy is enabled for this container registry replication. </summary>
        [WirePath("properties.zoneRedundancy")]
        public ContainerRegistryZoneRedundancy? ZoneRedundancy { get; set; }
    }
}
