// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityCenter.Samples
{
    public partial class Sample_SubscriptionSecurityTaskCollection
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_GetSecurityRecommendationTaskFromSecurityDataLocation()
        {
            // Generated from example definition: specification/security/resource-manager/Microsoft.Security/preview/2015-06-01-preview/examples/Tasks/GetTaskSubscriptionLocation_example.json
            // this example is just showing the usage of "Tasks_GetSubscriptionLevelTask" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SecurityCenterLocationResource created on azure
            // for more information of creating SecurityCenterLocationResource, please refer to the document of SecurityCenterLocationResource
            string subscriptionId = "20ff7fc3-e762-44dd-bd96-b71116dcdc23";
            AzureLocation ascLocation = new AzureLocation("westeurope");
            ResourceIdentifier securityCenterLocationResourceId = SecurityCenterLocationResource.CreateResourceIdentifier(subscriptionId, ascLocation);
            SecurityCenterLocationResource securityCenterLocation = client.GetSecurityCenterLocationResource(securityCenterLocationResourceId);

            // get the collection of this SubscriptionSecurityTaskResource
            SubscriptionSecurityTaskCollection collection = securityCenterLocation.GetSubscriptionSecurityTasks();

            // invoke the operation
            string taskName = "62609ee7-d0a5-8616-9fe4-1df5cca7758d";
            SubscriptionSecurityTaskResource result = await collection.GetAsync(taskName);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            SecurityTaskData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetAll_GetSecurityRecommendationsTasksFromSecurityDataLocation()
        {
            // Generated from example definition: specification/security/resource-manager/Microsoft.Security/preview/2015-06-01-preview/examples/Tasks/GetTasksSubscriptionLocation_example.json
            // this example is just showing the usage of "Tasks_ListByHomeRegion" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SecurityCenterLocationResource created on azure
            // for more information of creating SecurityCenterLocationResource, please refer to the document of SecurityCenterLocationResource
            string subscriptionId = "20ff7fc3-e762-44dd-bd96-b71116dcdc23";
            AzureLocation ascLocation = new AzureLocation("westeurope");
            ResourceIdentifier securityCenterLocationResourceId = SecurityCenterLocationResource.CreateResourceIdentifier(subscriptionId, ascLocation);
            SecurityCenterLocationResource securityCenterLocation = client.GetSecurityCenterLocationResource(securityCenterLocationResourceId);

            // get the collection of this SubscriptionSecurityTaskResource
            SubscriptionSecurityTaskCollection collection = securityCenterLocation.GetSubscriptionSecurityTasks();

            // invoke the operation and iterate over the result
            await foreach (SubscriptionSecurityTaskResource item in collection.GetAllAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                SecurityTaskData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Exists_GetSecurityRecommendationTaskFromSecurityDataLocation()
        {
            // Generated from example definition: specification/security/resource-manager/Microsoft.Security/preview/2015-06-01-preview/examples/Tasks/GetTaskSubscriptionLocation_example.json
            // this example is just showing the usage of "Tasks_GetSubscriptionLevelTask" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SecurityCenterLocationResource created on azure
            // for more information of creating SecurityCenterLocationResource, please refer to the document of SecurityCenterLocationResource
            string subscriptionId = "20ff7fc3-e762-44dd-bd96-b71116dcdc23";
            AzureLocation ascLocation = new AzureLocation("westeurope");
            ResourceIdentifier securityCenterLocationResourceId = SecurityCenterLocationResource.CreateResourceIdentifier(subscriptionId, ascLocation);
            SecurityCenterLocationResource securityCenterLocation = client.GetSecurityCenterLocationResource(securityCenterLocationResourceId);

            // get the collection of this SubscriptionSecurityTaskResource
            SubscriptionSecurityTaskCollection collection = securityCenterLocation.GetSubscriptionSecurityTasks();

            // invoke the operation
            string taskName = "62609ee7-d0a5-8616-9fe4-1df5cca7758d";
            bool result = await collection.ExistsAsync(taskName);

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetIfExists_GetSecurityRecommendationTaskFromSecurityDataLocation()
        {
            // Generated from example definition: specification/security/resource-manager/Microsoft.Security/preview/2015-06-01-preview/examples/Tasks/GetTaskSubscriptionLocation_example.json
            // this example is just showing the usage of "Tasks_GetSubscriptionLevelTask" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SecurityCenterLocationResource created on azure
            // for more information of creating SecurityCenterLocationResource, please refer to the document of SecurityCenterLocationResource
            string subscriptionId = "20ff7fc3-e762-44dd-bd96-b71116dcdc23";
            AzureLocation ascLocation = new AzureLocation("westeurope");
            ResourceIdentifier securityCenterLocationResourceId = SecurityCenterLocationResource.CreateResourceIdentifier(subscriptionId, ascLocation);
            SecurityCenterLocationResource securityCenterLocation = client.GetSecurityCenterLocationResource(securityCenterLocationResourceId);

            // get the collection of this SubscriptionSecurityTaskResource
            SubscriptionSecurityTaskCollection collection = securityCenterLocation.GetSubscriptionSecurityTasks();

            // invoke the operation
            string taskName = "62609ee7-d0a5-8616-9fe4-1df5cca7758d";
            NullableResponse<SubscriptionSecurityTaskResource> response = await collection.GetIfExistsAsync(taskName);
            SubscriptionSecurityTaskResource result = response.HasValue ? response.Value : null;

            if (result == null)
            {
                Console.WriteLine("Succeeded with null as result");
            }
            else
            {
                // the variable result is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                SecurityTaskData resourceData = result.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }
        }
    }
}
