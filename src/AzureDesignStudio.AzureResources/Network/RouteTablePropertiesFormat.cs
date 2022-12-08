// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// RouteTablePropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class RouteTablePropertiesFormat
    {
        /// <summary>
        /// Collection of routes contained within a route table.
        /// </summary>
        [JsonPropertyName("routes")]
        public IList<Route> Routes { get; set; }

        /// <summary>
        /// A collection of references to subnets.
        /// </summary>
        [JsonPropertyName("subnets")]
        public IList<Subnet> Subnets { get; set; }

        /// <summary>
        /// Whether to disable the routes learned by BGP on that route table. True means disable.
        /// </summary>
        [JsonPropertyName("disableBgpRoutePropagation")]
        public bool DisableBgpRoutePropagation { get; set; }

        /// <summary>
        /// The provisioning state of the route table resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// The resource GUID property of the route table.
        /// </summary>
        [JsonPropertyName("resourceGuid")]
        public string ResourceGuid { get; set; }
    }
}