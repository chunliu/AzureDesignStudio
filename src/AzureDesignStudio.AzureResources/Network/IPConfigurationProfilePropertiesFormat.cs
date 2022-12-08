// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// IPConfigurationProfilePropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class IPConfigurationProfilePropertiesFormat
    {
        /// <summary>
        /// The reference to the subnet resource to create a container network interface ip configuration.
        /// </summary>
        [JsonPropertyName("subnet")]
        public Subnet Subnet { get; set; }

        /// <summary>
        /// The provisioning state of the IP configuration profile resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}