// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.DataFactory.Models
{
    /// <summary> Managed Identity used for CMK. </summary>
    internal partial class DataFactoryCmkIdentity
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

        /// <summary> Initializes a new instance of <see cref="DataFactoryCmkIdentity"/>. </summary>
        public DataFactoryCmkIdentity()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DataFactoryCmkIdentity"/>. </summary>
        /// <param name="userAssignedIdentity"> The resource id of the user assigned identity to authenticate to customer's key vault. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DataFactoryCmkIdentity(string userAssignedIdentity, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            UserAssignedIdentity = userAssignedIdentity;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The resource id of the user assigned identity to authenticate to customer's key vault. </summary>
        public string UserAssignedIdentity { get; set; }
    }
}
