// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.ApiManagement
{
    /// <summary>
    /// VirtualNetworkConfiguration
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class VirtualNetworkConfiguration
    {
        /// <summary>
        /// The virtual network ID. This is typically a GUID. Expect a null GUID by default.
        /// </summary>
        [JsonPropertyName("vnetid")]
        public string Vnetid { get; set; }

        /// <summary>
        /// The name of the subnet.
        /// </summary>
        [JsonPropertyName("subnetname")]
        public string Subnetname { get; set; }

        /// <summary>
        /// The full resource ID of a subnet in a virtual network to deploy the API Management service in.
        /// </summary>
        [JsonPropertyName("subnetResourceId")]
        public string SubnetResourceId { get; set; }
    }
}