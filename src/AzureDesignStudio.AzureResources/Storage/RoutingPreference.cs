// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Storage
{
    /// <summary>
    /// RoutingPreference
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class RoutingPreference
    {
        /// <summary>
        /// Routing Choice defines the kind of network routing opted by the user.
        /// </summary>
        [JsonPropertyName("routingChoice")]
        public string RoutingChoice { get; set; }

        /// <summary>
        /// A boolean flag which indicates whether microsoft routing storage endpoints are to be published
        /// </summary>
        [JsonPropertyName("publishMicrosoftEndpoints")]
        public bool PublishMicrosoftEndpoints { get; set; }

        /// <summary>
        /// A boolean flag which indicates whether internet routing storage endpoints are to be published
        /// </summary>
        [JsonPropertyName("publishInternetEndpoints")]
        public bool PublishInternetEndpoints { get; set; }
    }
}