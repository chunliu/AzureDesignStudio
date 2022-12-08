// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// VirtualMachinePublicIPAddressConfiguration
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class VirtualMachinePublicIPAddressConfiguration
    {
        /// <summary>
        /// The publicIP address configuration name.
        /// </summary>
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Describes a virtual machines IP Configuration's PublicIPAddress configuration
        /// </summary>
        [JsonPropertyName("properties")]
        public VirtualMachinePublicIPAddressConfigurationProperties Properties { get; set; }

        /// <summary>
        /// Describes the public IP Sku. It can only be set with OrchestrationMode as Flexible.
        /// </summary>
        [JsonPropertyName("sku")]
        public PublicIPAddressSku Sku { get; set; }
    }
}