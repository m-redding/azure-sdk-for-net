// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.Language.Conversations.Models
{
    /// <summary> The entity extraction result of a Conversation project. </summary>
    public partial class ConversationEntity
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ConversationEntity"/>. </summary>
        /// <param name="category"> The entity category. </param>
        /// <param name="text"> The predicted entity text. </param>
        /// <param name="offset"> The starting index of this entity in the query. </param>
        /// <param name="length"> The length of the text. </param>
        /// <param name="confidence"> The entity confidence score. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="category"/> or <paramref name="text"/> is null. </exception>
        internal ConversationEntity(string category, string text, int offset, int length, float confidence)
        {
            Argument.AssertNotNull(category, nameof(category));
            Argument.AssertNotNull(text, nameof(text));

            Category = category;
            Text = text;
            Offset = offset;
            Length = length;
            Confidence = confidence;
            Resolutions = new ChangeTrackingList<ResolutionBase>();
            ExtraInformation = new ChangeTrackingList<ConversationEntityExtraInformation>();
        }

        /// <summary> Initializes a new instance of <see cref="ConversationEntity"/>. </summary>
        /// <param name="category"> The entity category. </param>
        /// <param name="text"> The predicted entity text. </param>
        /// <param name="offset"> The starting index of this entity in the query. </param>
        /// <param name="length"> The length of the text. </param>
        /// <param name="confidence"> The entity confidence score. </param>
        /// <param name="resolutions">
        /// The collection of entity resolution objects.
        /// Please note <see cref="ResolutionBase"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="AgeResolution"/>, <see cref="AreaResolution"/>, <see cref="BooleanResolution"/>, <see cref="CurrencyResolution"/>, <see cref="DateTimeResolution"/>, <see cref="InformationResolution"/>, <see cref="LengthResolution"/>, <see cref="NumberResolution"/>, <see cref="NumericRangeResolution"/>, <see cref="OrdinalResolution"/>, <see cref="SpeedResolution"/>, <see cref="TemperatureResolution"/>, <see cref="TemporalSpanResolution"/>, <see cref="VolumeResolution"/> and <see cref="WeightResolution"/>.
        /// </param>
        /// <param name="extraInformation">
        /// The collection of entity extra information objects.
        /// Please note <see cref="ConversationEntityExtraInformation"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="EntitySubtype"/>, <see cref="ListKey"/> and <see cref="RegexKey"/>.
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ConversationEntity(string category, string text, int offset, int length, float confidence, IReadOnlyList<ResolutionBase> resolutions, IReadOnlyList<ConversationEntityExtraInformation> extraInformation, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Category = category;
            Text = text;
            Offset = offset;
            Length = length;
            Confidence = confidence;
            Resolutions = resolutions;
            ExtraInformation = extraInformation;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ConversationEntity"/> for deserialization. </summary>
        internal ConversationEntity()
        {
        }

        /// <summary> The entity category. </summary>
        public string Category { get; }
        /// <summary> The predicted entity text. </summary>
        public string Text { get; }
        /// <summary> The starting index of this entity in the query. </summary>
        public int Offset { get; }
        /// <summary> The length of the text. </summary>
        public int Length { get; }
        /// <summary> The entity confidence score. </summary>
        public float Confidence { get; }
        /// <summary>
        /// The collection of entity resolution objects.
        /// Please note <see cref="ResolutionBase"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="AgeResolution"/>, <see cref="AreaResolution"/>, <see cref="BooleanResolution"/>, <see cref="CurrencyResolution"/>, <see cref="DateTimeResolution"/>, <see cref="InformationResolution"/>, <see cref="LengthResolution"/>, <see cref="NumberResolution"/>, <see cref="NumericRangeResolution"/>, <see cref="OrdinalResolution"/>, <see cref="SpeedResolution"/>, <see cref="TemperatureResolution"/>, <see cref="TemporalSpanResolution"/>, <see cref="VolumeResolution"/> and <see cref="WeightResolution"/>.
        /// </summary>
        public IReadOnlyList<ResolutionBase> Resolutions { get; }
        /// <summary>
        /// The collection of entity extra information objects.
        /// Please note <see cref="ConversationEntityExtraInformation"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="EntitySubtype"/>, <see cref="ListKey"/> and <see cref="RegexKey"/>.
        /// </summary>
        public IReadOnlyList<ConversationEntityExtraInformation> ExtraInformation { get; }
    }
}
