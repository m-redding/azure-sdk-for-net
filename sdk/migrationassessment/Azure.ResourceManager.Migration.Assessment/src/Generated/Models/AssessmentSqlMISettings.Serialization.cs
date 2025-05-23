// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Migration.Assessment.Models
{
    public partial class AssessmentSqlMISettings : IUtf8JsonSerializable, IJsonModel<AssessmentSqlMISettings>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<AssessmentSqlMISettings>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<AssessmentSqlMISettings>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AssessmentSqlMISettings>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AssessmentSqlMISettings)} does not support writing '{format}' format.");
            }

            if (Optional.IsDefined(AzureSqlServiceTier))
            {
                writer.WritePropertyName("azureSqlServiceTier"u8);
                writer.WriteStringValue(AzureSqlServiceTier.Value.ToString());
            }
            if (Optional.IsDefined(AzureSqlInstanceType))
            {
                writer.WritePropertyName("azureSqlInstanceType"u8);
                writer.WriteStringValue(AzureSqlInstanceType.Value.ToString());
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

        AssessmentSqlMISettings IJsonModel<AssessmentSqlMISettings>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AssessmentSqlMISettings>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AssessmentSqlMISettings)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAssessmentSqlMISettings(document.RootElement, options);
        }

        internal static AssessmentSqlMISettings DeserializeAssessmentSqlMISettings(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            AssessmentSqlServiceTier? azureSqlServiceTier = default;
            AssessmentSqlInstanceType? azureSqlInstanceType = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("azureSqlServiceTier"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    azureSqlServiceTier = new AssessmentSqlServiceTier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("azureSqlInstanceType"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    azureSqlInstanceType = new AssessmentSqlInstanceType(property.Value.GetString());
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new AssessmentSqlMISettings(azureSqlServiceTier, azureSqlInstanceType, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<AssessmentSqlMISettings>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AssessmentSqlMISettings>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerMigrationAssessmentContext.Default);
                default:
                    throw new FormatException($"The model {nameof(AssessmentSqlMISettings)} does not support writing '{options.Format}' format.");
            }
        }

        AssessmentSqlMISettings IPersistableModel<AssessmentSqlMISettings>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AssessmentSqlMISettings>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeAssessmentSqlMISettings(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(AssessmentSqlMISettings)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<AssessmentSqlMISettings>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
