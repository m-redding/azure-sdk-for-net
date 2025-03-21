// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.MobileNetwork.Models
{
    /// <summary> Single-network slice selection assistance information (S-NSSAI). </summary>
    public partial class Snssai
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

        /// <summary> Initializes a new instance of <see cref="Snssai"/>. </summary>
        /// <param name="sst"> Slice/service type (SST). </param>
        public Snssai(int sst)
        {
            Sst = sst;
        }

        /// <summary> Initializes a new instance of <see cref="Snssai"/>. </summary>
        /// <param name="sst"> Slice/service type (SST). </param>
        /// <param name="sd"> Slice differentiator (SD). </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal Snssai(int sst, string sd, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Sst = sst;
            Sd = sd;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="Snssai"/> for deserialization. </summary>
        internal Snssai()
        {
        }

        /// <summary> Slice/service type (SST). </summary>
        [WirePath("sst")]
        public int Sst { get; set; }
        /// <summary> Slice differentiator (SD). </summary>
        [WirePath("sd")]
        public string Sd { get; set; }
    }
}
