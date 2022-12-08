// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Storage
{
    /// <summary>
    /// NetworkRuleSet
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class NetworkRuleSet
    {
        /// <summary>
        /// Specifies whether traffic is bypassed for Logging/Metrics/AzureServices. Possible values are any combination of Logging|Metrics|AzureServices (For example, "Logging, Metrics"), or None to bypass none of those traffics.
        /// </summary>
        [JsonPropertyName("bypass")]
        public string Bypass { get; set; }

        /// <summary>
        /// Sets the resource access rules
        /// </summary>
        [JsonPropertyName("resourceAccessRules")]
        public IList<ResourceAccessRule> ResourceAccessRules { get; set; }

        /// <summary>
        /// Sets the virtual network rules
        /// </summary>
        [JsonPropertyName("virtualNetworkRules")]
        public IList<VirtualNetworkRule> VirtualNetworkRules { get; set; }

        /// <summary>
        /// Sets the IP ACL rules
        /// </summary>
        [JsonPropertyName("ipRules")]
        public IList<IPRule> IpRules { get; set; }

        /// <summary>
        /// Specifies the default action of allow or deny when no other rules match.
        /// </summary>
        [Required]
        [JsonPropertyName("defaultAction")]
        public string DefaultAction { get; set; }
    }
}