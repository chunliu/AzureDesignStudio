// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// InboundNatRulePropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class InboundNatRulePropertiesFormat
    {
        /// <summary>
        /// A reference to frontend IP addresses.
        /// </summary>
        [JsonPropertyName("frontendIPConfiguration")]
        public SubResource FrontendIPConfiguration { get; set; }

        /// <summary>
        /// A reference to a private IP address defined on a network interface of a VM. Traffic sent to the frontend port of each of the frontend IP configurations is forwarded to the backend IP.
        /// </summary>
        [JsonPropertyName("backendIPConfiguration")]
        public NetworkInterfaceIPConfiguration BackendIPConfiguration { get; set; }

        /// <summary>
        /// The reference to the transport protocol used by the load balancing rule.
        /// </summary>
        [JsonPropertyName("protocol")]
        public string Protocol { get; set; }

        /// <summary>
        /// The port for the external endpoint. Port numbers for each rule must be unique within the Load Balancer. Acceptable values range from 1 to 65534.
        /// </summary>
        [JsonPropertyName("frontendPort")]
        public int FrontendPort { get; set; }

        /// <summary>
        /// The port used for the internal endpoint. Acceptable values range from 1 to 65535.
        /// </summary>
        [JsonPropertyName("backendPort")]
        public int BackendPort { get; set; }

        /// <summary>
        /// The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes. This element is only used when the protocol is set to TCP.
        /// </summary>
        [JsonPropertyName("idleTimeoutInMinutes")]
        public int IdleTimeoutInMinutes { get; set; }

        /// <summary>
        /// Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed after you create the endpoint.
        /// </summary>
        [JsonPropertyName("enableFloatingIP")]
        public bool EnableFloatingIP { get; set; }

        /// <summary>
        /// Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used when the protocol is set to TCP.
        /// </summary>
        [JsonPropertyName("enableTcpReset")]
        public bool EnableTcpReset { get; set; }

        /// <summary>
        /// The port range start for the external endpoint. This property is used together with BackendAddressPool and FrontendPortRangeEnd. Individual inbound NAT rule port mappings will be created for each backend address from BackendAddressPool. Acceptable values range from 1 to 65534.
        /// </summary>
        [JsonPropertyName("frontendPortRangeStart")]
        public int FrontendPortRangeStart { get; set; }

        /// <summary>
        /// The port range end for the external endpoint. This property is used together with BackendAddressPool and FrontendPortRangeStart. Individual inbound NAT rule port mappings will be created for each backend address from BackendAddressPool. Acceptable values range from 1 to 65534.
        /// </summary>
        [JsonPropertyName("frontendPortRangeEnd")]
        public int FrontendPortRangeEnd { get; set; }

        /// <summary>
        /// A reference to backendAddressPool resource.
        /// </summary>
        [JsonPropertyName("backendAddressPool")]
        public SubResource BackendAddressPool { get; set; }

        /// <summary>
        /// The provisioning state of the inbound NAT rule resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}