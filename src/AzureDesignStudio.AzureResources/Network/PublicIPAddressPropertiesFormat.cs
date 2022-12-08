// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// PublicIPAddressPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class PublicIPAddressPropertiesFormat
    {
        /// <summary>
        /// The public IP address allocation method.
        /// </summary>
        [JsonPropertyName("publicIPAllocationMethod")]
        public string PublicIPAllocationMethod { get; set; }

        /// <summary>
        /// The public IP address version.
        /// </summary>
        [JsonPropertyName("publicIPAddressVersion")]
        public string PublicIPAddressVersion { get; set; }

        /// <summary>
        /// The IP configuration associated with the public IP address.
        /// </summary>
        [JsonPropertyName("ipConfiguration")]
        public IPConfiguration IpConfiguration { get; set; }

        /// <summary>
        /// The FQDN of the DNS record associated with the public IP address.
        /// </summary>
        [JsonPropertyName("dnsSettings")]
        public PublicIPAddressDnsSettings DnsSettings { get; set; }

        /// <summary>
        /// The DDoS protection custom policy associated with the public IP address.
        /// </summary>
        [JsonPropertyName("ddosSettings")]
        public DdosSettings DdosSettings { get; set; }

        /// <summary>
        /// The list of tags associated with the public IP address.
        /// </summary>
        [JsonPropertyName("ipTags")]
        public IList<IpTag> IpTags { get; set; }

        /// <summary>
        /// The IP address associated with the public IP address resource.
        /// </summary>
        [JsonPropertyName("ipAddress")]
        public string IpAddress { get; set; }

        /// <summary>
        /// The Public IP Prefix this Public IP Address should be allocated from.
        /// </summary>
        [JsonPropertyName("publicIPPrefix")]
        public SubResource PublicIPPrefix { get; set; }

        /// <summary>
        /// The idle timeout of the public IP address.
        /// </summary>
        [JsonPropertyName("idleTimeoutInMinutes")]
        public int IdleTimeoutInMinutes { get; set; }

        /// <summary>
        /// The resource GUID property of the public IP address resource.
        /// </summary>
        [JsonPropertyName("resourceGuid")]
        public string ResourceGuid { get; set; }

        /// <summary>
        /// The provisioning state of the public IP address resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// The service public IP address of the public IP address resource.
        /// </summary>
        [JsonPropertyName("servicePublicIPAddress")]
        public PublicIPAddress ServicePublicIPAddress { get; set; }

        /// <summary>
        /// The NatGateway for the Public IP address.
        /// </summary>
        [JsonPropertyName("natGateway")]
        public NatGateway NatGateway { get; set; }

        /// <summary>
        /// Migration phase of Public IP Address.
        /// </summary>
        [JsonPropertyName("migrationPhase")]
        public string MigrationPhase { get; set; }

        /// <summary>
        /// The linked public IP address of the public IP address resource.
        /// </summary>
        [JsonPropertyName("linkedPublicIPAddress")]
        public PublicIPAddress LinkedPublicIPAddress { get; set; }

        /// <summary>
        /// Specify what happens to the public IP address when the VM using it is deleted
        /// </summary>
        [JsonPropertyName("deleteOption")]
        public string DeleteOption { get; set; }
    }
}