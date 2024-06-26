// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.ManagedServiceIdentity.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Azure Resource properties.
    /// </summary>
    /// <remarks>
    /// Describes an Azure resource that is attached to an identity.
    /// </remarks>
    public partial class AzureResource
    {
        /// <summary>
        /// Initializes a new instance of the AzureResource class.
        /// </summary>
        public AzureResource()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the AzureResource class.
        /// </summary>
        /// <param name="id">The ID of this resource.</param>
        /// <param name="name">The name of this resource.</param>
        /// <param name="type">The type of this resource.</param>
        /// <param name="resourceGroup">The name of the resource group this
        /// resource belongs to.</param>
        /// <param name="subscriptionId">The ID of the subscription this
        /// resource belongs to.</param>
        /// <param name="subscriptionDisplayName">The name of the subscription
        /// this resource belongs to.</param>
        public AzureResource(string id = default(string), string name = default(string), string type = default(string), string resourceGroup = default(string), string subscriptionId = default(string), string subscriptionDisplayName = default(string))
        {
            Id = id;
            Name = name;
            Type = type;
            ResourceGroup = resourceGroup;
            SubscriptionId = subscriptionId;
            SubscriptionDisplayName = subscriptionDisplayName;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets the ID of this resource.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; private set; }

        /// <summary>
        /// Gets the name of this resource.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        /// <summary>
        /// Gets the type of this resource.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; private set; }

        /// <summary>
        /// Gets the name of the resource group this resource belongs to.
        /// </summary>
        [JsonProperty(PropertyName = "resourceGroup")]
        public string ResourceGroup { get; private set; }

        /// <summary>
        /// Gets the ID of the subscription this resource belongs to.
        /// </summary>
        [JsonProperty(PropertyName = "subscriptionId")]
        public string SubscriptionId { get; private set; }

        /// <summary>
        /// Gets the name of the subscription this resource belongs to.
        /// </summary>
        [JsonProperty(PropertyName = "subscriptionDisplayName")]
        public string SubscriptionDisplayName { get; private set; }

    }
}
