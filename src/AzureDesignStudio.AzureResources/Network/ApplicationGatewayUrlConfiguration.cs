// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayUrlConfiguration
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayUrlConfiguration
    {
        /// <summary>
        /// Url path which user has provided for url rewrite. Null means no path will be updated. Default value is null.
        /// </summary>
        [JsonPropertyName("modifiedPath")]
        public string ModifiedPath { get; set; }

        /// <summary>
        /// Query string which user has provided for url rewrite. Null means no query string will be updated. Default value is null.
        /// </summary>
        [JsonPropertyName("modifiedQueryString")]
        public string ModifiedQueryString { get; set; }

        /// <summary>
        /// If set as true, it will re-evaluate the url path map provided in path based request routing rules using modified path. Default value is false.
        /// </summary>
        [JsonPropertyName("reroute")]
        public bool Reroute { get; set; }
    }
}