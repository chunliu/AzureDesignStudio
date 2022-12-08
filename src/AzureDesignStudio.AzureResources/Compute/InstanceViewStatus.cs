// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// InstanceViewStatus
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class InstanceViewStatus
    {
        /// <summary>
        /// The status code.
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// The level code.
        /// </summary>
        [JsonPropertyName("level")]
        public string Level { get; set; }

        /// <summary>
        /// The short localizable label for the status.
        /// </summary>
        [JsonPropertyName("displayStatus")]
        public string DisplayStatus { get; set; }

        /// <summary>
        /// The detailed status message, including for alerts and error messages.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>
        /// The time of the status.
        /// </summary>
        [JsonPropertyName("time")]
        public string Time { get; set; }
    }
}