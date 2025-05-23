// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.DevSpaces.Models
{
    public partial class ContainerHostMapping : IUtf8JsonSerializable, IJsonModel<ContainerHostMapping>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ContainerHostMapping>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<ContainerHostMapping>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ContainerHostMapping>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ContainerHostMapping)} does not support writing '{format}' format.");
            }

            if (Optional.IsDefined(ContainerHostResourceId))
            {
                writer.WritePropertyName("containerHostResourceId"u8);
                writer.WriteStringValue(ContainerHostResourceId);
            }
            if (options.Format != "W" && Optional.IsDefined(MappedControllerResourceId))
            {
                writer.WritePropertyName("mappedControllerResourceId"u8);
                writer.WriteStringValue(MappedControllerResourceId);
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        ContainerHostMapping IJsonModel<ContainerHostMapping>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ContainerHostMapping>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ContainerHostMapping)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeContainerHostMapping(document.RootElement, options);
        }

        internal static ContainerHostMapping DeserializeContainerHostMapping(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string containerHostResourceId = default;
            string mappedControllerResourceId = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("containerHostResourceId"u8))
                {
                    containerHostResourceId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("mappedControllerResourceId"u8))
                {
                    mappedControllerResourceId = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new ContainerHostMapping(containerHostResourceId, mappedControllerResourceId, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ContainerHostMapping>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ContainerHostMapping>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerDevSpacesContext.Default);
                default:
                    throw new FormatException($"The model {nameof(ContainerHostMapping)} does not support writing '{options.Format}' format.");
            }
        }

        ContainerHostMapping IPersistableModel<ContainerHostMapping>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ContainerHostMapping>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeContainerHostMapping(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ContainerHostMapping)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ContainerHostMapping>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
