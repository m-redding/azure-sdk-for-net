// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ApplicationInsights.Models;

namespace Azure.ResourceManager.ApplicationInsights.Mocking
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    public partial class MockableApplicationInsightsSubscriptionResource : ArmResource
    {
        private ClientDiagnostics _applicationInsightsComponentComponentsClientDiagnostics;
        private ComponentsRestOperations _applicationInsightsComponentComponentsRestClient;
        private ClientDiagnostics _applicationInsightsWebTestWebTestsClientDiagnostics;
        private WebTestsRestOperations _applicationInsightsWebTestWebTestsRestClient;
        private ClientDiagnostics _applicationInsightsWorkbookWorkbooksClientDiagnostics;
        private WorkbooksRestOperations _applicationInsightsWorkbookWorkbooksRestClient;

        /// <summary> Initializes a new instance of the <see cref="MockableApplicationInsightsSubscriptionResource"/> class for mocking. </summary>
        protected MockableApplicationInsightsSubscriptionResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MockableApplicationInsightsSubscriptionResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockableApplicationInsightsSubscriptionResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics ApplicationInsightsComponentComponentsClientDiagnostics => _applicationInsightsComponentComponentsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.ApplicationInsights", ApplicationInsightsComponentResource.ResourceType.Namespace, Diagnostics);
        private ComponentsRestOperations ApplicationInsightsComponentComponentsRestClient => _applicationInsightsComponentComponentsRestClient ??= new ComponentsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(ApplicationInsightsComponentResource.ResourceType));
        private ClientDiagnostics ApplicationInsightsWebTestWebTestsClientDiagnostics => _applicationInsightsWebTestWebTestsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.ApplicationInsights", ApplicationInsightsWebTestResource.ResourceType.Namespace, Diagnostics);
        private WebTestsRestOperations ApplicationInsightsWebTestWebTestsRestClient => _applicationInsightsWebTestWebTestsRestClient ??= new WebTestsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(ApplicationInsightsWebTestResource.ResourceType));
        private ClientDiagnostics ApplicationInsightsWorkbookWorkbooksClientDiagnostics => _applicationInsightsWorkbookWorkbooksClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.ApplicationInsights", ApplicationInsightsWorkbookResource.ResourceType.Namespace, Diagnostics);
        private WorkbooksRestOperations ApplicationInsightsWorkbookWorkbooksRestClient => _applicationInsightsWorkbookWorkbooksRestClient ??= new WorkbooksRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(ApplicationInsightsWorkbookResource.ResourceType));

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary>
        /// Gets a list of all Application Insights components within a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Insights/components</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Components_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-02-02</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ApplicationInsightsComponentResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApplicationInsightsComponentResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApplicationInsightsComponentResource> GetApplicationInsightsComponentsAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ApplicationInsightsComponentComponentsRestClient.CreateListRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => ApplicationInsightsComponentComponentsRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new ApplicationInsightsComponentResource(Client, ApplicationInsightsComponentData.DeserializeApplicationInsightsComponentData(e)), ApplicationInsightsComponentComponentsClientDiagnostics, Pipeline, "MockableApplicationInsightsSubscriptionResource.GetApplicationInsightsComponents", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets a list of all Application Insights components within a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Insights/components</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Components_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-02-02</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ApplicationInsightsComponentResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApplicationInsightsComponentResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApplicationInsightsComponentResource> GetApplicationInsightsComponents(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ApplicationInsightsComponentComponentsRestClient.CreateListRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => ApplicationInsightsComponentComponentsRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new ApplicationInsightsComponentResource(Client, ApplicationInsightsComponentData.DeserializeApplicationInsightsComponentData(e)), ApplicationInsightsComponentComponentsClientDiagnostics, Pipeline, "MockableApplicationInsightsSubscriptionResource.GetApplicationInsightsComponents", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Get all Application Insights web test definitions for the specified subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Insights/webtests</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebTests_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-06-15</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ApplicationInsightsWebTestResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApplicationInsightsWebTestResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApplicationInsightsWebTestResource> GetApplicationInsightsWebTestsAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ApplicationInsightsWebTestWebTestsRestClient.CreateListRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => ApplicationInsightsWebTestWebTestsRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new ApplicationInsightsWebTestResource(Client, ApplicationInsightsWebTestData.DeserializeApplicationInsightsWebTestData(e)), ApplicationInsightsWebTestWebTestsClientDiagnostics, Pipeline, "MockableApplicationInsightsSubscriptionResource.GetApplicationInsightsWebTests", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Get all Application Insights web test definitions for the specified subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Insights/webtests</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebTests_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-06-15</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ApplicationInsightsWebTestResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApplicationInsightsWebTestResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApplicationInsightsWebTestResource> GetApplicationInsightsWebTests(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ApplicationInsightsWebTestWebTestsRestClient.CreateListRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => ApplicationInsightsWebTestWebTestsRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new ApplicationInsightsWebTestResource(Client, ApplicationInsightsWebTestData.DeserializeApplicationInsightsWebTestData(e)), ApplicationInsightsWebTestWebTestsClientDiagnostics, Pipeline, "MockableApplicationInsightsSubscriptionResource.GetApplicationInsightsWebTests", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Get all Workbooks defined within a specified subscription and category.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Insights/workbooks</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Workbooks_ListBySubscription</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ApplicationInsightsWorkbookResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="category"> Category of workbook to return. </param>
        /// <param name="tags"> Tags presents on each workbook returned. </param>
        /// <param name="canFetchContent"> Flag indicating whether or not to return the full content for each applicable workbook. If false, only return summary content for workbooks. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApplicationInsightsWorkbookResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApplicationInsightsWorkbookResource> GetApplicationInsightsWorkbooksAsync(WorkbookCategoryType category, IEnumerable<string> tags = null, bool? canFetchContent = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ApplicationInsightsWorkbookWorkbooksRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId, category, tags, canFetchContent);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => ApplicationInsightsWorkbookWorkbooksRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId, category, tags, canFetchContent);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new ApplicationInsightsWorkbookResource(Client, ApplicationInsightsWorkbookData.DeserializeApplicationInsightsWorkbookData(e)), ApplicationInsightsWorkbookWorkbooksClientDiagnostics, Pipeline, "MockableApplicationInsightsSubscriptionResource.GetApplicationInsightsWorkbooks", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Get all Workbooks defined within a specified subscription and category.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Insights/workbooks</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Workbooks_ListBySubscription</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ApplicationInsightsWorkbookResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="category"> Category of workbook to return. </param>
        /// <param name="tags"> Tags presents on each workbook returned. </param>
        /// <param name="canFetchContent"> Flag indicating whether or not to return the full content for each applicable workbook. If false, only return summary content for workbooks. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApplicationInsightsWorkbookResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApplicationInsightsWorkbookResource> GetApplicationInsightsWorkbooks(WorkbookCategoryType category, IEnumerable<string> tags = null, bool? canFetchContent = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ApplicationInsightsWorkbookWorkbooksRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId, category, tags, canFetchContent);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => ApplicationInsightsWorkbookWorkbooksRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId, category, tags, canFetchContent);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new ApplicationInsightsWorkbookResource(Client, ApplicationInsightsWorkbookData.DeserializeApplicationInsightsWorkbookData(e)), ApplicationInsightsWorkbookWorkbooksClientDiagnostics, Pipeline, "MockableApplicationInsightsSubscriptionResource.GetApplicationInsightsWorkbooks", "value", "nextLink", cancellationToken);
        }
    }
}
