// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayRoutingRulePropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayRoutingRulePropertiesFormat
    {
        /// <summary>
        /// Rule type.
        /// </summary>
        [JsonPropertyName("ruleType")]
        public string RuleType { get; set; }

        /// <summary>
        /// Priority of the routing rule.
        /// </summary>
        [Required]
        [JsonPropertyName("priority")]
        public int Priority { get; set; }

        /// <summary>
        /// Backend address pool resource of the application gateway.
        /// </summary>
        [JsonPropertyName("backendAddressPool")]
        public SubResource BackendAddressPool { get; set; }

        /// <summary>
        /// Backend settings resource of the application gateway.
        /// </summary>
        [JsonPropertyName("backendSettings")]
        public SubResource BackendSettings { get; set; }

        /// <summary>
        /// Listener resource of the application gateway.
        /// </summary>
        [JsonPropertyName("listener")]
        public SubResource Listener { get; set; }

        /// <summary>
        /// The provisioning state of the request routing rule resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}