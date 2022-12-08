// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayFirewallDisabledRuleGroup
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayFirewallDisabledRuleGroup
    {
        /// <summary>
        /// The name of the rule group that will be disabled.
        /// </summary>
        [Required]
        [JsonPropertyName("ruleGroupName")]
        public string RuleGroupName { get; set; }

        /// <summary>
        /// The list of rules that will be disabled. If null, all rules of the rule group will be disabled.
        /// </summary>
        [JsonPropertyName("rules")]
        public IList<int> Rules { get; set; }
    }
}