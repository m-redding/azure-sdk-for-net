// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.SecurityInsights.Models
{
    /// <summary> Timeline Query Errors. </summary>
    internal partial class TimelineError
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

        /// <summary> Initializes a new instance of <see cref="TimelineError"/>. </summary>
        /// <param name="kind"> the query kind. </param>
        /// <param name="errorMessage"> the error message. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="errorMessage"/> is null. </exception>
        internal TimelineError(EntityTimelineKind kind, string errorMessage)
        {
            Argument.AssertNotNull(errorMessage, nameof(errorMessage));

            Kind = kind;
            ErrorMessage = errorMessage;
        }

        /// <summary> Initializes a new instance of <see cref="TimelineError"/>. </summary>
        /// <param name="kind"> the query kind. </param>
        /// <param name="queryId"> the query id. </param>
        /// <param name="errorMessage"> the error message. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal TimelineError(EntityTimelineKind kind, string queryId, string errorMessage, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Kind = kind;
            QueryId = queryId;
            ErrorMessage = errorMessage;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="TimelineError"/> for deserialization. </summary>
        internal TimelineError()
        {
        }

        /// <summary> the query kind. </summary>
        [WirePath("kind")]
        public EntityTimelineKind Kind { get; }
        /// <summary> the query id. </summary>
        [WirePath("queryId")]
        public string QueryId { get; }
        /// <summary> the error message. </summary>
        [WirePath("errorMessage")]
        public string ErrorMessage { get; }
    }
}
