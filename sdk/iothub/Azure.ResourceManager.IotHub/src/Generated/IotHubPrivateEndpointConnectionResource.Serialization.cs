// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.IotHub
{
    public partial class IotHubPrivateEndpointConnectionResource : IJsonModel<IotHubPrivateEndpointConnectionData>
    {
        private static IotHubPrivateEndpointConnectionData s_dataDeserializationInstance;
        private static IotHubPrivateEndpointConnectionData DataDeserializationInstance => s_dataDeserializationInstance ??= new();

        void IJsonModel<IotHubPrivateEndpointConnectionData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<IotHubPrivateEndpointConnectionData>)Data).Write(writer, options);

        IotHubPrivateEndpointConnectionData IJsonModel<IotHubPrivateEndpointConnectionData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<IotHubPrivateEndpointConnectionData>)DataDeserializationInstance).Create(ref reader, options);

        BinaryData IPersistableModel<IotHubPrivateEndpointConnectionData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<IotHubPrivateEndpointConnectionData>(Data, options, AzureResourceManagerIotHubContext.Default);

        IotHubPrivateEndpointConnectionData IPersistableModel<IotHubPrivateEndpointConnectionData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<IotHubPrivateEndpointConnectionData>(data, options, AzureResourceManagerIotHubContext.Default);

        string IPersistableModel<IotHubPrivateEndpointConnectionData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<IotHubPrivateEndpointConnectionData>)DataDeserializationInstance).GetFormatFromOptions(options);
    }
}
