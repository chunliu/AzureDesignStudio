// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// MaintenanceRedeployStatus
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class MaintenanceRedeployStatus
    {
        /// <summary>
        /// True, if customer is allowed to perform Maintenance.
        /// </summary>
        [JsonPropertyName("isCustomerInitiatedMaintenanceAllowed")]
        public bool IsCustomerInitiatedMaintenanceAllowed { get; set; }

        /// <summary>
        /// Start Time for the Pre Maintenance Window.
        /// </summary>
        [JsonPropertyName("preMaintenanceWindowStartTime")]
        public string PreMaintenanceWindowStartTime { get; set; }

        /// <summary>
        /// End Time for the Pre Maintenance Window.
        /// </summary>
        [JsonPropertyName("preMaintenanceWindowEndTime")]
        public string PreMaintenanceWindowEndTime { get; set; }

        /// <summary>
        /// Start Time for the Maintenance Window.
        /// </summary>
        [JsonPropertyName("maintenanceWindowStartTime")]
        public string MaintenanceWindowStartTime { get; set; }

        /// <summary>
        /// End Time for the Maintenance Window.
        /// </summary>
        [JsonPropertyName("maintenanceWindowEndTime")]
        public string MaintenanceWindowEndTime { get; set; }

        /// <summary>
        /// The Last Maintenance Operation Result Code.
        /// </summary>
        [JsonPropertyName("lastOperationResultCode")]
        public string LastOperationResultCode { get; set; }

        /// <summary>
        /// Message returned for the last Maintenance Operation.
        /// </summary>
        [JsonPropertyName("lastOperationMessage")]
        public string LastOperationMessage { get; set; }
    }
}