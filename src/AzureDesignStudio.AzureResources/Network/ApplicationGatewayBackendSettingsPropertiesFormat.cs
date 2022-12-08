// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayBackendSettingsPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayBackendSettingsPropertiesFormat
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
        /// Connection timeout in seconds. Application Gateway will fail the request if response is not received within ConnectionTimeout. Acceptable values are from 1 second to 86400 seconds.
        /// </summary>
        [JsonPropertyName("timeout")]
        public int Timeout { get; set; }

        /// <summary>
        /// Probe resource of an application gateway.
        /// </summary>
        [JsonPropertyName("probe")]
        public SubResource Probe { get; set; }

        /// <summary>
        /// Array of references to application gateway trusted root certificates.
        /// </summary>
        [JsonPropertyName("trustedRootCertificates")]
        public IList<SubResource> TrustedRootCertificates { get; set; }

        /// <summary>
        /// Server name indication to be sent to the backend servers for Tls protocol.
        /// </summary>
        [JsonPropertyName("hostName")]
        public string HostName { get; set; }

        /// <summary>
        /// Whether to pick server name indication from the host name of the backend server for Tls protocol. Default value is false.
        /// </summary>
        [JsonPropertyName("pickHostNameFromBackendAddress")]
        public bool PickHostNameFromBackendAddress { get; set; }

        /// <summary>
        /// The provisioning state of the backend HTTP settings resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}