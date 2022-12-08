// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayLoadDistributionTargetPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayLoadDistributionTargetPropertiesFormat
    {
        /// <summary>
        /// Weight per server. Range between 1 and 100.
        /// </summary>
        [JsonPropertyName("weightPerServer")]
        public int WeightPerServer { get; set; }

        /// <summary>
        /// Backend address pool resource of the application gateway.
        /// </summary>
        [JsonPropertyName("backendAddressPool")]
        public SubResource BackendAddressPool { get; set; }
    }
}