// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.AppComplianceAutomation.Models;

namespace Azure.ResourceManager.AppComplianceAutomation.Mocking
{
    /// <summary> A class to add extension methods to TenantResource. </summary>
    public partial class MockableAppComplianceAutomationTenantResource : ArmResource
    {
        private ClientDiagnostics _providerActionsClientDiagnostics;
        private ProviderActionsRestOperations _providerActionsRestClient;

        /// <summary> Initializes a new instance of the <see cref="MockableAppComplianceAutomationTenantResource"/> class for mocking. </summary>
        protected MockableAppComplianceAutomationTenantResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MockableAppComplianceAutomationTenantResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockableAppComplianceAutomationTenantResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics ProviderActionsClientDiagnostics => _providerActionsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.AppComplianceAutomation", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private ProviderActionsRestOperations ProviderActionsRestClient => _providerActionsRestClient ??= new ProviderActionsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of AppComplianceReportResources in the TenantResource. </summary>
        /// <returns> An object representing collection of AppComplianceReportResources and their operations over a AppComplianceReportResource. </returns>
        public virtual AppComplianceReportCollection GetAppComplianceReports()
        {
            return GetCachedClient(client => new AppComplianceReportCollection(client, Id));
        }

        /// <summary>
        /// Get the AppComplianceAutomation report and its properties.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AppComplianceAutomation/reports/{reportName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Report_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-06-27</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppComplianceReportResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="reportName"> Report Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="reportName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="reportName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<AppComplianceReportResource>> GetAppComplianceReportAsync(string reportName, CancellationToken cancellationToken = default)
        {
            return await GetAppComplianceReports().GetAsync(reportName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get the AppComplianceAutomation report and its properties.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AppComplianceAutomation/reports/{reportName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Report_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-06-27</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppComplianceReportResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="reportName"> Report Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="reportName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="reportName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<AppComplianceReportResource> GetAppComplianceReport(string reportName, CancellationToken cancellationToken = default)
        {
            return GetAppComplianceReports().Get(reportName, cancellationToken);
        }

        /// <summary>
        /// Check if the given name is available for a report.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AppComplianceAutomation/checkNameAvailability</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProviderActions_CheckNameAvailability</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-06-27</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content of the action request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<Response<AppComplianceReportNameAvailabilityResult>> CheckAppComplianceReportNameAvailabilityAsync(AppComplianceReportNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ProviderActionsClientDiagnostics.CreateScope("MockableAppComplianceAutomationTenantResource.CheckAppComplianceReportNameAvailability");
            scope.Start();
            try
            {
                var response = await ProviderActionsRestClient.CheckNameAvailabilityAsync(content, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Check if the given name is available for a report.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AppComplianceAutomation/checkNameAvailability</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProviderActions_CheckNameAvailability</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-06-27</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content of the action request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual Response<AppComplianceReportNameAvailabilityResult> CheckAppComplianceReportNameAvailability(AppComplianceReportNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ProviderActionsClientDiagnostics.CreateScope("MockableAppComplianceAutomationTenantResource.CheckAppComplianceReportNameAvailability");
            scope.Start();
            try
            {
                var response = ProviderActionsRestClient.CheckNameAvailability(content, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the count of reports.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AppComplianceAutomation/getCollectionCount</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProviderActions_GetCollectionCount</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-06-27</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content of the action request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<Response<ReportCollectionGetCountResult>> GetCollectionCountProviderActionAsync(ReportCollectionGetCountContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ProviderActionsClientDiagnostics.CreateScope("MockableAppComplianceAutomationTenantResource.GetCollectionCountProviderAction");
            scope.Start();
            try
            {
                var response = await ProviderActionsRestClient.GetCollectionCountAsync(content, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the count of reports.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AppComplianceAutomation/getCollectionCount</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProviderActions_GetCollectionCount</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-06-27</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content of the action request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual Response<ReportCollectionGetCountResult> GetCollectionCountProviderAction(ReportCollectionGetCountContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ProviderActionsClientDiagnostics.CreateScope("MockableAppComplianceAutomationTenantResource.GetCollectionCountProviderAction");
            scope.Start();
            try
            {
                var response = ProviderActionsRestClient.GetCollectionCount(content, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the resource overview status.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AppComplianceAutomation/getOverviewStatus</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProviderActions_GetOverviewStatus</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-06-27</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content of the action request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<Response<AppComplianceGetOverviewStatusResult>> GetOverviewStatusProviderActionAsync(AppComplianceGetOverviewStatusContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ProviderActionsClientDiagnostics.CreateScope("MockableAppComplianceAutomationTenantResource.GetOverviewStatusProviderAction");
            scope.Start();
            try
            {
                var response = await ProviderActionsRestClient.GetOverviewStatusAsync(content, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the resource overview status.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AppComplianceAutomation/getOverviewStatus</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProviderActions_GetOverviewStatus</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-06-27</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content of the action request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual Response<AppComplianceGetOverviewStatusResult> GetOverviewStatusProviderAction(AppComplianceGetOverviewStatusContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ProviderActionsClientDiagnostics.CreateScope("MockableAppComplianceAutomationTenantResource.GetOverviewStatusProviderAction");
            scope.Start();
            try
            {
                var response = ProviderActionsRestClient.GetOverviewStatus(content, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List the storage accounts which are in use by related reports
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AppComplianceAutomation/listInUseStorageAccounts</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProviderActions_ListInUseStorageAccounts</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-06-27</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content of the action request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<Response<ReportListInUseStorageAccountsResult>> GetInUseStorageAccountsProviderActionAsync(ReportListInUseStorageAccountsContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ProviderActionsClientDiagnostics.CreateScope("MockableAppComplianceAutomationTenantResource.GetInUseStorageAccountsProviderAction");
            scope.Start();
            try
            {
                var response = await ProviderActionsRestClient.ListInUseStorageAccountsAsync(content, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List the storage accounts which are in use by related reports
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AppComplianceAutomation/listInUseStorageAccounts</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProviderActions_ListInUseStorageAccounts</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-06-27</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content of the action request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual Response<ReportListInUseStorageAccountsResult> GetInUseStorageAccountsProviderAction(ReportListInUseStorageAccountsContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ProviderActionsClientDiagnostics.CreateScope("MockableAppComplianceAutomationTenantResource.GetInUseStorageAccountsProviderAction");
            scope.Start();
            try
            {
                var response = ProviderActionsRestClient.ListInUseStorageAccounts(content, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Onboard given subscriptions to Microsoft.AppComplianceAutomation provider.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AppComplianceAutomation/onboard</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProviderActions_Onboard</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-06-27</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content of the action request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<ArmOperation<AppComplianceOnboardResult>> OnboardProviderActionAsync(WaitUntil waitUntil, AppComplianceOnboardContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ProviderActionsClientDiagnostics.CreateScope("MockableAppComplianceAutomationTenantResource.OnboardProviderAction");
            scope.Start();
            try
            {
                var response = await ProviderActionsRestClient.OnboardAsync(content, cancellationToken).ConfigureAwait(false);
                var operation = new AppComplianceAutomationArmOperation<AppComplianceOnboardResult>(new AppComplianceOnboardResultOperationSource(), ProviderActionsClientDiagnostics, Pipeline, ProviderActionsRestClient.CreateOnboardRequest(content).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Onboard given subscriptions to Microsoft.AppComplianceAutomation provider.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AppComplianceAutomation/onboard</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProviderActions_Onboard</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-06-27</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content of the action request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual ArmOperation<AppComplianceOnboardResult> OnboardProviderAction(WaitUntil waitUntil, AppComplianceOnboardContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ProviderActionsClientDiagnostics.CreateScope("MockableAppComplianceAutomationTenantResource.OnboardProviderAction");
            scope.Start();
            try
            {
                var response = ProviderActionsRestClient.Onboard(content, cancellationToken);
                var operation = new AppComplianceAutomationArmOperation<AppComplianceOnboardResult>(new AppComplianceOnboardResultOperationSource(), ProviderActionsClientDiagnostics, Pipeline, ProviderActionsRestClient.CreateOnboardRequest(content).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Trigger quick evaluation for the given subscriptions.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AppComplianceAutomation/triggerEvaluation</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProviderActions_TriggerEvaluation</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-06-27</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content of the action request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<ArmOperation<TriggerEvaluationResult>> TriggerEvaluationProviderActionAsync(WaitUntil waitUntil, TriggerEvaluationContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ProviderActionsClientDiagnostics.CreateScope("MockableAppComplianceAutomationTenantResource.TriggerEvaluationProviderAction");
            scope.Start();
            try
            {
                var response = await ProviderActionsRestClient.TriggerEvaluationAsync(content, cancellationToken).ConfigureAwait(false);
                var operation = new AppComplianceAutomationArmOperation<TriggerEvaluationResult>(new TriggerEvaluationResultOperationSource(), ProviderActionsClientDiagnostics, Pipeline, ProviderActionsRestClient.CreateTriggerEvaluationRequest(content).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Trigger quick evaluation for the given subscriptions.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AppComplianceAutomation/triggerEvaluation</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProviderActions_TriggerEvaluation</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-06-27</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content of the action request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual ArmOperation<TriggerEvaluationResult> TriggerEvaluationProviderAction(WaitUntil waitUntil, TriggerEvaluationContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ProviderActionsClientDiagnostics.CreateScope("MockableAppComplianceAutomationTenantResource.TriggerEvaluationProviderAction");
            scope.Start();
            try
            {
                var response = ProviderActionsRestClient.TriggerEvaluation(content, cancellationToken);
                var operation = new AppComplianceAutomationArmOperation<TriggerEvaluationResult>(new TriggerEvaluationResultOperationSource(), ProviderActionsClientDiagnostics, Pipeline, ProviderActionsRestClient.CreateTriggerEvaluationRequest(content).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
