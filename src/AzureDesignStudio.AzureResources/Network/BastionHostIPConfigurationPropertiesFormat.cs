// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// BastionHostIPConfigurationPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class BastionHostIPConfigurationPropertiesFormat
    {
        /// <summary>
        /// Reference of the subnet resource.
        /// </summary>
        [Required]
        [JsonPropertyName("subnet")]
        public SubResource Subnet { get; set; }

        /// <summary>
        /// Reference of the PublicIP resource.
        /// </summary>
        [Required]
        [JsonPropertyName("publicIPAddress")]
        public SubResource PublicIPAddress { get; set; }

        /// <summary>
        /// The provisioning state of the bastion host IP configuration resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Private IP allocation method.
        /// </summary>
        [JsonPropertyName("privateIPAllocationMethod")]
        public string PrivateIPAllocationMethod { get; set; }
    }
}