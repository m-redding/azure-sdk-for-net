// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Workloads.Models
{
    public partial class ApplicationServerFullResourceNames : IUtf8JsonSerializable, IJsonModel<ApplicationServerFullResourceNames>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ApplicationServerFullResourceNames>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<ApplicationServerFullResourceNames>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ApplicationServerFullResourceNames>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ApplicationServerFullResourceNames)} does not support writing '{format}' format.");
            }

            if (Optional.IsCollectionDefined(VirtualMachines))
            {
                writer.WritePropertyName("virtualMachines"u8);
                writer.WriteStartArray();
                foreach (var item in VirtualMachines)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(AvailabilitySetName))
            {
                writer.WritePropertyName("availabilitySetName"u8);
                writer.WriteStringValue(AvailabilitySetName);
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

        ApplicationServerFullResourceNames IJsonModel<ApplicationServerFullResourceNames>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ApplicationServerFullResourceNames>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ApplicationServerFullResourceNames)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeApplicationServerFullResourceNames(document.RootElement, options);
        }

        internal static ApplicationServerFullResourceNames DeserializeApplicationServerFullResourceNames(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<VirtualMachineResourceNames> virtualMachines = default;
            string availabilitySetName = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("virtualMachines"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<VirtualMachineResourceNames> array = new List<VirtualMachineResourceNames>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VirtualMachineResourceNames.DeserializeVirtualMachineResourceNames(item, options));
                    }
                    virtualMachines = array;
                    continue;
                }
                if (property.NameEquals("availabilitySetName"u8))
                {
                    availabilitySetName = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new ApplicationServerFullResourceNames(virtualMachines ?? new ChangeTrackingList<VirtualMachineResourceNames>(), availabilitySetName, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ApplicationServerFullResourceNames>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ApplicationServerFullResourceNames>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerWorkloadsContext.Default);
                default:
                    throw new FormatException($"The model {nameof(ApplicationServerFullResourceNames)} does not support writing '{options.Format}' format.");
            }
        }

        ApplicationServerFullResourceNames IPersistableModel<ApplicationServerFullResourceNames>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ApplicationServerFullResourceNames>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeApplicationServerFullResourceNames(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ApplicationServerFullResourceNames)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ApplicationServerFullResourceNames>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
