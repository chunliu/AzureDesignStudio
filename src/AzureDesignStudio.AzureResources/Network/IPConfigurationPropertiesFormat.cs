// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// IPConfigurationPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class IPConfigurationPropertiesFormat
    {
        /// <summary>
        /// The private IP address of the IP configuration.
        /// </summary>
        [JsonPropertyName("privateIPAddress")]
        public string PrivateIPAddress { get; set; }

        /// <summary>
        /// The private IP address allocation method.
        /// </summary>
        [JsonPropertyName("privateIPAllocationMethod")]
        public string PrivateIPAllocationMethod { get; set; }

        /// <summary>
        /// The reference to the subnet resource.
        /// </summary>
        [JsonPropertyName("subnet")]
        public Subnet Subnet { get; set; }

        /// <summary>
        /// The reference to the public IP resource.
        /// </summary>
        [JsonPropertyName("publicIPAddress")]
        public PublicIPAddress PublicIPAddress { get; set; }

        /// <summary>
        /// The provisioning state of the IP configuration resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}