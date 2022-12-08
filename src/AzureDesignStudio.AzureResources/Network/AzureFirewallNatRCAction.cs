// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// AzureFirewallNatRCAction
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class AzureFirewallNatRCAction
    {
        /// <summary>
        /// The type of action.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}