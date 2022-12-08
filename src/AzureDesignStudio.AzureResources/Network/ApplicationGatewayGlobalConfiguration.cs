// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayGlobalConfiguration
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayGlobalConfiguration
    {
        /// <summary>
        /// Enable request buffering.
        /// </summary>
        [JsonPropertyName("enableRequestBuffering")]
        public bool EnableRequestBuffering { get; set; }

        /// <summary>
        /// Enable response buffering.
        /// </summary>
        [JsonPropertyName("enableResponseBuffering")]
        public bool EnableResponseBuffering { get; set; }
    }
}