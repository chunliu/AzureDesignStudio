// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// HubIPAddresses
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class HubIPAddresses
    {
        /// <summary>
        /// Public IP addresses associated with azure firewall.
        /// </summary>
        [JsonPropertyName("publicIPs")]
        public HubPublicIPAddresses PublicIPs { get; set; }

        /// <summary>
        /// Private IP Address associated with azure firewall.
        /// </summary>
        [JsonPropertyName("privateIPAddress")]
        public string PrivateIPAddress { get; set; }
    }
}