// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// VirtualMachineNetworkInterfaceIPConfiguration
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class VirtualMachineNetworkInterfaceIPConfiguration
    {
        /// <summary>
        /// The IP configuration name.
        /// </summary>
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Describes a virtual machine network interface IP configuration properties.
        /// </summary>
        [JsonPropertyName("properties")]
        public VirtualMachineNetworkInterfaceIPConfigurationProperties Properties { get; set; }
    }
}