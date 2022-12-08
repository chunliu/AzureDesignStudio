// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ServiceEndpointPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ServiceEndpointPropertiesFormat
    {
        /// <summary>
        /// The type of the endpoint service.
        /// </summary>
        [JsonPropertyName("service")]
        public string Service { get; set; }

        /// <summary>
        /// A list of locations.
        /// </summary>
        [JsonPropertyName("locations")]
        public IList<string> Locations { get; set; }

        /// <summary>
        /// The provisioning state of the service endpoint resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}