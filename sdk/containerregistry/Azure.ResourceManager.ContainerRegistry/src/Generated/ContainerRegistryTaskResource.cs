// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ContainerRegistry.Models;

namespace Azure.ResourceManager.ContainerRegistry
{
    /// <summary>
    /// A Class representing a ContainerRegistryTask along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="ContainerRegistryTaskResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetContainerRegistryTaskResource method.
    /// Otherwise you can get one from its parent resource <see cref="ContainerRegistryResource"/> using the GetContainerRegistryTask method.
    /// </summary>
    public partial class ContainerRegistryTaskResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="ContainerRegistryTaskResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="registryName"> The registryName. </param>
        /// <param name="taskName"> The taskName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string taskName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _containerRegistryTaskTasksClientDiagnostics;
        private readonly TasksRestOperations _containerRegistryTaskTasksRestClient;
        private readonly ContainerRegistryTaskData _data;

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.ContainerRegistry/registries/tasks";

        /// <summary> Initializes a new instance of the <see cref="ContainerRegistryTaskResource"/> class for mocking. </summary>
        protected ContainerRegistryTaskResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ContainerRegistryTaskResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal ContainerRegistryTaskResource(ArmClient client, ContainerRegistryTaskData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="ContainerRegistryTaskResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ContainerRegistryTaskResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _containerRegistryTaskTasksClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.ContainerRegistry", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string containerRegistryTaskTasksApiVersion);
            _containerRegistryTaskTasksRestClient = new TasksRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, containerRegistryTaskTasksApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual ContainerRegistryTaskData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Get the properties of a specified task.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Tasks_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-03-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerRegistryTaskResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ContainerRegistryTaskResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _containerRegistryTaskTasksClientDiagnostics.CreateScope("ContainerRegistryTaskResource.Get");
            scope.Start();
            try
            {
                var response = await _containerRegistryTaskTasksRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ContainerRegistryTaskResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the properties of a specified task.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Tasks_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-03-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerRegistryTaskResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ContainerRegistryTaskResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _containerRegistryTaskTasksClientDiagnostics.CreateScope("ContainerRegistryTaskResource.Get");
            scope.Start();
            try
            {
                var response = _containerRegistryTaskTasksRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ContainerRegistryTaskResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a specified task.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Tasks_Delete</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-03-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerRegistryTaskResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _containerRegistryTaskTasksClientDiagnostics.CreateScope("ContainerRegistryTaskResource.Delete");
            scope.Start();
            try
            {
                var response = await _containerRegistryTaskTasksRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var uri = _containerRegistryTaskTasksRestClient.CreateDeleteRequestUri(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name);
                var rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new ContainerRegistryArmOperation(response, rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a specified task.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Tasks_Delete</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-03-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerRegistryTaskResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _containerRegistryTaskTasksClientDiagnostics.CreateScope("ContainerRegistryTaskResource.Delete");
            scope.Start();
            try
            {
                var response = _containerRegistryTaskTasksRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var uri = _containerRegistryTaskTasksRestClient.CreateDeleteRequestUri(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name);
                var rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new ContainerRegistryArmOperation(response, rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates a task with the specified parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Tasks_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-03-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerRegistryTaskResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> The parameters for updating a task. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual async Task<Response<ContainerRegistryTaskResource>> UpdateAsync(ContainerRegistryTaskPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using var scope = _containerRegistryTaskTasksClientDiagnostics.CreateScope("ContainerRegistryTaskResource.Update");
            scope.Start();
            try
            {
                var response = await _containerRegistryTaskTasksRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, patch, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ContainerRegistryTaskResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates a task with the specified parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Tasks_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-03-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerRegistryTaskResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> The parameters for updating a task. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual Response<ContainerRegistryTaskResource> Update(ContainerRegistryTaskPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using var scope = _containerRegistryTaskTasksClientDiagnostics.CreateScope("ContainerRegistryTaskResource.Update");
            scope.Start();
            try
            {
                var response = _containerRegistryTaskTasksRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, patch, cancellationToken);
                return Response.FromValue(new ContainerRegistryTaskResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Returns a task with extended information that includes all secrets.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}/listDetails</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Tasks_GetDetails</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-03-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerRegistryTaskResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ContainerRegistryTaskResource>> GetDetailsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _containerRegistryTaskTasksClientDiagnostics.CreateScope("ContainerRegistryTaskResource.GetDetails");
            scope.Start();
            try
            {
                var response = await _containerRegistryTaskTasksRestClient.GetDetailsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ContainerRegistryTaskResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Returns a task with extended information that includes all secrets.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}/listDetails</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Tasks_GetDetails</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-03-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerRegistryTaskResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ContainerRegistryTaskResource> GetDetails(CancellationToken cancellationToken = default)
        {
            using var scope = _containerRegistryTaskTasksClientDiagnostics.CreateScope("ContainerRegistryTaskResource.GetDetails");
            scope.Start();
            try
            {
                var response = _containerRegistryTaskTasksRestClient.GetDetails(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                return Response.FromValue(new ContainerRegistryTaskResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Tasks_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-03-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerRegistryTaskResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual async Task<Response<ContainerRegistryTaskResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _containerRegistryTaskTasksClientDiagnostics.CreateScope("ContainerRegistryTaskResource.AddTag");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues[key] = value;
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalResponse = await _containerRegistryTaskTasksRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new ContainerRegistryTaskResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    var patch = new ContainerRegistryTaskPatch();
                    foreach (var tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags[key] = value;
                    var result = await UpdateAsync(patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return result;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Tasks_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-03-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerRegistryTaskResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual Response<ContainerRegistryTaskResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _containerRegistryTaskTasksClientDiagnostics.CreateScope("ContainerRegistryTaskResource.AddTag");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues[key] = value;
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                    var originalResponse = _containerRegistryTaskTasksRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                    return Response.FromValue(new ContainerRegistryTaskResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = Get(cancellationToken: cancellationToken).Value.Data;
                    var patch = new ContainerRegistryTaskPatch();
                    foreach (var tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags[key] = value;
                    var result = Update(patch, cancellationToken: cancellationToken);
                    return result;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Tasks_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-03-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerRegistryTaskResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual async Task<Response<ContainerRegistryTaskResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _containerRegistryTaskTasksClientDiagnostics.CreateScope("ContainerRegistryTaskResource.SetTags");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    await GetTagResource().DeleteAsync(WaitUntil.Completed, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalResponse = await _containerRegistryTaskTasksRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new ContainerRegistryTaskResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    var patch = new ContainerRegistryTaskPatch();
                    patch.Tags.ReplaceWith(tags);
                    var result = await UpdateAsync(patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return result;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Tasks_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-03-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerRegistryTaskResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual Response<ContainerRegistryTaskResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _containerRegistryTaskTasksClientDiagnostics.CreateScope("ContainerRegistryTaskResource.SetTags");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    GetTagResource().Delete(WaitUntil.Completed, cancellationToken: cancellationToken);
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                    var originalResponse = _containerRegistryTaskTasksRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                    return Response.FromValue(new ContainerRegistryTaskResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = Get(cancellationToken: cancellationToken).Value.Data;
                    var patch = new ContainerRegistryTaskPatch();
                    patch.Tags.ReplaceWith(tags);
                    var result = Update(patch, cancellationToken: cancellationToken);
                    return result;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Tasks_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-03-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerRegistryTaskResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual async Task<Response<ContainerRegistryTaskResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _containerRegistryTaskTasksClientDiagnostics.CreateScope("ContainerRegistryTaskResource.RemoveTag");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues.Remove(key);
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalResponse = await _containerRegistryTaskTasksRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new ContainerRegistryTaskResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    var patch = new ContainerRegistryTaskPatch();
                    foreach (var tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags.Remove(key);
                    var result = await UpdateAsync(patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return result;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Tasks_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-03-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerRegistryTaskResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual Response<ContainerRegistryTaskResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _containerRegistryTaskTasksClientDiagnostics.CreateScope("ContainerRegistryTaskResource.RemoveTag");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues.Remove(key);
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                    var originalResponse = _containerRegistryTaskTasksRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                    return Response.FromValue(new ContainerRegistryTaskResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = Get(cancellationToken: cancellationToken).Value.Data;
                    var patch = new ContainerRegistryTaskPatch();
                    foreach (var tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags.Remove(key);
                    var result = Update(patch, cancellationToken: cancellationToken);
                    return result;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
