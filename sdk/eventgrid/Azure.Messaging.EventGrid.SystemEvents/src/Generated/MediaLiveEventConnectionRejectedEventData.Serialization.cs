// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    public partial class MediaLiveEventConnectionRejectedEventData : IUtf8JsonSerializable, IJsonModel<MediaLiveEventConnectionRejectedEventData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<MediaLiveEventConnectionRejectedEventData>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<MediaLiveEventConnectionRejectedEventData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MediaLiveEventConnectionRejectedEventData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MediaLiveEventConnectionRejectedEventData)} does not support writing '{format}' format.");
            }

            if (Optional.IsDefined(IngestUrl))
            {
                writer.WritePropertyName("ingestUrl"u8);
                writer.WriteStringValue(IngestUrl);
            }
            if (Optional.IsDefined(StreamId))
            {
                writer.WritePropertyName("streamId"u8);
                writer.WriteStringValue(StreamId);
            }
            if (Optional.IsDefined(EncoderIp))
            {
                writer.WritePropertyName("encoderIp"u8);
                writer.WriteStringValue(EncoderIp);
            }
            if (Optional.IsDefined(EncoderPort))
            {
                writer.WritePropertyName("encoderPort"u8);
                writer.WriteStringValue(EncoderPort);
            }
            if (Optional.IsDefined(ResultCode))
            {
                writer.WritePropertyName("resultCode"u8);
                writer.WriteStringValue(ResultCode);
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        MediaLiveEventConnectionRejectedEventData IJsonModel<MediaLiveEventConnectionRejectedEventData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MediaLiveEventConnectionRejectedEventData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MediaLiveEventConnectionRejectedEventData)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMediaLiveEventConnectionRejectedEventData(document.RootElement, options);
        }

        internal static MediaLiveEventConnectionRejectedEventData DeserializeMediaLiveEventConnectionRejectedEventData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string ingestUrl = default;
            string streamId = default;
            string encoderIp = default;
            string encoderPort = default;
            string resultCode = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ingestUrl"u8))
                {
                    ingestUrl = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("streamId"u8))
                {
                    streamId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("encoderIp"u8))
                {
                    encoderIp = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("encoderPort"u8))
                {
                    encoderPort = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("resultCode"u8))
                {
                    resultCode = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new MediaLiveEventConnectionRejectedEventData(
                ingestUrl,
                streamId,
                encoderIp,
                encoderPort,
                resultCode,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<MediaLiveEventConnectionRejectedEventData>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MediaLiveEventConnectionRejectedEventData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(MediaLiveEventConnectionRejectedEventData)} does not support writing '{options.Format}' format.");
            }
        }

        MediaLiveEventConnectionRejectedEventData IPersistableModel<MediaLiveEventConnectionRejectedEventData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MediaLiveEventConnectionRejectedEventData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeMediaLiveEventConnectionRejectedEventData(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(MediaLiveEventConnectionRejectedEventData)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<MediaLiveEventConnectionRejectedEventData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static MediaLiveEventConnectionRejectedEventData FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeMediaLiveEventConnectionRejectedEventData(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this, ModelSerializationExtensions.WireOptions);
            return content;
        }
    }
}
