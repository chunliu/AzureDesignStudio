// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.ApiManagement
{
    /// <summary>
    /// ApiManagementServiceProperties
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApiManagementServiceProperties
    {
        /// <summary>
        /// Publisher email.
        /// </summary>
        [Required]
        [JsonPropertyName("publisherEmail")]
        public string PublisherEmail { get; set; }

        /// <summary>
        /// Publisher name.
        /// </summary>
        [Required]
        [JsonPropertyName("publisherName")]
        public string PublisherName { get; set; }

        /// <summary>
        /// Email address from which the notification will be sent.
        /// </summary>
        [JsonPropertyName("notificationSenderEmail")]
        public string NotificationSenderEmail { get; set; }

        /// <summary>
        /// The current provisioning state of the API Management service which can be one of the following: Created/Activating/Succeeded/Updating/Failed/Stopped/Terminating/TerminationFailed/Deleted.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// The provisioning state of the API Management service, which is targeted by the long running operation started on the service.
        /// </summary>
        [JsonPropertyName("targetProvisioningState")]
        public string TargetProvisioningState { get; set; }

        /// <summary>
        /// Creation UTC date of the API Management service.The date conforms to the following format: `yyyy-MM-ddTHH:mm:ssZ` as specified by the ISO 8601 standard.
        /// </summary>
        [JsonPropertyName("createdAtUtc")]
        public string CreatedAtUtc { get; set; }

        /// <summary>
        /// Gateway URL of the API Management service.
        /// </summary>
        [JsonPropertyName("gatewayUrl")]
        public string GatewayUrl { get; set; }

        /// <summary>
        /// Gateway URL of the API Management service in the Default Region.
        /// </summary>
        [JsonPropertyName("gatewayRegionalUrl")]
        public string GatewayRegionalUrl { get; set; }

        /// <summary>
        /// Publisher portal endpoint Url of the API Management service.
        /// </summary>
        [JsonPropertyName("portalUrl")]
        public string PortalUrl { get; set; }

        /// <summary>
        /// Management API endpoint URL of the API Management service.
        /// </summary>
        [JsonPropertyName("managementApiUrl")]
        public string ManagementApiUrl { get; set; }

        /// <summary>
        /// SCM endpoint URL of the API Management service.
        /// </summary>
        [JsonPropertyName("scmUrl")]
        public string ScmUrl { get; set; }

        /// <summary>
        /// DEveloper Portal endpoint URL of the API Management service.
        /// </summary>
        [JsonPropertyName("developerPortalUrl")]
        public string DeveloperPortalUrl { get; set; }

        /// <summary>
        /// Custom hostname configuration of the API Management service.
        /// </summary>
        [JsonPropertyName("hostnameConfigurations")]
        public IList<HostnameConfiguration> HostnameConfigurations { get; set; }

        /// <summary>
        /// Public Static Load Balanced IP addresses of the API Management service in Primary region. Available only for Basic, Standard, Premium and Isolated SKU.
        /// </summary>
        [JsonPropertyName("publicIPAddresses")]
        public IList<string> PublicIPAddresses { get; set; }

        /// <summary>
        /// Private Static Load Balanced IP addresses of the API Management service in Primary region which is deployed in an Internal Virtual Network. Available only for Basic, Standard, Premium and Isolated SKU.
        /// </summary>
        [JsonPropertyName("privateIPAddresses")]
        public IList<string> PrivateIPAddresses { get; set; }

        /// <summary>
        /// Public Standard SKU IP V4 based IP address to be associated with Virtual Network deployed service in the region. Supported only for Developer and Premium SKU being deployed in Virtual Network.
        /// </summary>
        [JsonPropertyName("publicIpAddressId")]
        public string PublicIpAddressId { get; set; }

        /// <summary>
        /// Whether or not public endpoint access is allowed for this API Management service.  Value is optional but if passed in, must be 'Enabled' or 'Disabled'. If 'Disabled', private endpoints are the exclusive access method. Default value is 'Enabled'
        /// </summary>
        [JsonPropertyName("publicNetworkAccess")]
        public string PublicNetworkAccess { get; set; }

        /// <summary>
        /// Virtual network configuration of the API Management service.
        /// </summary>
        [JsonPropertyName("virtualNetworkConfiguration")]
        public VirtualNetworkConfiguration VirtualNetworkConfiguration { get; set; }

        /// <summary>
        /// Additional datacenter locations of the API Management service.
        /// </summary>
        [JsonPropertyName("additionalLocations")]
        public IList<AdditionalLocation> AdditionalLocations { get; set; }

        /// <summary>
        /// Custom properties of the API Management service.</br>Setting `Microsoft.WindowsAzure.ApiManagement.Gateway.Security.Ciphers.TripleDes168` will disable the cipher TLS_RSA_WITH_3DES_EDE_CBC_SHA for all TLS(1.0, 1.1 and 1.2).</br>Setting `Microsoft.WindowsAzure.ApiManagement.Gateway.Security.Protocols.Tls11` can be used to disable just TLS 1.1.</br>Setting `Microsoft.WindowsAzure.ApiManagement.Gateway.Security.Protocols.Tls10` can be used to disable TLS 1.0 on an API Management service.</br>Setting `Microsoft.WindowsAzure.ApiManagement.Gateway.Security.Backend.Protocols.Tls11` can be used to disable just TLS 1.1 for communications with backends.</br>Setting `Microsoft.WindowsAzure.ApiManagement.Gateway.Security.Backend.Protocols.Tls10` can be used to disable TLS 1.0 for communications with backends.</br>Setting `Microsoft.WindowsAzure.ApiManagement.Gateway.Protocols.Server.Http2` can be used to enable HTTP2 protocol on an API Management service.</br>Not specifying any of these properties on PATCH operation will reset omitted properties' values to their defaults. For all the settings except Http2 the default value is `True` if the service was created on or before April 1st 2018 and `False` otherwise. Http2 setting's default value is `False`.</br></br>You can disable any of next ciphers by using settings `Microsoft.WindowsAzure.ApiManagement.Gateway.Security.Ciphers.[cipher_name]`: TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA, TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA, TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA, TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA, TLS_RSA_WITH_AES_128_GCM_SHA256, TLS_RSA_WITH_AES_256_CBC_SHA256, TLS_RSA_WITH_AES_128_CBC_SHA256, TLS_RSA_WITH_AES_256_CBC_SHA, TLS_RSA_WITH_AES_128_CBC_SHA. For example, `Microsoft.WindowsAzure.ApiManagement.Gateway.Security.Ciphers.TLS_RSA_WITH_AES_128_CBC_SHA256`:`false`. The default value is `true` for them.  Note: next ciphers can't be disabled since they are required by Azure CloudService internal components: TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384,TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256,TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384,TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256,TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA384,TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA256,TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA384,TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA256,TLS_RSA_WITH_AES_256_GCM_SHA384
        /// </summary>
        [JsonPropertyName("customProperties")]
        public ApiManagementServiceBasePropertiesCustomProperties CustomProperties { get; set; }

        /// <summary>
        /// List of Certificates that need to be installed in the API Management service. Max supported certificates that can be installed is 10.
        /// </summary>
        [JsonPropertyName("certificates")]
        public IList<CertificateConfiguration> Certificates { get; set; }

        /// <summary>
        /// Property only meant to be used for Consumption SKU Service. This enforces a client certificate to be presented on each request to the gateway. This also enables the ability to authenticate the certificate in the policy on the gateway.
        /// </summary>
        [JsonPropertyName("enableClientCertificate")]
        public bool EnableClientCertificate { get; set; }

        /// <summary>
        /// Property can be used to enable NAT Gateway for this API Management service.
        /// </summary>
        [JsonPropertyName("natGatewayState")]
        public string NatGatewayState { get; set; }

        /// <summary>
        /// Outbound public IPV4 address prefixes associated with NAT Gateway deployed service. Available only for Premium SKU on stv2 platform.
        /// </summary>
        [JsonPropertyName("outboundPublicIPAddresses")]
        public IList<string> OutboundPublicIPAddresses { get; set; }

        /// <summary>
        /// Property only valid for an Api Management service deployed in multiple locations. This can be used to disable the gateway in master region.
        /// </summary>
        [JsonPropertyName("disableGateway")]
        public bool DisableGateway { get; set; }

        /// <summary>
        /// The type of VPN in which API Management service needs to be configured in. None (Default Value) means the API Management service is not part of any Virtual Network, External means the API Management deployment is set up inside a Virtual Network having an Internet Facing Endpoint, and Internal means that API Management deployment is setup inside a Virtual Network having an Intranet Facing Endpoint only.
        /// </summary>
        [JsonPropertyName("virtualNetworkType")]
        public string VirtualNetworkType { get; set; }

        /// <summary>
        /// Control Plane Apis version constraint for the API Management service.
        /// </summary>
        [JsonPropertyName("apiVersionConstraint")]
        public ApiVersionConstraint ApiVersionConstraint { get; set; }

        /// <summary>
        /// Undelete Api Management Service if it was previously soft-deleted. If this flag is specified and set to True all other properties will be ignored.
        /// </summary>
        [JsonPropertyName("restore")]
        public bool Restore { get; set; }

        /// <summary>
        /// List of Private Endpoint Connections of this service.
        /// </summary>
        [JsonPropertyName("privateEndpointConnections")]
        public IList<RemotePrivateEndpointConnectionWrapper> PrivateEndpointConnections { get; set; }

        /// <summary>
        /// Compute Platform Version running the service in this location.
        /// </summary>
        [JsonPropertyName("platformVersion")]
        public string PlatformVersion { get; set; }
    }
}