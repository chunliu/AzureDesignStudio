// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// VirtualMachineNetworkInterfaceConfiguration
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class VirtualMachineNetworkInterfaceConfiguration
    {
        /// <summary>
        /// The network interface configuration name.
        /// </summary>
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Describes a virtual machine network profile's IP configuration.
        /// </summary>
        [JsonPropertyName("properties")]
        public VirtualMachineNetworkInterfaceConfigurationProperties Properties { get; set; }
    }
}