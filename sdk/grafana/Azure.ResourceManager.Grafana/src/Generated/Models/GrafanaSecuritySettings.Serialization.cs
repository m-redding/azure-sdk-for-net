// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Grafana.Models
{
    internal partial class GrafanaSecuritySettings : IUtf8JsonSerializable, IJsonModel<GrafanaSecuritySettings>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<GrafanaSecuritySettings>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<GrafanaSecuritySettings>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<GrafanaSecuritySettings>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(GrafanaSecuritySettings)} does not support writing '{format}' format.");
            }

            if (Optional.IsDefined(IsCsrfAlwaysCheckEnabled))
            {
                writer.WritePropertyName("csrfAlwaysCheck"u8);
                writer.WriteBooleanValue(IsCsrfAlwaysCheckEnabled.Value);
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

        GrafanaSecuritySettings IJsonModel<GrafanaSecuritySettings>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<GrafanaSecuritySettings>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(GrafanaSecuritySettings)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeGrafanaSecuritySettings(document.RootElement, options);
        }

        internal static GrafanaSecuritySettings DeserializeGrafanaSecuritySettings(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool? csrfAlwaysCheck = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("csrfAlwaysCheck"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    csrfAlwaysCheck = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new GrafanaSecuritySettings(csrfAlwaysCheck, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<GrafanaSecuritySettings>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<GrafanaSecuritySettings>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerGrafanaContext.Default);
                default:
                    throw new FormatException($"The model {nameof(GrafanaSecuritySettings)} does not support writing '{options.Format}' format.");
            }
        }

        GrafanaSecuritySettings IPersistableModel<GrafanaSecuritySettings>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<GrafanaSecuritySettings>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeGrafanaSecuritySettings(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(GrafanaSecuritySettings)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<GrafanaSecuritySettings>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
