// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// AzureFirewallNatRuleCollectionProperties
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class AzureFirewallNatRuleCollectionProperties
    {
        /// <summary>
        /// Priority of the NAT rule collection resource.
        /// </summary>
        [JsonPropertyName("priority")]
        public int Priority { get; set; }

        /// <summary>
        /// The action type of a NAT rule collection.
        /// </summary>
        [JsonPropertyName("action")]
        public AzureFirewallNatRCAction Action { get; set; }

        /// <summary>
        /// Collection of rules used by a NAT rule collection.
        /// </summary>
        [JsonPropertyName("rules")]
        public IList<AzureFirewallNatRule> Rules { get; set; }

        /// <summary>
        /// The provisioning state of the NAT rule collection resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}