﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Serialization;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Streaming dtmf.
    /// </summary>
    internal class DtmfDataInternal
    {
        /// <summary>
        /// The dtmf data in base64 string.
        /// </summary>
        [JsonPropertyName("data")]
        public string Data { get; set; }

        /// <summary>
        /// The timestamp of thwn the media was sourced.
        /// </summary>
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Participant ID.
        /// </summary>
        [JsonPropertyName("participantRawID")]
        public string ParticipantRawId { get; set; }
    }
}
