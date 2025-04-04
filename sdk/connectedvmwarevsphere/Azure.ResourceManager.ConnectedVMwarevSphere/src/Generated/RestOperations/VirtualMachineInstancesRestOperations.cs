// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ConnectedVMwarevSphere.Models;

namespace Azure.ResourceManager.ConnectedVMwarevSphere
{
    internal partial class VirtualMachineInstancesRestOperations
    {
        private readonly TelemetryDetails _userAgent;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of VirtualMachineInstancesRestOperations. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="applicationId"> The application id to use for user agent. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipeline"/> or <paramref name="apiVersion"/> is null. </exception>
        public VirtualMachineInstancesRestOperations(HttpPipeline pipeline, string applicationId, Uri endpoint = null, string apiVersion = default)
        {
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("https://management.azure.com");
            _apiVersion = apiVersion ?? "2023-12-01";
            _userAgent = new TelemetryDetails(GetType().Assembly, applicationId);
        }

        internal RequestUriBuilder CreateCreateOrUpdateRequestUri(string resourceUri, VMwareVmInstanceData data)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceUri, false);
            uri.AppendPath("/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineInstances/default", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            return uri;
        }

        internal HttpMessage CreateCreateOrUpdateRequest(string resourceUri, VMwareVmInstanceData data)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceUri, false);
            uri.AppendPath("/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineInstances/default", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(data, ModelSerializationExtensions.WireOptions);
            request.Content = content;
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> The operation to create or update a virtual machine instance. Please note some properties can be set only during virtual machine instance creation. </summary>
        /// <param name="resourceUri"> The fully qualified Azure Resource manager identifier of the Hybrid Compute machine resource to be extended. </param>
        /// <param name="data"> Request payload. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceUri"/> or <paramref name="data"/> is null. </exception>
        public async Task<Response> CreateOrUpdateAsync(string resourceUri, VMwareVmInstanceData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceUri, nameof(resourceUri));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(resourceUri, data);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> The operation to create or update a virtual machine instance. Please note some properties can be set only during virtual machine instance creation. </summary>
        /// <param name="resourceUri"> The fully qualified Azure Resource manager identifier of the Hybrid Compute machine resource to be extended. </param>
        /// <param name="data"> Request payload. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceUri"/> or <paramref name="data"/> is null. </exception>
        public Response CreateOrUpdate(string resourceUri, VMwareVmInstanceData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceUri, nameof(resourceUri));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(resourceUri, data);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal RequestUriBuilder CreateGetRequestUri(string resourceUri)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceUri, false);
            uri.AppendPath("/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineInstances/default", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            return uri;
        }

        internal HttpMessage CreateGetRequest(string resourceUri)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceUri, false);
            uri.AppendPath("/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineInstances/default", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Retrieves information about a virtual machine instance. </summary>
        /// <param name="resourceUri"> The fully qualified Azure Resource manager identifier of the Hybrid Compute machine resource to be extended. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceUri"/> is null. </exception>
        public async Task<Response<VMwareVmInstanceData>> GetAsync(string resourceUri, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceUri, nameof(resourceUri));

            using var message = CreateGetRequest(resourceUri);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        VMwareVmInstanceData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
                        value = VMwareVmInstanceData.DeserializeVMwareVmInstanceData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((VMwareVmInstanceData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Retrieves information about a virtual machine instance. </summary>
        /// <param name="resourceUri"> The fully qualified Azure Resource manager identifier of the Hybrid Compute machine resource to be extended. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceUri"/> is null. </exception>
        public Response<VMwareVmInstanceData> Get(string resourceUri, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceUri, nameof(resourceUri));

            using var message = CreateGetRequest(resourceUri);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        VMwareVmInstanceData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
                        value = VMwareVmInstanceData.DeserializeVMwareVmInstanceData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((VMwareVmInstanceData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal RequestUriBuilder CreateUpdateRequestUri(string resourceUri, VMwareVmInstancePatch patch)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceUri, false);
            uri.AppendPath("/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineInstances/default", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            return uri;
        }

        internal HttpMessage CreateUpdateRequest(string resourceUri, VMwareVmInstancePatch patch)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceUri, false);
            uri.AppendPath("/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineInstances/default", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(patch, ModelSerializationExtensions.WireOptions);
            request.Content = content;
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> The operation to update a virtual machine instance. </summary>
        /// <param name="resourceUri"> The fully qualified Azure Resource manager identifier of the Hybrid Compute machine resource to be extended. </param>
        /// <param name="patch"> Resource properties to update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceUri"/> or <paramref name="patch"/> is null. </exception>
        public async Task<Response> UpdateAsync(string resourceUri, VMwareVmInstancePatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceUri, nameof(resourceUri));
            Argument.AssertNotNull(patch, nameof(patch));

            using var message = CreateUpdateRequest(resourceUri, patch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> The operation to update a virtual machine instance. </summary>
        /// <param name="resourceUri"> The fully qualified Azure Resource manager identifier of the Hybrid Compute machine resource to be extended. </param>
        /// <param name="patch"> Resource properties to update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceUri"/> or <paramref name="patch"/> is null. </exception>
        public Response Update(string resourceUri, VMwareVmInstancePatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceUri, nameof(resourceUri));
            Argument.AssertNotNull(patch, nameof(patch));

            using var message = CreateUpdateRequest(resourceUri, patch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal RequestUriBuilder CreateDeleteRequestUri(string resourceUri, bool? deleteFromHost, bool? force)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceUri, false);
            uri.AppendPath("/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineInstances/default", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            if (deleteFromHost != null)
            {
                uri.AppendQuery("deleteFromHost", deleteFromHost.Value, true);
            }
            if (force != null)
            {
                uri.AppendQuery("force", force.Value, true);
            }
            return uri;
        }

        internal HttpMessage CreateDeleteRequest(string resourceUri, bool? deleteFromHost, bool? force)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceUri, false);
            uri.AppendPath("/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineInstances/default", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            if (deleteFromHost != null)
            {
                uri.AppendQuery("deleteFromHost", deleteFromHost.Value, true);
            }
            if (force != null)
            {
                uri.AppendQuery("force", force.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> The operation to delete a virtual machine instance. </summary>
        /// <param name="resourceUri"> The fully qualified Azure Resource manager identifier of the Hybrid Compute machine resource to be extended. </param>
        /// <param name="deleteFromHost"> Whether to delete the VM from the vCenter. </param>
        /// <param name="force"> Whether force delete was specified. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceUri"/> is null. </exception>
        public async Task<Response> DeleteAsync(string resourceUri, bool? deleteFromHost = null, bool? force = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceUri, nameof(resourceUri));

            using var message = CreateDeleteRequest(resourceUri, deleteFromHost, force);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> The operation to delete a virtual machine instance. </summary>
        /// <param name="resourceUri"> The fully qualified Azure Resource manager identifier of the Hybrid Compute machine resource to be extended. </param>
        /// <param name="deleteFromHost"> Whether to delete the VM from the vCenter. </param>
        /// <param name="force"> Whether force delete was specified. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceUri"/> is null. </exception>
        public Response Delete(string resourceUri, bool? deleteFromHost = null, bool? force = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceUri, nameof(resourceUri));

            using var message = CreateDeleteRequest(resourceUri, deleteFromHost, force);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal RequestUriBuilder CreateListRequestUri(string resourceUri)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceUri, false);
            uri.AppendPath("/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineInstances", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            return uri;
        }

        internal HttpMessage CreateListRequest(string resourceUri)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceUri, false);
            uri.AppendPath("/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineInstances", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Lists all of the virtual machine instances within the specified parent resource. </summary>
        /// <param name="resourceUri"> The fully qualified Azure Resource manager identifier of the Hybrid Compute machine resource to be extended. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceUri"/> is null. </exception>
        public async Task<Response<VMwareVmInstanceListResult>> ListAsync(string resourceUri, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceUri, nameof(resourceUri));

            using var message = CreateListRequest(resourceUri);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        VMwareVmInstanceListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
                        value = VMwareVmInstanceListResult.DeserializeVMwareVmInstanceListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists all of the virtual machine instances within the specified parent resource. </summary>
        /// <param name="resourceUri"> The fully qualified Azure Resource manager identifier of the Hybrid Compute machine resource to be extended. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceUri"/> is null. </exception>
        public Response<VMwareVmInstanceListResult> List(string resourceUri, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceUri, nameof(resourceUri));

            using var message = CreateListRequest(resourceUri);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        VMwareVmInstanceListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
                        value = VMwareVmInstanceListResult.DeserializeVMwareVmInstanceListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal RequestUriBuilder CreateStopRequestUri(string resourceUri, StopVirtualMachineContent content)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceUri, false);
            uri.AppendPath("/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineInstances/default/stop", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            return uri;
        }

        internal HttpMessage CreateStopRequest(string resourceUri, StopVirtualMachineContent content)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceUri, false);
            uri.AppendPath("/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineInstances/default/stop", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (content != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content0 = new Utf8JsonRequestContent();
                content0.JsonWriter.WriteObjectValue(content, ModelSerializationExtensions.WireOptions);
                request.Content = content0;
            }
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> The operation to power off (stop) a virtual machine instance. </summary>
        /// <param name="resourceUri"> The fully qualified Azure Resource manager identifier of the Hybrid Compute machine resource to be extended. </param>
        /// <param name="content"> Virtualmachine stop action payload. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceUri"/> is null. </exception>
        public async Task<Response> StopAsync(string resourceUri, StopVirtualMachineContent content = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceUri, nameof(resourceUri));

            using var message = CreateStopRequest(resourceUri, content);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> The operation to power off (stop) a virtual machine instance. </summary>
        /// <param name="resourceUri"> The fully qualified Azure Resource manager identifier of the Hybrid Compute machine resource to be extended. </param>
        /// <param name="content"> Virtualmachine stop action payload. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceUri"/> is null. </exception>
        public Response Stop(string resourceUri, StopVirtualMachineContent content = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceUri, nameof(resourceUri));

            using var message = CreateStopRequest(resourceUri, content);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal RequestUriBuilder CreateStartRequestUri(string resourceUri)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceUri, false);
            uri.AppendPath("/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineInstances/default/start", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            return uri;
        }

        internal HttpMessage CreateStartRequest(string resourceUri)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceUri, false);
            uri.AppendPath("/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineInstances/default/start", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> The operation to start a virtual machine instance. </summary>
        /// <param name="resourceUri"> The fully qualified Azure Resource manager identifier of the Hybrid Compute machine resource to be extended. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceUri"/> is null. </exception>
        public async Task<Response> StartAsync(string resourceUri, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceUri, nameof(resourceUri));

            using var message = CreateStartRequest(resourceUri);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> The operation to start a virtual machine instance. </summary>
        /// <param name="resourceUri"> The fully qualified Azure Resource manager identifier of the Hybrid Compute machine resource to be extended. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceUri"/> is null. </exception>
        public Response Start(string resourceUri, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceUri, nameof(resourceUri));

            using var message = CreateStartRequest(resourceUri);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal RequestUriBuilder CreateRestartRequestUri(string resourceUri)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceUri, false);
            uri.AppendPath("/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineInstances/default/restart", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            return uri;
        }

        internal HttpMessage CreateRestartRequest(string resourceUri)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceUri, false);
            uri.AppendPath("/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineInstances/default/restart", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> The operation to restart a virtual machine instance. </summary>
        /// <param name="resourceUri"> The fully qualified Azure Resource manager identifier of the Hybrid Compute machine resource to be extended. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceUri"/> is null. </exception>
        public async Task<Response> RestartAsync(string resourceUri, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceUri, nameof(resourceUri));

            using var message = CreateRestartRequest(resourceUri);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> The operation to restart a virtual machine instance. </summary>
        /// <param name="resourceUri"> The fully qualified Azure Resource manager identifier of the Hybrid Compute machine resource to be extended. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceUri"/> is null. </exception>
        public Response Restart(string resourceUri, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceUri, nameof(resourceUri));

            using var message = CreateRestartRequest(resourceUri);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal RequestUriBuilder CreateListNextPageRequestUri(string nextLink, string resourceUri)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            return uri;
        }

        internal HttpMessage CreateListNextPageRequest(string nextLink, string resourceUri)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Lists all of the virtual machine instances within the specified parent resource. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="resourceUri"> The fully qualified Azure Resource manager identifier of the Hybrid Compute machine resource to be extended. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> or <paramref name="resourceUri"/> is null. </exception>
        public async Task<Response<VMwareVmInstanceListResult>> ListNextPageAsync(string nextLink, string resourceUri, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNull(resourceUri, nameof(resourceUri));

            using var message = CreateListNextPageRequest(nextLink, resourceUri);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        VMwareVmInstanceListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
                        value = VMwareVmInstanceListResult.DeserializeVMwareVmInstanceListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists all of the virtual machine instances within the specified parent resource. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="resourceUri"> The fully qualified Azure Resource manager identifier of the Hybrid Compute machine resource to be extended. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> or <paramref name="resourceUri"/> is null. </exception>
        public Response<VMwareVmInstanceListResult> ListNextPage(string nextLink, string resourceUri, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNull(resourceUri, nameof(resourceUri));

            using var message = CreateListNextPageRequest(nextLink, resourceUri);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        VMwareVmInstanceListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
                        value = VMwareVmInstanceListResult.DeserializeVMwareVmInstanceListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
