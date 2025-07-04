// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable enable

using Azure.Provisioning.Primitives;
using System;

namespace Azure.Provisioning.ContainerRegistry;

/// <summary>
/// The TLS certificate properties of the connected registry login server.
/// </summary>
public partial class ContainerRegistryTlsCertificateProperties : ProvisionableConstruct
{
    /// <summary>
    /// The type of certificate location.
    /// </summary>
    public BicepValue<ContainerRegistryCertificateType> CertificateType 
    {
        get { Initialize(); return _certificateType!; }
    }
    private BicepValue<ContainerRegistryCertificateType>? _certificateType;

    /// <summary>
    /// Indicates the location of the certificates.
    /// </summary>
    public BicepValue<string> CertificateLocation 
    {
        get { Initialize(); return _certificateLocation!; }
    }
    private BicepValue<string>? _certificateLocation;

    /// <summary>
    /// Creates a new ContainerRegistryTlsCertificateProperties.
    /// </summary>
    public ContainerRegistryTlsCertificateProperties()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// ContainerRegistryTlsCertificateProperties.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _certificateType = DefineProperty<ContainerRegistryCertificateType>("CertificateType", ["type"], isOutput: true);
        _certificateLocation = DefineProperty<string>("CertificateLocation", ["location"], isOutput: true);
    }
}
