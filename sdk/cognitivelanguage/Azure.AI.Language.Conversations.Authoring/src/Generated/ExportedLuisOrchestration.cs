// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.Language.Conversations.Authoring
{
    /// <summary> Defines the orchestration details for a LUIS application target. </summary>
    public partial class ExportedLuisOrchestration
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

        /// <summary> Initializes a new instance of <see cref="ExportedLuisOrchestration"/>. </summary>
        /// <param name="appId"> The LUIS application ID. </param>
        public ExportedLuisOrchestration(Guid appId)
        {
            AppId = appId;
        }

        /// <summary> Initializes a new instance of <see cref="ExportedLuisOrchestration"/>. </summary>
        /// <param name="appId"> The LUIS application ID. </param>
        /// <param name="appVersion"> The targeted version Id. </param>
        /// <param name="slotName"> The targeted slot name. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ExportedLuisOrchestration(Guid appId, string appVersion, string slotName, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            AppId = appId;
            AppVersion = appVersion;
            SlotName = slotName;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ExportedLuisOrchestration"/> for deserialization. </summary>
        internal ExportedLuisOrchestration()
        {
        }

        /// <summary> The LUIS application ID. </summary>
        public Guid AppId { get; }
        /// <summary> The targeted version Id. </summary>
        public string AppVersion { get; set; }
        /// <summary> The targeted slot name. </summary>
        public string SlotName { get; set; }
    }
}
