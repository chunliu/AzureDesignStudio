// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayProbePropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayProbePropertiesFormat
    {
        /// <summary>
        /// The protocol used for the probe.
        /// </summary>
        [JsonPropertyName("protocol")]
        public string Protocol { get; set; }

        /// <summary>
        /// Host name to send the probe to.
        /// </summary>
        [JsonPropertyName("host")]
        public string Host { get; set; }

        /// <summary>
        /// Relative path of probe. Valid path starts from '/'. Probe is sent to <Protocol>://<host>:<port><path>.
        /// </summary>
        [JsonPropertyName("path")]
        public string Path { get; set; }

        /// <summary>
        /// The probing interval in seconds. This is the time interval between two consecutive probes. Acceptable values are from 1 second to 86400 seconds.
        /// </summary>
        [JsonPropertyName("interval")]
        public int Interval { get; set; }

        /// <summary>
        /// The probe timeout in seconds. Probe marked as failed if valid response is not received with this timeout period. Acceptable values are from 1 second to 86400 seconds.
        /// </summary>
        [JsonPropertyName("timeout")]
        public int Timeout { get; set; }

        /// <summary>
        /// The probe retry count. Backend server is marked down after consecutive probe failure count reaches UnhealthyThreshold. Acceptable values are from 1 second to 20.
        /// </summary>
        [JsonPropertyName("unhealthyThreshold")]
        public int UnhealthyThreshold { get; set; }

        /// <summary>
        /// Whether the host header should be picked from the backend http settings. Default value is false.
        /// </summary>
        [JsonPropertyName("pickHostNameFromBackendHttpSettings")]
        public bool PickHostNameFromBackendHttpSettings { get; set; }

        /// <summary>
        /// Whether the server name indication should be picked from the backend settings for Tls protocol. Default value is false.
        /// </summary>
        [JsonPropertyName("pickHostNameFromBackendSettings")]
        public bool PickHostNameFromBackendSettings { get; set; }

        /// <summary>
        /// Minimum number of servers that are always marked healthy. Default value is 0.
        /// </summary>
        [JsonPropertyName("minServers")]
        public int MinServers { get; set; }

        /// <summary>
        /// Criterion for classifying a healthy probe response.
        /// </summary>
        [JsonPropertyName("match")]
        public ApplicationGatewayProbeHealthResponseMatch Match { get; set; }

        /// <summary>
        /// The provisioning state of the probe resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Custom port which will be used for probing the backend servers. The valid value ranges from 1 to 65535. In case not set, port from http settings will be used. This property is valid for Standard_v2 and WAF_v2 only.
        /// </summary>
        [JsonPropertyName("port")]
        public int Port { get; set; }
    }
}