// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// AzureFirewallApplicationRuleCollectionPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class AzureFirewallApplicationRuleCollectionPropertiesFormat
    {
        /// <summary>
        /// Priority of the application rule collection resource.
        /// </summary>
        [JsonPropertyName("priority")]
        public int Priority { get; set; }

        /// <summary>
        /// The action type of a rule collection.
        /// </summary>
        [JsonPropertyName("action")]
        public AzureFirewallRCAction Action { get; set; }

        /// <summary>
        /// Collection of rules used by a application rule collection.
        /// </summary>
        [JsonPropertyName("rules")]
        public IList<AzureFirewallApplicationRule> Rules { get; set; }

        /// <summary>
        /// The provisioning state of the application rule collection resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}