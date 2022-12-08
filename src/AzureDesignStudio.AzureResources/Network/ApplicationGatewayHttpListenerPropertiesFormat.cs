// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayHttpListenerPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayHttpListenerPropertiesFormat
    {
        /// <summary>
        /// Frontend IP configuration resource of an application gateway.
        /// </summary>
        [JsonPropertyName("frontendIPConfiguration")]
        public SubResource FrontendIPConfiguration { get; set; }

        /// <summary>
        /// Frontend port resource of an application gateway.
        /// </summary>
        [JsonPropertyName("frontendPort")]
        public SubResource FrontendPort { get; set; }

        /// <summary>
        /// Protocol of the HTTP listener.
        /// </summary>
        [JsonPropertyName("protocol")]
        public string Protocol { get; set; }

        /// <summary>
        /// Host name of HTTP listener.
        /// </summary>
        [JsonPropertyName("hostName")]
        public string HostName { get; set; }

        /// <summary>
        /// SSL certificate resource of an application gateway.
        /// </summary>
        [JsonPropertyName("sslCertificate")]
        public SubResource SslCertificate { get; set; }

        /// <summary>
        /// SSL profile resource of the application gateway.
        /// </summary>
        [JsonPropertyName("sslProfile")]
        public SubResource SslProfile { get; set; }

        /// <summary>
        /// Applicable only if protocol is https. Enables SNI for multi-hosting.
        /// </summary>
        [JsonPropertyName("requireServerNameIndication")]
        public bool RequireServerNameIndication { get; set; }

        /// <summary>
        /// The provisioning state of the HTTP listener resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Custom error configurations of the HTTP listener.
        /// </summary>
        [JsonPropertyName("customErrorConfigurations")]
        public IList<ApplicationGatewayCustomError> CustomErrorConfigurations { get; set; }

        /// <summary>
        /// Reference to the FirewallPolicy resource.
        /// </summary>
        [JsonPropertyName("firewallPolicy")]
        public SubResource FirewallPolicy { get; set; }

        /// <summary>
        /// List of Host names for HTTP Listener that allows special wildcard characters as well.
        /// </summary>
        [JsonPropertyName("hostNames")]
        public IList<string> HostNames { get; set; }
    }
}