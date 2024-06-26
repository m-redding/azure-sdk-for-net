// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.CosmosDB.Models
{
    /// <summary> Properties for Create or Update request for SqlDedicatedGatewayServiceResource. </summary>
    public partial class SqlDedicatedGatewayServiceResourceCreateUpdateProperties : ServiceResourceCreateUpdateProperties
    {
        /// <summary> Initializes a new instance of <see cref="SqlDedicatedGatewayServiceResourceCreateUpdateProperties"/>. </summary>
        public SqlDedicatedGatewayServiceResourceCreateUpdateProperties()
        {
            ServiceType = CosmosDBServiceType.SqlDedicatedGateway;
        }

        /// <summary> Initializes a new instance of <see cref="SqlDedicatedGatewayServiceResourceCreateUpdateProperties"/>. </summary>
        /// <param name="instanceSize"> Instance type for the service. </param>
        /// <param name="instanceCount"> Instance count for the service. </param>
        /// <param name="serviceType"> ServiceType for the service. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="dedicatedGatewayType"> DedicatedGatewayType for the service. </param>
        internal SqlDedicatedGatewayServiceResourceCreateUpdateProperties(CosmosDBServiceSize? instanceSize, int? instanceCount, CosmosDBServiceType serviceType, IDictionary<string, BinaryData> serializedAdditionalRawData, DedicatedGatewayType? dedicatedGatewayType) : base(instanceSize, instanceCount, serviceType, serializedAdditionalRawData)
        {
            DedicatedGatewayType = dedicatedGatewayType;
            ServiceType = serviceType;
        }

        /// <summary> DedicatedGatewayType for the service. </summary>
        [WirePath("dedicatedGatewayType")]
        public DedicatedGatewayType? DedicatedGatewayType { get; set; }
    }
}
