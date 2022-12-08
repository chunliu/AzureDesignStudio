// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// TerminateNotificationProfile
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class TerminateNotificationProfile
    {
        /// <summary>
        /// Configurable length of time a Virtual Machine being deleted will have to potentially approve the Terminate Scheduled Event before the event is auto approved (timed out). The configuration must be specified in ISO 8601 format, the default value is 5 minutes (PT5M)
        /// </summary>
        [JsonPropertyName("notBeforeTimeout")]
        public string NotBeforeTimeout { get; set; }

        /// <summary>
        /// Specifies whether the Terminate Scheduled event is enabled or disabled.
        /// </summary>
        [JsonPropertyName("enable")]
        public bool Enable { get; set; }
    }
}