// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Web
{
    /// <summary>
    /// RequestsBasedTrigger
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class RequestsBasedTrigger
    {
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
    }
}