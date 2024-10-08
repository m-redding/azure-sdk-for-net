// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.AppContainers.Models
{
    /// <summary> TCPSocket specifies an action involving a TCP port. TCP hooks not yet supported. </summary>
    public partial class ContainerAppTcpSocketRequestInfo
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

        /// <summary> Initializes a new instance of <see cref="ContainerAppTcpSocketRequestInfo"/>. </summary>
        /// <param name="port"> Number or name of the port to access on the container. Number must be in the range 1 to 65535. Name must be an IANA_SVC_NAME. </param>
        public ContainerAppTcpSocketRequestInfo(int port)
        {
            Port = port;
        }

        /// <summary> Initializes a new instance of <see cref="ContainerAppTcpSocketRequestInfo"/>. </summary>
        /// <param name="host"> Optional: Host name to connect to, defaults to the pod IP. </param>
        /// <param name="port"> Number or name of the port to access on the container. Number must be in the range 1 to 65535. Name must be an IANA_SVC_NAME. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ContainerAppTcpSocketRequestInfo(string host, int port, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Host = host;
            Port = port;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ContainerAppTcpSocketRequestInfo"/> for deserialization. </summary>
        internal ContainerAppTcpSocketRequestInfo()
        {
        }

        /// <summary> Optional: Host name to connect to, defaults to the pod IP. </summary>
        [WirePath("host")]
        public string Host { get; set; }
        /// <summary> Number or name of the port to access on the container. Number must be in the range 1 to 65535. Name must be an IANA_SVC_NAME. </summary>
        [WirePath("port")]
        public int Port { get; set; }
    }
}
