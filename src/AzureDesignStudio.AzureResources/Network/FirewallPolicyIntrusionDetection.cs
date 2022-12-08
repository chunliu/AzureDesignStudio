// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// FirewallPolicyIntrusionDetection
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class FirewallPolicyIntrusionDetection
    {
        /// <summary>
        /// Intrusion detection general state.
        /// </summary>
        [JsonPropertyName("mode")]
        public string Mode { get; set; }

        /// <summary>
        /// Intrusion detection configuration properties.
        /// </summary>
        [JsonPropertyName("configuration")]
        public FirewallPolicyIntrusionDetectionConfiguration Configuration { get; set; }
    }
}