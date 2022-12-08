// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// AvailablePatchSummary
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class AvailablePatchSummary
    {
        /// <summary>
        /// The overall success or failure status of the operation. It remains "InProgress" until the operation completes. At that point it will become "Unknown", "Failed", "Succeeded", or "CompletedWithWarnings."
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// The activity ID of the operation that produced this result. It is used to correlate across CRP and extension logs.
        /// </summary>
        [JsonPropertyName("assessmentActivityId")]
        public string AssessmentActivityId { get; set; }

        /// <summary>
        /// The overall reboot status of the VM. It will be true when partially installed patches require a reboot to complete installation but the reboot has not yet occurred.
        /// </summary>
        [JsonPropertyName("rebootPending")]
        public bool RebootPending { get; set; }

        /// <summary>
        /// The number of critical or security patches that have been detected as available and not yet installed.
        /// </summary>
        [JsonPropertyName("criticalAndSecurityPatchCount")]
        public int CriticalAndSecurityPatchCount { get; set; }

        /// <summary>
        /// The number of all available patches excluding critical and security.
        /// </summary>
        [JsonPropertyName("otherPatchCount")]
        public int OtherPatchCount { get; set; }

        /// <summary>
        /// The UTC timestamp when the operation began.
        /// </summary>
        [JsonPropertyName("startTime")]
        public string StartTime { get; set; }

        /// <summary>
        /// The UTC timestamp when the operation began.
        /// </summary>
        [JsonPropertyName("lastModifiedTime")]
        public string LastModifiedTime { get; set; }

        /// <summary>
        /// The errors that were encountered during execution of the operation. The details array contains the list of them.
        /// </summary>
        [JsonPropertyName("error")]
        public ApiError Error { get; set; }
    }
}