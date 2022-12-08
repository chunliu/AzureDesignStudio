// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.ApiManagement
{
    /// <summary>
    /// AdditionalLocation
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class AdditionalLocation
    {
        /// <summary>
        /// The location name of the additional region among Azure Data center regions.
        /// </summary>
        [Required]
        [JsonPropertyName("location")]
        public string Location { get; set; }

        /// <summary>
        /// SKU properties of the API Management service.
        /// </summary>
        [Required]
        [JsonPropertyName("sku")]
        public ApiManagementServiceSkuProperties Sku { get; set; }

        /// <summary>
        /// A list of availability zones denoting where the resource needs to come from.
        /// </summary>
        [JsonPropertyName("zones")]
        public IList<string> Zones { get; set; }

        /// <summary>
        /// Public Static Load Balanced IP addresses of the API Management service in the additional location. Available only for Basic, Standard, Premium and Isolated SKU.
        /// </summary>
        [JsonPropertyName("publicIPAddresses")]
        public IList<string> PublicIPAddresses { get; set; }

        /// <summary>
        /// Private Static Load Balanced IP addresses of the API Management service which is deployed in an Internal Virtual Network in a particular additional location. Available only for Basic, Standard, Premium and Isolated SKU.
        /// </summary>
        [JsonPropertyName("privateIPAddresses")]
        public IList<string> PrivateIPAddresses { get; set; }

        /// <summary>
        /// Public Standard SKU IP V4 based IP address to be associated with Virtual Network deployed service in the location. Supported only for Premium SKU being deployed in Virtual Network.
        /// </summary>
        [JsonPropertyName("publicIpAddressId")]
        public string PublicIpAddressId { get; set; }

        /// <summary>
        /// Virtual network configuration for the location.
        /// </summary>
        [JsonPropertyName("virtualNetworkConfiguration")]
        public VirtualNetworkConfiguration VirtualNetworkConfiguration { get; set; }

        /// <summary>
        /// Gateway URL of the API Management service in the Region.
        /// </summary>
        [JsonPropertyName("gatewayRegionalUrl")]
        public string GatewayRegionalUrl { get; set; }

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
        /// Property only valid for an Api Management service deployed in multiple locations. This can be used to disable the gateway in this additional location.
        /// </summary>
        [JsonPropertyName("disableGateway")]
        public bool DisableGateway { get; set; }

        /// <summary>
        /// Compute Platform Version running the service.
        /// </summary>
        [JsonPropertyName("platformVersion")]
        public string PlatformVersion { get; set; }
    }
}