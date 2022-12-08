// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// NetworkSecurityGroupPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class NetworkSecurityGroupPropertiesFormat
    {
        /// <summary>
        /// When enabled, flows created from Network Security Group connections will be re-evaluated when rules are updates. Initial enablement will trigger re-evaluation.
        /// </summary>
        [JsonPropertyName("flushConnection")]
        public bool FlushConnection { get; set; }

        /// <summary>
        /// A collection of security rules of the network security group.
        /// </summary>
        [JsonPropertyName("securityRules")]
        public IList<SecurityRule> SecurityRules { get; set; }

        /// <summary>
        /// The default security rules of network security group.
        /// </summary>
        [JsonPropertyName("defaultSecurityRules")]
        public IList<SecurityRule> DefaultSecurityRules { get; set; }

        /// <summary>
        /// A collection of references to network interfaces.
        /// </summary>
        [JsonPropertyName("networkInterfaces")]
        public IList<NetworkInterface> NetworkInterfaces { get; set; }

        /// <summary>
        /// A collection of references to subnets.
        /// </summary>
        [JsonPropertyName("subnets")]
        public IList<Subnet> Subnets { get; set; }

        /// <summary>
        /// A collection of references to flow log resources.
        /// </summary>
        [JsonPropertyName("flowLogs")]
        public IList<FlowLog> FlowLogs { get; set; }

        /// <summary>
        /// The resource GUID property of the network security group resource.
        /// </summary>
        [JsonPropertyName("resourceGuid")]
        public string ResourceGuid { get; set; }

        /// <summary>
        /// The provisioning state of the network security group resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}