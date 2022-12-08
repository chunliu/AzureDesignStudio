// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayConnectionDraining
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayConnectionDraining
    {
        /// <summary>
        /// Whether connection draining is enabled or not.
        /// </summary>
        [Required]
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// The number of seconds connection draining is active. Acceptable values are from 1 second to 3600 seconds.
        /// </summary>
        [Required]
        [JsonPropertyName("drainTimeoutInSec")]
        public int DrainTimeoutInSec { get; set; }
    }
}