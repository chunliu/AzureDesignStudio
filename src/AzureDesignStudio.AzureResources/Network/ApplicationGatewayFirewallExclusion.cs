// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayFirewallExclusion
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayFirewallExclusion
    {
        /// <summary>
        /// The variable to be excluded.
        /// </summary>
        [Required]
        [JsonPropertyName("matchVariable")]
        public string MatchVariable { get; set; }

        /// <summary>
        /// When matchVariable is a collection, operate on the selector to specify which elements in the collection this exclusion applies to.
        /// </summary>
        [Required]
        [JsonPropertyName("selectorMatchOperator")]
        public string SelectorMatchOperator { get; set; }

        /// <summary>
        /// When matchVariable is a collection, operator used to specify which elements in the collection this exclusion applies to.
        /// </summary>
        [Required]
        [JsonPropertyName("selector")]
        public string Selector { get; set; }
    }
}