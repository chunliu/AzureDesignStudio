// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewaySslPolicy
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewaySslPolicy
    {
        /// <summary>
        /// Ssl protocols to be disabled on application gateway.
        /// </summary>
        [JsonPropertyName("disabledSslProtocols")]
        public IList<string> DisabledSslProtocols { get; set; }

        /// <summary>
        /// Type of Ssl Policy.
        /// </summary>
        [JsonPropertyName("policyType")]
        public string PolicyType { get; set; }

        /// <summary>
        /// Name of Ssl predefined policy.
        /// </summary>
        [JsonPropertyName("policyName")]
        public string PolicyName { get; set; }

        /// <summary>
        /// Ssl cipher suites to be enabled in the specified order to application gateway.
        /// </summary>
        [JsonPropertyName("cipherSuites")]
        public IList<string> CipherSuites { get; set; }

        /// <summary>
        /// Minimum version of Ssl protocol to be supported on application gateway.
        /// </summary>
        [JsonPropertyName("minProtocolVersion")]
        public string MinProtocolVersion { get; set; }
    }
}