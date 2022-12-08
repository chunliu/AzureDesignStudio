// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// FirewallPolicyTransportSecurity
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class FirewallPolicyTransportSecurity
    {
        /// <summary>
        /// The CA used for intermediate CA generation.
        /// </summary>
        [JsonPropertyName("certificateAuthority")]
        public FirewallPolicyCertificateAuthority CertificateAuthority { get; set; }
    }
}