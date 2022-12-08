// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayPrivateLinkConfigurationProperties
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayPrivateLinkConfigurationProperties
    {
        /// <summary>
        /// An array of application gateway private link ip configurations.
        /// </summary>
        [JsonPropertyName("ipConfigurations")]
        public IList<ApplicationGatewayPrivateLinkIpConfiguration> IpConfigurations { get; set; }

        /// <summary>
        /// The provisioning state of the application gateway private link configuration.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}