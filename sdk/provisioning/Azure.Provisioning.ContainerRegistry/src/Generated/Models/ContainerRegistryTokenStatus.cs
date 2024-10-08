// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

using System.Runtime.Serialization;

namespace Azure.Provisioning.ContainerRegistry;

/// <summary>
/// The status of the token example enabled or disabled.
/// </summary>
public enum ContainerRegistryTokenStatus
{
    /// <summary>
    /// enabled.
    /// </summary>
    [DataMember(Name = "enabled")]
    Enabled,

    /// <summary>
    /// disabled.
    /// </summary>
    [DataMember(Name = "disabled")]
    Disabled,
}
