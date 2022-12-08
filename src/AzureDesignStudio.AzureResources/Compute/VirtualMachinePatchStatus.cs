// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// VirtualMachinePatchStatus
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class VirtualMachinePatchStatus
    {
        /// <summary>
        /// The available patch summary of the latest assessment operation for the virtual machine.
        /// </summary>
        [JsonPropertyName("availablePatchSummary")]
        public AvailablePatchSummary AvailablePatchSummary { get; set; }

        /// <summary>
        /// The installation summary of the latest installation operation for the virtual machine.
        /// </summary>
        [JsonPropertyName("lastPatchInstallationSummary")]
        public LastPatchInstallationSummary LastPatchInstallationSummary { get; set; }

        /// <summary>
        /// The enablement status of the specified patchMode
        /// </summary>
        [JsonPropertyName("configurationStatuses")]
        public IList<InstanceViewStatus> ConfigurationStatuses { get; set; }
    }
}