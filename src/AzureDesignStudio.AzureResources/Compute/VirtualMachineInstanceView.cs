// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// VirtualMachineInstanceView
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class VirtualMachineInstanceView
    {
        /// <summary>
        /// Specifies the update domain of the virtual machine.
        /// </summary>
        [JsonPropertyName("platformUpdateDomain")]
        public int PlatformUpdateDomain { get; set; }

        /// <summary>
        /// Specifies the fault domain of the virtual machine.
        /// </summary>
        [JsonPropertyName("platformFaultDomain")]
        public int PlatformFaultDomain { get; set; }

        /// <summary>
        /// The computer name assigned to the virtual machine.
        /// </summary>
        [JsonPropertyName("computerName")]
        public string ComputerName { get; set; }

        /// <summary>
        /// The Operating System running on the virtual machine.
        /// </summary>
        [JsonPropertyName("osName")]
        public string OsName { get; set; }

        /// <summary>
        /// The version of Operating System running on the virtual machine.
        /// </summary>
        [JsonPropertyName("osVersion")]
        public string OsVersion { get; set; }

        /// <summary>
        /// Specifies the HyperVGeneration Type associated with a resource
        /// </summary>
        [JsonPropertyName("hyperVGeneration")]
        public string HyperVGeneration { get; set; }

        /// <summary>
        /// The Remote desktop certificate thumbprint.
        /// </summary>
        [JsonPropertyName("rdpThumbPrint")]
        public string RdpThumbPrint { get; set; }

        /// <summary>
        /// The VM Agent running on the virtual machine.
        /// </summary>
        [JsonPropertyName("vmAgent")]
        public VirtualMachineAgentInstanceView VmAgent { get; set; }

        /// <summary>
        /// The Maintenance Operation status on the virtual machine.
        /// </summary>
        [JsonPropertyName("maintenanceRedeployStatus")]
        public MaintenanceRedeployStatus MaintenanceRedeployStatus { get; set; }

        /// <summary>
        /// The virtual machine disk information.
        /// </summary>
        [JsonPropertyName("disks")]
        public IList<DiskInstanceView> Disks { get; set; }

        /// <summary>
        /// The extensions information.
        /// </summary>
        [JsonPropertyName("extensions")]
        public IList<VirtualMachineExtensionInstanceView> Extensions { get; set; }

        /// <summary>
        /// The health status for the VM.
        /// </summary>
        [JsonPropertyName("vmHealth")]
        public VirtualMachineHealthStatus VmHealth { get; set; }

        /// <summary>
        /// Boot Diagnostics is a debugging feature which allows you to view Console Output and Screenshot to diagnose VM status. <br><br> You can easily view the output of your console log. <br><br> Azure also enables you to see a screenshot of the VM from the hypervisor.
        /// </summary>
        [JsonPropertyName("bootDiagnostics")]
        public BootDiagnosticsInstanceView BootDiagnostics { get; set; }

        /// <summary>
        /// Resource id of the dedicated host, on which the virtual machine is allocated through automatic placement, when the virtual machine is associated with a dedicated host group that has automatic placement enabled. <br><br>Minimum api-version: 2020-06-01.
        /// </summary>
        [JsonPropertyName("assignedHost")]
        public string AssignedHost { get; set; }

        /// <summary>
        /// The resource status information.
        /// </summary>
        [JsonPropertyName("statuses")]
        public IList<InstanceViewStatus> Statuses { get; set; }

        /// <summary>
        /// [Preview Feature] The status of virtual machine patch operations.
        /// </summary>
        [JsonPropertyName("patchStatus")]
        public VirtualMachinePatchStatus PatchStatus { get; set; }
    }
}