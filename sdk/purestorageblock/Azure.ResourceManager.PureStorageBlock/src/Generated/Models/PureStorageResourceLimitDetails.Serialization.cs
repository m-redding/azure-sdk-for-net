// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.PureStorageBlock.Models
{
    public partial class PureStorageResourceLimitDetails : IUtf8JsonSerializable, IJsonModel<PureStorageResourceLimitDetails>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<PureStorageResourceLimitDetails>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<PureStorageResourceLimitDetails>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PureStorageResourceLimitDetails>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(PureStorageResourceLimitDetails)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("storagePool"u8);
            writer.WriteObjectValue(StoragePool, options);
            writer.WritePropertyName("volume"u8);
            writer.WriteObjectValue(Volume, options);
            writer.WritePropertyName("protectionPolicy"u8);
            writer.WriteObjectValue(ProtectionPolicy, options);
            writer.WritePropertyName("performancePolicy"u8);
            writer.WriteObjectValue(PerformancePolicy, options);
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

        PureStorageResourceLimitDetails IJsonModel<PureStorageResourceLimitDetails>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PureStorageResourceLimitDetails>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(PureStorageResourceLimitDetails)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePureStorageResourceLimitDetails(document.RootElement, options);
        }

        internal static PureStorageResourceLimitDetails DeserializePureStorageResourceLimitDetails(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            StoragePoolLimits storagePool = default;
            VolumeLimits volume = default;
            ProtectionPolicyLimits protectionPolicy = default;
            PerformancePolicyLimits performancePolicy = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("storagePool"u8))
                {
                    storagePool = StoragePoolLimits.DeserializeStoragePoolLimits(property.Value, options);
                    continue;
                }
                if (property.NameEquals("volume"u8))
                {
                    volume = VolumeLimits.DeserializeVolumeLimits(property.Value, options);
                    continue;
                }
                if (property.NameEquals("protectionPolicy"u8))
                {
                    protectionPolicy = ProtectionPolicyLimits.DeserializeProtectionPolicyLimits(property.Value, options);
                    continue;
                }
                if (property.NameEquals("performancePolicy"u8))
                {
                    performancePolicy = PerformancePolicyLimits.DeserializePerformancePolicyLimits(property.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new PureStorageResourceLimitDetails(storagePool, volume, protectionPolicy, performancePolicy, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<PureStorageResourceLimitDetails>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PureStorageResourceLimitDetails>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerPureStorageBlockContext.Default);
                default:
                    throw new FormatException($"The model {nameof(PureStorageResourceLimitDetails)} does not support writing '{options.Format}' format.");
            }
        }

        PureStorageResourceLimitDetails IPersistableModel<PureStorageResourceLimitDetails>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PureStorageResourceLimitDetails>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializePureStorageResourceLimitDetails(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(PureStorageResourceLimitDetails)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<PureStorageResourceLimitDetails>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
