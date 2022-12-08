// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Web
{
    /// <summary>
    /// StatusCodesBasedTrigger
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class StatusCodesBasedTrigger
    {
        /// <summary>
        /// HTTP status code.
        /// </summary>
        [JsonPropertyName("status")]
        public int Status { get; set; }

        /// <summary>
        /// Request Sub Status.
        /// </summary>
        [JsonPropertyName("subStatus")]
        public int SubStatus { get; set; }

        /// <summary>
        /// Win32 error code.
        /// </summary>
        [JsonPropertyName("win32Status")]
        public int Win32Status { get; set; }

        /// <summary>
        /// Request Count.
        /// </summary>
        [JsonPropertyName("count")]
        public int Count { get; set; }

        /// <summary>
        /// Time interval.
        /// </summary>
        [JsonPropertyName("timeInterval")]
        public string TimeInterval { get; set; }

        /// <summary>
        /// Request Path
        /// </summary>
        [JsonPropertyName("path")]
        public string Path { get; set; }
    }
}