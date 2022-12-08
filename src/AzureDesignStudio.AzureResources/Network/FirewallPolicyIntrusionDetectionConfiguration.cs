// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// FirewallPolicyIntrusionDetectionConfiguration
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class FirewallPolicyIntrusionDetectionConfiguration
    {
        /// <summary>
        /// List of specific signatures states.
        /// </summary>
        [JsonPropertyName("signatureOverrides")]
        public IList<FirewallPolicyIntrusionDetectionSignatureSpecification> SignatureOverrides { get; set; }

        /// <summary>
        /// List of rules for traffic to bypass.
        /// </summary>
        [JsonPropertyName("bypassTrafficSettings")]
        public IList<FirewallPolicyIntrusionDetectionBypassTrafficSpecifications> BypassTrafficSettings { get; set; }

        /// <summary>
        /// IDPS Private IP address ranges are used to identify traffic direction (i.e. inbound, outbound, etc.). By default, only ranges defined by IANA RFC 1918 are considered private IP addresses. To modify default ranges, specify your Private IP address ranges with this property
        /// </summary>
        [JsonPropertyName("privateRanges")]
        public IList<string> PrivateRanges { get; set; }
    }
}