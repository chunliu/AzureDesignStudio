// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// LastPatchInstallationSummary
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class LastPatchInstallationSummary
    {
        /// <summary>
        /// The overall success or failure status of the operation. It remains "InProgress" until the operation completes. At that point it will become "Unknown", "Failed", "Succeeded", or "CompletedWithWarnings."
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// The activity ID of the operation that produced this result. It is used to correlate across CRP and extension logs.
        /// </summary>
        [JsonPropertyName("installationActivityId")]
        public string InstallationActivityId { get; set; }

        /// <summary>
        /// Describes whether the operation ran out of time before it completed all its intended actions
        /// </summary>
        [JsonPropertyName("maintenanceWindowExceeded")]
        public bool MaintenanceWindowExceeded { get; set; }

        /// <summary>
        /// The number of all available patches but not going to be installed because it didn't match a classification or inclusion list entry.
        /// </summary>
        [JsonPropertyName("notSelectedPatchCount")]
        public int NotSelectedPatchCount { get; set; }

        /// <summary>
        /// The number of all available patches but excluded explicitly by a customer-specified exclusion list match.
        /// </summary>
        [JsonPropertyName("excludedPatchCount")]
        public int ExcludedPatchCount { get; set; }

        /// <summary>
        /// The number of all available patches expected to be installed over the course of the patch installation operation.
        /// </summary>
        [JsonPropertyName("pendingPatchCount")]
        public int PendingPatchCount { get; set; }

        /// <summary>
        /// The count of patches that successfully installed.
        /// </summary>
        [JsonPropertyName("installedPatchCount")]
        public int InstalledPatchCount { get; set; }

        /// <summary>
        /// The count of patches that failed installation.
        /// </summary>
        [JsonPropertyName("failedPatchCount")]
        public int FailedPatchCount { get; set; }

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