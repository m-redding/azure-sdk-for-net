// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.MongoDBAtlas.Mocking;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.MongoDBAtlas
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.MongoDBAtlas. </summary>
    public static partial class MongoDBAtlasExtensions
    {
        private static MockableMongoDBAtlasArmClient GetMockableMongoDBAtlasArmClient(ArmClient client)
        {
            return client.GetCachedClient(client0 => new MockableMongoDBAtlasArmClient(client0));
        }

        private static MockableMongoDBAtlasResourceGroupResource GetMockableMongoDBAtlasResourceGroupResource(ArmResource resource)
        {
            return resource.GetCachedClient(client => new MockableMongoDBAtlasResourceGroupResource(client, resource.Id));
        }

        private static MockableMongoDBAtlasSubscriptionResource GetMockableMongoDBAtlasSubscriptionResource(ArmResource resource)
        {
            return resource.GetCachedClient(client => new MockableMongoDBAtlasSubscriptionResource(client, resource.Id));
        }

        /// <summary>
        /// Gets an object representing a <see cref="MongoDBAtlasOrganizationResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="MongoDBAtlasOrganizationResource.CreateResourceIdentifier" /> to create a <see cref="MongoDBAtlasOrganizationResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMongoDBAtlasArmClient.GetMongoDBAtlasOrganizationResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="MongoDBAtlasOrganizationResource"/> object. </returns>
        public static MongoDBAtlasOrganizationResource GetMongoDBAtlasOrganizationResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableMongoDBAtlasArmClient(client).GetMongoDBAtlasOrganizationResource(id);
        }

        /// <summary>
        /// Gets a collection of MongoDBAtlasOrganizationResources in the ResourceGroupResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMongoDBAtlasResourceGroupResource.GetMongoDBAtlasOrganizations()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        /// <returns> An object representing collection of MongoDBAtlasOrganizationResources and their operations over a MongoDBAtlasOrganizationResource. </returns>
        public static MongoDBAtlasOrganizationCollection GetMongoDBAtlasOrganizations(this ResourceGroupResource resourceGroupResource)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableMongoDBAtlasResourceGroupResource(resourceGroupResource).GetMongoDBAtlasOrganizations();
        }

        /// <summary>
        /// Get a OrganizationResource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/MongoDB.Atlas/organizations/{organizationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>OrganizationResource_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MongoDBAtlasOrganizationResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMongoDBAtlasResourceGroupResource.GetMongoDBAtlasOrganizationAsync(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="organizationName"> Name of the Organization resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="organizationName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="organizationName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<MongoDBAtlasOrganizationResource>> GetMongoDBAtlasOrganizationAsync(this ResourceGroupResource resourceGroupResource, string organizationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return await GetMockableMongoDBAtlasResourceGroupResource(resourceGroupResource).GetMongoDBAtlasOrganizationAsync(organizationName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a OrganizationResource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/MongoDB.Atlas/organizations/{organizationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>OrganizationResource_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MongoDBAtlasOrganizationResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMongoDBAtlasResourceGroupResource.GetMongoDBAtlasOrganization(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="organizationName"> Name of the Organization resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="organizationName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="organizationName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Response<MongoDBAtlasOrganizationResource> GetMongoDBAtlasOrganization(this ResourceGroupResource resourceGroupResource, string organizationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableMongoDBAtlasResourceGroupResource(resourceGroupResource).GetMongoDBAtlasOrganization(organizationName, cancellationToken);
        }

        /// <summary>
        /// List OrganizationResource resources by subscription ID
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/MongoDB.Atlas/organizations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>OrganizationResource_ListBySubscription</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MongoDBAtlasOrganizationResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMongoDBAtlasSubscriptionResource.GetMongoDBAtlasOrganizations(CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> An async collection of <see cref="MongoDBAtlasOrganizationResource"/> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<MongoDBAtlasOrganizationResource> GetMongoDBAtlasOrganizationsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableMongoDBAtlasSubscriptionResource(subscriptionResource).GetMongoDBAtlasOrganizationsAsync(cancellationToken);
        }

        /// <summary>
        /// List OrganizationResource resources by subscription ID
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/MongoDB.Atlas/organizations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>OrganizationResource_ListBySubscription</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MongoDBAtlasOrganizationResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMongoDBAtlasSubscriptionResource.GetMongoDBAtlasOrganizations(CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="MongoDBAtlasOrganizationResource"/> that may take multiple service requests to iterate over. </returns>
        public static Pageable<MongoDBAtlasOrganizationResource> GetMongoDBAtlasOrganizations(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableMongoDBAtlasSubscriptionResource(subscriptionResource).GetMongoDBAtlasOrganizations(cancellationToken);
        }
    }
}
