// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// ScheduledEventsProfile
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ScheduledEventsProfile
    {
        /// <summary>
        /// Specifies Terminate Scheduled Event related configurations.
        /// </summary>
        [JsonPropertyName("terminateNotificationProfile")]
        public TerminateNotificationProfile TerminateNotificationProfile { get; set; }
    }
}