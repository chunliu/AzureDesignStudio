// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// NetworkProfile
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class NetworkProfile
    {
        /// <summary>
        /// Specifies the list of resource Ids for the network interfaces associated with the virtual machine.
        /// </summary>
        [JsonPropertyName("networkInterfaces")]
        public IList<NetworkInterfaceReference> NetworkInterfaces { get; set; }

        /// <summary>
        /// specifies the Microsoft.Network API version used when creating networking resources in the Network Interface Configurations
        /// </summary>
        [JsonPropertyName("networkApiVersion")]
        public string NetworkApiVersion { get; set; }

        /// <summary>
        /// Specifies the networking configurations that will be used to create the virtual machine networking resources.
        /// </summary>
        [JsonPropertyName("networkInterfaceConfigurations")]
        public IList<VirtualMachineNetworkInterfaceConfiguration> NetworkInterfaceConfigurations { get; set; }
    }
}