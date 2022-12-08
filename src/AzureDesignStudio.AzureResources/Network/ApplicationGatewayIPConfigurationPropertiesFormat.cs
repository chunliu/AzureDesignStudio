// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayIPConfigurationPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayIPConfigurationPropertiesFormat
    {
        /// <summary>
        /// Reference to the subnet resource. A subnet from where application gateway gets its private address.
        /// </summary>
        [JsonPropertyName("subnet")]
        public SubResource Subnet { get; set; }

        /// <summary>
        /// The provisioning state of the application gateway IP configuration resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}