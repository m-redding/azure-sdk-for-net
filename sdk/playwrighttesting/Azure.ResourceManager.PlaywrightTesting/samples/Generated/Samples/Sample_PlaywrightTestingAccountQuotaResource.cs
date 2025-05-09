// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.PlaywrightTesting.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.PlaywrightTesting.Samples
{
    public partial class Sample_PlaywrightTestingAccountQuotaResource
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_AccountQuotasGet()
        {
            // Generated from example definition: 2024-12-01/AccountQuotas_Get.json
            // this example is just showing the usage of "AccountQuota_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this PlaywrightTestingAccountQuotaResource created on azure
            // for more information of creating PlaywrightTestingAccountQuotaResource, please refer to the document of PlaywrightTestingAccountQuotaResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "dummyrg";
            string accountName = "myPlaywrightAccount";
            PlaywrightTestingQuotaName quotaName = PlaywrightTestingQuotaName.ScalableExecution;
            ResourceIdentifier playwrightTestingAccountQuotaResourceId = PlaywrightTestingAccountQuotaResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName, quotaName);
            PlaywrightTestingAccountQuotaResource playwrightTestingAccountQuota = client.GetPlaywrightTestingAccountQuotaResource(playwrightTestingAccountQuotaResourceId);

            // invoke the operation
            PlaywrightTestingAccountQuotaResource result = await playwrightTestingAccountQuota.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            PlaywrightTestingAccountQuotaData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }
    }
}
