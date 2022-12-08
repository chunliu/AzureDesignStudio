// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// VirtualNetworkBgpCommunities
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class VirtualNetworkBgpCommunities
    {
        /// <summary>
        /// The BGP community associated with the virtual network.
        /// </summary>
        [Required]
        [JsonPropertyName("virtualNetworkCommunity")]
        public string VirtualNetworkCommunity { get; set; }

        /// <summary>
        /// The BGP community associated with the region of the virtual network.
        /// </summary>
        [JsonPropertyName("regionalCommunity")]
        public string RegionalCommunity { get; set; }
    }
}