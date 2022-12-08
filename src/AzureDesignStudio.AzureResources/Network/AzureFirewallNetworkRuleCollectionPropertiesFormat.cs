// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// AzureFirewallNetworkRuleCollectionPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class AzureFirewallNetworkRuleCollectionPropertiesFormat
    {
        /// <summary>
        /// Priority of the network rule collection resource.
        /// </summary>
        [JsonPropertyName("priority")]
        public int Priority { get; set; }

        /// <summary>
        /// The action type of a rule collection.
        /// </summary>
        [JsonPropertyName("action")]
        public AzureFirewallRCAction Action { get; set; }

        /// <summary>
        /// Collection of rules used by a network rule collection.
        /// </summary>
        [JsonPropertyName("rules")]
        public IList<AzureFirewallNetworkRule> Rules { get; set; }

        /// <summary>
        /// The provisioning state of the network rule collection resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}