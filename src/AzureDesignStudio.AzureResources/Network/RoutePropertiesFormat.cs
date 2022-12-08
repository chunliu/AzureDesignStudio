// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// RoutePropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class RoutePropertiesFormat
    {
        /// <summary>
        /// The destination CIDR to which the route applies.
        /// </summary>
        [JsonPropertyName("addressPrefix")]
        public string AddressPrefix { get; set; }

        /// <summary>
        /// The type of Azure hop the packet should be sent to.
        /// </summary>
        [Required]
        [JsonPropertyName("nextHopType")]
        public string NextHopType { get; set; }

        /// <summary>
        /// The IP address packets should be forwarded to. Next hop values are only allowed in routes where the next hop type is VirtualAppliance.
        /// </summary>
        [JsonPropertyName("nextHopIpAddress")]
        public string NextHopIpAddress { get; set; }

        /// <summary>
        /// The provisioning state of the route resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// A value indicating whether this route overrides overlapping BGP routes regardless of LPM.
        /// </summary>
        [JsonPropertyName("hasBgpOverride")]
        public bool HasBgpOverride { get; set; }
    }
}