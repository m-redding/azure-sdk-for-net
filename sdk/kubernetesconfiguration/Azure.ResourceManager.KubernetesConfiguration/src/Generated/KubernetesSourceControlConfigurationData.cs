// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.KubernetesConfiguration.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.KubernetesConfiguration
{
    /// <summary>
    /// A class representing the KubernetesSourceControlConfiguration data model.
    /// The SourceControl Configuration object returned in Get &amp; Put response.
    /// </summary>
    public partial class KubernetesSourceControlConfigurationData : ResourceData
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

        /// <summary> Initializes a new instance of <see cref="KubernetesSourceControlConfigurationData"/>. </summary>
        public KubernetesSourceControlConfigurationData()
        {
            ConfigurationProtectedSettings = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of <see cref="KubernetesSourceControlConfigurationData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="repositoryUri"> Url of the SourceControl Repository. </param>
        /// <param name="operatorNamespace"> The namespace to which this operator is installed to. Maximum of 253 lower case alphanumeric characters, hyphen and period only. </param>
        /// <param name="operatorInstanceName"> Instance name of the operator - identifying the specific configuration. </param>
        /// <param name="operatorType"> Type of the operator. </param>
        /// <param name="operatorParams"> Any Parameters for the Operator instance in string format. </param>
        /// <param name="configurationProtectedSettings"> Name-value pairs of protected configuration settings for the configuration. </param>
        /// <param name="operatorScope"> Scope at which the operator will be installed. </param>
        /// <param name="repositoryPublicKey"> Public Key associated with this SourceControl configuration (either generated within the cluster or provided by the user). </param>
        /// <param name="sshKnownHostsContents"> Base64-encoded known_hosts contents containing public SSH keys required to access private Git instances. </param>
        /// <param name="isHelmOperatorEnabled"> Option to enable Helm Operator for this git configuration. </param>
        /// <param name="helmOperatorProperties"> Properties for Helm operator. </param>
        /// <param name="provisioningState"> The provisioning state of the resource provider. </param>
        /// <param name="complianceStatus"> Compliance Status of the Configuration. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal KubernetesSourceControlConfigurationData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, Uri repositoryUri, string operatorNamespace, string operatorInstanceName, KubernetesOperator? operatorType, string operatorParams, IDictionary<string, string> configurationProtectedSettings, KubernetesOperatorScope? operatorScope, string repositoryPublicKey, string sshKnownHostsContents, bool? isHelmOperatorEnabled, HelmOperatorProperties helmOperatorProperties, KubernetesConfigurationProvisioningStateType? provisioningState, KubernetesConfigurationComplianceStatus complianceStatus, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            RepositoryUri = repositoryUri;
            OperatorNamespace = operatorNamespace;
            OperatorInstanceName = operatorInstanceName;
            OperatorType = operatorType;
            OperatorParams = operatorParams;
            ConfigurationProtectedSettings = configurationProtectedSettings;
            OperatorScope = operatorScope;
            RepositoryPublicKey = repositoryPublicKey;
            SshKnownHostsContents = sshKnownHostsContents;
            IsHelmOperatorEnabled = isHelmOperatorEnabled;
            HelmOperatorProperties = helmOperatorProperties;
            ProvisioningState = provisioningState;
            ComplianceStatus = complianceStatus;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Url of the SourceControl Repository. </summary>
        [WirePath("properties.repositoryUrl")]
        public Uri RepositoryUri { get; set; }
        /// <summary> The namespace to which this operator is installed to. Maximum of 253 lower case alphanumeric characters, hyphen and period only. </summary>
        [WirePath("properties.operatorNamespace")]
        public string OperatorNamespace { get; set; }
        /// <summary> Instance name of the operator - identifying the specific configuration. </summary>
        [WirePath("properties.operatorInstanceName")]
        public string OperatorInstanceName { get; set; }
        /// <summary> Type of the operator. </summary>
        [WirePath("properties.operatorType")]
        public KubernetesOperator? OperatorType { get; set; }
        /// <summary> Any Parameters for the Operator instance in string format. </summary>
        [WirePath("properties.operatorParams")]
        public string OperatorParams { get; set; }
        /// <summary> Name-value pairs of protected configuration settings for the configuration. </summary>
        [WirePath("properties.configurationProtectedSettings")]
        public IDictionary<string, string> ConfigurationProtectedSettings { get; }
        /// <summary> Scope at which the operator will be installed. </summary>
        [WirePath("properties.operatorScope")]
        public KubernetesOperatorScope? OperatorScope { get; set; }
        /// <summary> Public Key associated with this SourceControl configuration (either generated within the cluster or provided by the user). </summary>
        [WirePath("properties.repositoryPublicKey")]
        public string RepositoryPublicKey { get; }
        /// <summary> Base64-encoded known_hosts contents containing public SSH keys required to access private Git instances. </summary>
        [WirePath("properties.sshKnownHostsContents")]
        public string SshKnownHostsContents { get; set; }
        /// <summary> Option to enable Helm Operator for this git configuration. </summary>
        [WirePath("properties.enableHelmOperator")]
        public bool? IsHelmOperatorEnabled { get; set; }
        /// <summary> Properties for Helm operator. </summary>
        [WirePath("properties.helmOperatorProperties")]
        public HelmOperatorProperties HelmOperatorProperties { get; set; }
        /// <summary> The provisioning state of the resource provider. </summary>
        [WirePath("properties.provisioningState")]
        public KubernetesConfigurationProvisioningStateType? ProvisioningState { get; }
        /// <summary> Compliance Status of the Configuration. </summary>
        [WirePath("properties.complianceStatus")]
        public KubernetesConfigurationComplianceStatus ComplianceStatus { get; }
    }
}
