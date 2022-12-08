// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayListenerPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayListenerPropertiesFormat
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
        /// Protocol of the listener.
        /// </summary>
        [JsonPropertyName("protocol")]
        public string Protocol { get; set; }

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
        /// The provisioning state of the listener resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}