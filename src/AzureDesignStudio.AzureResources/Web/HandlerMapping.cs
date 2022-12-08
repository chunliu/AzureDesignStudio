// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Web
{
    /// <summary>
    /// HandlerMapping
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class HandlerMapping
    {
        /// <summary>
        /// Requests with this extension will be handled using the specified FastCGI application.
        /// </summary>
        [JsonPropertyName("extension")]
        public string Extension { get; set; }

        /// <summary>
        /// The absolute path to the FastCGI application.
        /// </summary>
        [JsonPropertyName("scriptProcessor")]
        public string ScriptProcessor { get; set; }

        /// <summary>
        /// Command-line arguments to be passed to the script processor.
        /// </summary>
        [JsonPropertyName("arguments")]
        public string Arguments { get; set; }
    }
}