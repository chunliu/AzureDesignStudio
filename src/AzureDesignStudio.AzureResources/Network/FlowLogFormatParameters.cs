// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// FlowLogFormatParameters
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class FlowLogFormatParameters
    {
        /// <summary>
        /// The file type of flow log.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The version (revision) of the flow log.
        /// </summary>
        [JsonPropertyName("version")]
        public int Version { get; set; }
    }
}