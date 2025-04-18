// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.ContainerRegistry.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ContainerRegistry.Samples
{
    public partial class Sample_ContainerRegistryArchiveResource
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_ArchiveGet()
        {
            // Generated from example definition: specification/containerregistry/resource-manager/Microsoft.ContainerRegistry/preview/2025-03-01-preview/examples/ArchiveGet.json
            // this example is just showing the usage of "Archives_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ContainerRegistryArchiveResource created on azure
            // for more information of creating ContainerRegistryArchiveResource, please refer to the document of ContainerRegistryArchiveResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "myResourceGroup";
            string registryName = "myRegistry";
            string packageType = "myPackageType";
            string archiveName = "myArchiveName";
            ResourceIdentifier containerRegistryArchiveResourceId = ContainerRegistryArchiveResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, registryName, packageType, archiveName);
            ContainerRegistryArchiveResource containerRegistryArchive = client.GetContainerRegistryArchiveResource(containerRegistryArchiveResourceId);

            // invoke the operation
            ContainerRegistryArchiveResource result = await containerRegistryArchive.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            ContainerRegistryArchiveData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Delete_ArchiveDelete()
        {
            // Generated from example definition: specification/containerregistry/resource-manager/Microsoft.ContainerRegistry/preview/2025-03-01-preview/examples/ArchiveDelete.json
            // this example is just showing the usage of "Archives_Delete" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ContainerRegistryArchiveResource created on azure
            // for more information of creating ContainerRegistryArchiveResource, please refer to the document of ContainerRegistryArchiveResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "myResourceGroup";
            string registryName = "myRegistry";
            string packageType = "myPackageType";
            string archiveName = "myArchiveName";
            ResourceIdentifier containerRegistryArchiveResourceId = ContainerRegistryArchiveResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, registryName, packageType, archiveName);
            ContainerRegistryArchiveResource containerRegistryArchive = client.GetContainerRegistryArchiveResource(containerRegistryArchiveResourceId);

            // invoke the operation
            await containerRegistryArchive.DeleteAsync(WaitUntil.Completed);

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Update_ArchiveUpdate()
        {
            // Generated from example definition: specification/containerregistry/resource-manager/Microsoft.ContainerRegistry/preview/2025-03-01-preview/examples/ArchiveUpdate.json
            // this example is just showing the usage of "Archives_Update" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ContainerRegistryArchiveResource created on azure
            // for more information of creating ContainerRegistryArchiveResource, please refer to the document of ContainerRegistryArchiveResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "myResourceGroup";
            string registryName = "myRegistry";
            string packageType = "myPackageType";
            string archiveName = "myArchiveName";
            ResourceIdentifier containerRegistryArchiveResourceId = ContainerRegistryArchiveResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, registryName, packageType, archiveName);
            ContainerRegistryArchiveResource containerRegistryArchive = client.GetContainerRegistryArchiveResource(containerRegistryArchiveResourceId);

            // invoke the operation
            ContainerRegistryArchivePatch patch = new ContainerRegistryArchivePatch
            {
                PublishedVersion = "string",
            };
            ContainerRegistryArchiveResource result = await containerRegistryArchive.UpdateAsync(patch);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            ContainerRegistryArchiveData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }
    }
}
