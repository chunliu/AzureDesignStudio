// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayBackendHttpSettingsPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayBackendHttpSettingsPropertiesFormat
    {
        /// <summary>
        /// The destination port on the backend.
        /// </summary>
        [JsonPropertyName("port")]
        public int Port { get; set; }

        /// <summary>
        /// The protocol used to communicate with the backend.
        /// </summary>
        [JsonPropertyName("protocol")]
        public string Protocol { get; set; }

        /// <summary>
        /// Cookie based affinity.
        /// </summary>
        [JsonPropertyName("cookieBasedAffinity")]
        public string CookieBasedAffinity { get; set; }

        /// <summary>
        /// Request timeout in seconds. Application Gateway will fail the request if response is not received within RequestTimeout. Acceptable values are from 1 second to 86400 seconds.
        /// </summary>
        [JsonPropertyName("requestTimeout")]
        public int RequestTimeout { get; set; }

        /// <summary>
        /// Probe resource of an application gateway.
        /// </summary>
        [JsonPropertyName("probe")]
        public SubResource Probe { get; set; }

        /// <summary>
        /// Array of references to application gateway authentication certificates.
        /// </summary>
        [JsonPropertyName("authenticationCertificates")]
        public IList<SubResource> AuthenticationCertificates { get; set; }

        /// <summary>
        /// Array of references to application gateway trusted root certificates.
        /// </summary>
        [JsonPropertyName("trustedRootCertificates")]
        public IList<SubResource> TrustedRootCertificates { get; set; }

        /// <summary>
        /// Connection draining of the backend http settings resource.
        /// </summary>
        [JsonPropertyName("connectionDraining")]
        public ApplicationGatewayConnectionDraining ConnectionDraining { get; set; }

        /// <summary>
        /// Host header to be sent to the backend servers.
        /// </summary>
        [JsonPropertyName("hostName")]
        public string HostName { get; set; }

        /// <summary>
        /// Whether to pick host header should be picked from the host name of the backend server. Default value is false.
        /// </summary>
        [JsonPropertyName("pickHostNameFromBackendAddress")]
        public bool PickHostNameFromBackendAddress { get; set; }

        /// <summary>
        /// Cookie name to use for the affinity cookie.
        /// </summary>
        [JsonPropertyName("affinityCookieName")]
        public string AffinityCookieName { get; set; }

        /// <summary>
        /// Whether the probe is enabled. Default value is false.
        /// </summary>
        [JsonPropertyName("probeEnabled")]
        public bool ProbeEnabled { get; set; }

        /// <summary>
        /// Path which should be used as a prefix for all HTTP requests. Null means no path will be prefixed. Default value is null.
        /// </summary>
        [JsonPropertyName("path")]
        public string Path { get; set; }

        /// <summary>
        /// The provisioning state of the backend HTTP settings resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}