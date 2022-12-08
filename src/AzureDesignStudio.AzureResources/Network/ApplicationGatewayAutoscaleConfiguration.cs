// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayAutoscaleConfiguration
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayAutoscaleConfiguration
    {
        /// <summary>
        /// Lower bound on number of Application Gateway capacity.
        /// </summary>
        [Required]
        [JsonPropertyName("minCapacity")]
        public int MinCapacity { get; set; }

        /// <summary>
        /// Upper bound on number of Application Gateway capacity.
        /// </summary>
        [JsonPropertyName("maxCapacity")]
        public int MaxCapacity { get; set; }
    }
}