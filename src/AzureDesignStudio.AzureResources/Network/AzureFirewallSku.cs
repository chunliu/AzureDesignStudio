// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// AzureFirewallSku
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class AzureFirewallSku
    {
        /// <summary>
        /// Name of an Azure Firewall SKU.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Tier of an Azure Firewall.
        /// </summary>
        [JsonPropertyName("tier")]
        public string Tier { get; set; }
    }
}