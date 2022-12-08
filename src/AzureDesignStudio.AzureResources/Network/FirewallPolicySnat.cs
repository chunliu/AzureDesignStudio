// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// FirewallPolicySnat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class FirewallPolicySnat
    {
        /// <summary>
        /// List of private IP addresses/IP address ranges to not be SNAT.
        /// </summary>
        [JsonPropertyName("privateRanges")]
        public IList<string> PrivateRanges { get; set; }

        /// <summary>
        /// The operation mode for automatically learning private ranges to not be SNAT
        /// </summary>
        [JsonPropertyName("autoLearnPrivateRanges")]
        public string AutoLearnPrivateRanges { get; set; }
    }
}