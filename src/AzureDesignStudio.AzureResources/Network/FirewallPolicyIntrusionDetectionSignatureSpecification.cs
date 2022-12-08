// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// FirewallPolicyIntrusionDetectionSignatureSpecification
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class FirewallPolicyIntrusionDetectionSignatureSpecification
    {
        /// <summary>
        /// Signature id.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The signature state.
        /// </summary>
        [JsonPropertyName("mode")]
        public string Mode { get; set; }
    }
}