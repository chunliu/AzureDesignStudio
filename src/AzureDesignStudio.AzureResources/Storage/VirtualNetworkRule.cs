// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Storage
{
    /// <summary>
    /// VirtualNetworkRule
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class VirtualNetworkRule
    {
        /// <summary>
        /// Resource ID of a subnet, for example: /subscriptions/{subscriptionId}/resourceGroups/{groupName}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}.
        /// </summary>
        [Required]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The action of virtual network rule.
        /// </summary>
        [JsonPropertyName("action")]
        public string Action { get; set; }

        /// <summary>
        /// Gets the state of virtual network rule.
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }
    }
}