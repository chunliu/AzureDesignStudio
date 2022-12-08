// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// NatGatewayPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class NatGatewayPropertiesFormat
    {
        /// <summary>
        /// The idle timeout of the nat gateway.
        /// </summary>
        [JsonPropertyName("idleTimeoutInMinutes")]
        public int IdleTimeoutInMinutes { get; set; }

        /// <summary>
        /// An array of public ip addresses associated with the nat gateway resource.
        /// </summary>
        [JsonPropertyName("publicIpAddresses")]
        public IList<SubResource> PublicIpAddresses { get; set; }

        /// <summary>
        /// An array of public ip prefixes associated with the nat gateway resource.
        /// </summary>
        [JsonPropertyName("publicIpPrefixes")]
        public IList<SubResource> PublicIpPrefixes { get; set; }

        /// <summary>
        /// An array of references to the subnets using this nat gateway resource.
        /// </summary>
        [JsonPropertyName("subnets")]
        public IList<SubResource> Subnets { get; set; }

        /// <summary>
        /// The resource GUID property of the NAT gateway resource.
        /// </summary>
        [JsonPropertyName("resourceGuid")]
        public string ResourceGuid { get; set; }

        /// <summary>
        /// The provisioning state of the NAT gateway resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}