// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// VirtualNetworkEncryption
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class VirtualNetworkEncryption
    {
        /// <summary>
        /// Indicates if encryption is enabled on the virtual network.
        /// </summary>
        [Required]
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// If the encrypted VNet allows VM that does not support encryption
        /// </summary>
        [JsonPropertyName("enforcement")]
        public string Enforcement { get; set; }
    }
}