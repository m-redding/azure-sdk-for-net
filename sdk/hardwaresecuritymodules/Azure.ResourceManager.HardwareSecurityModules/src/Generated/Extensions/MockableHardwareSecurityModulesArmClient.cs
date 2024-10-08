// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.HardwareSecurityModules.Mocking
{
    /// <summary> A class to add extension methods to ArmClient. </summary>
    public partial class MockableHardwareSecurityModulesArmClient : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="MockableHardwareSecurityModulesArmClient"/> class for mocking. </summary>
        protected MockableHardwareSecurityModulesArmClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MockableHardwareSecurityModulesArmClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockableHardwareSecurityModulesArmClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        internal MockableHardwareSecurityModulesArmClient(ArmClient client) : this(client, ResourceIdentifier.Root)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary>
        /// Gets an object representing a <see cref="CloudHsmClusterResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="CloudHsmClusterResource.CreateResourceIdentifier" /> to create a <see cref="CloudHsmClusterResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="CloudHsmClusterResource"/> object. </returns>
        public virtual CloudHsmClusterResource GetCloudHsmClusterResource(ResourceIdentifier id)
        {
            CloudHsmClusterResource.ValidateResourceId(id);
            return new CloudHsmClusterResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="CloudHsmClusterPrivateEndpointConnectionResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="CloudHsmClusterPrivateEndpointConnectionResource.CreateResourceIdentifier" /> to create a <see cref="CloudHsmClusterPrivateEndpointConnectionResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="CloudHsmClusterPrivateEndpointConnectionResource"/> object. </returns>
        public virtual CloudHsmClusterPrivateEndpointConnectionResource GetCloudHsmClusterPrivateEndpointConnectionResource(ResourceIdentifier id)
        {
            CloudHsmClusterPrivateEndpointConnectionResource.ValidateResourceId(id);
            return new CloudHsmClusterPrivateEndpointConnectionResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="DedicatedHsmResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="DedicatedHsmResource.CreateResourceIdentifier" /> to create a <see cref="DedicatedHsmResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DedicatedHsmResource"/> object. </returns>
        public virtual DedicatedHsmResource GetDedicatedHsmResource(ResourceIdentifier id)
        {
            DedicatedHsmResource.ValidateResourceId(id);
            return new DedicatedHsmResource(Client, id);
        }
    }
}
