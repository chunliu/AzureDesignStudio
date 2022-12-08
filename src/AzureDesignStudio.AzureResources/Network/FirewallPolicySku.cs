// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// FirewallPolicySku
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class FirewallPolicySku
    {
        /// <summary>
        /// Tier of Firewall Policy.
        /// </summary>
        [JsonPropertyName("tier")]
        public string Tier { get; set; }
    }
}