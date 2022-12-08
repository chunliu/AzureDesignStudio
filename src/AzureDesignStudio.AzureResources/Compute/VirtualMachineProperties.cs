// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// VirtualMachineProperties
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class VirtualMachineProperties
    {
        /// <summary>
        /// Specifies the hardware settings for the virtual machine.
        /// </summary>
        [JsonPropertyName("hardwareProfile")]
        public HardwareProfile HardwareProfile { get; set; }

        /// <summary>
        /// Specifies the storage settings for the virtual machine disks.
        /// </summary>
        [JsonPropertyName("storageProfile")]
        public StorageProfile StorageProfile { get; set; }

        /// <summary>
        /// Specifies additional capabilities enabled or disabled on the virtual machine.
        /// </summary>
        [JsonPropertyName("additionalCapabilities")]
        public AdditionalCapabilities AdditionalCapabilities { get; set; }

        /// <summary>
        /// Specifies the operating system settings used while creating the virtual machine. Some of the settings cannot be changed once VM is provisioned.
        /// </summary>
        [JsonPropertyName("osProfile")]
        public OSProfile OsProfile { get; set; }

        /// <summary>
        /// Specifies the network interfaces of the virtual machine.
        /// </summary>
        [JsonPropertyName("networkProfile")]
        public NetworkProfile NetworkProfile { get; set; }

        /// <summary>
        /// Specifies the Security related profile settings for the virtual machine.
        /// </summary>
        [JsonPropertyName("securityProfile")]
        public SecurityProfile SecurityProfile { get; set; }

        /// <summary>
        /// Specifies the boot diagnostic settings state. <br><br>Minimum api-version: 2015-06-15.
        /// </summary>
        [JsonPropertyName("diagnosticsProfile")]
        public DiagnosticsProfile DiagnosticsProfile { get; set; }

        /// <summary>
        /// Specifies information about the availability set that the virtual machine should be assigned to. Virtual machines specified in the same availability set are allocated to different nodes to maximize availability. For more information about availability sets, see [Availability sets overview](https://docs.microsoft.com/azure/virtual-machines/availability-set-overview). <br><br> For more information on Azure planned maintenance, see [Maintenance and updates for Virtual Machines in Azure](https://docs.microsoft.com/azure/virtual-machines/maintenance-and-updates) <br><br> Currently, a VM can only be added to availability set at creation time. The availability set to which the VM is being added should be under the same resource group as the availability set resource. An existing VM cannot be added to an availability set. <br><br>This property cannot exist along with a non-null properties.virtualMachineScaleSet reference.
        /// </summary>
        [JsonPropertyName("availabilitySet")]
        public SubResource AvailabilitySet { get; set; }

        /// <summary>
        /// Specifies information about the virtual machine scale set that the virtual machine should be assigned to. Virtual machines specified in the same virtual machine scale set are allocated to different nodes to maximize availability. Currently, a VM can only be added to virtual machine scale set at creation time. An existing VM cannot be added to a virtual machine scale set. <br><br>This property cannot exist along with a non-null properties.availabilitySet reference. <br><br>Minimum api‐version: 2019‐03‐01
        /// </summary>
        [JsonPropertyName("virtualMachineScaleSet")]
        public SubResource VirtualMachineScaleSet { get; set; }

        /// <summary>
        /// Specifies information about the proximity placement group that the virtual machine should be assigned to. <br><br>Minimum api-version: 2018-04-01.
        /// </summary>
        [JsonPropertyName("proximityPlacementGroup")]
        public SubResource ProximityPlacementGroup { get; set; }

        /// <summary>
        /// Specifies the priority for the virtual machine. <br><br>Minimum api-version: 2019-03-01
        /// </summary>
        [JsonPropertyName("priority")]
        public string Priority { get; set; }

        /// <summary>
        /// Specifies the eviction policy for the Azure Spot virtual machine and Azure Spot scale set. <br><br>For Azure Spot virtual machines, both 'Deallocate' and 'Delete' are supported and the minimum api-version is 2019-03-01. <br><br>For Azure Spot scale sets, both 'Deallocate' and 'Delete' are supported and the minimum api-version is 2017-10-30-preview.
        /// </summary>
        [JsonPropertyName("evictionPolicy")]
        public string EvictionPolicy { get; set; }

        /// <summary>
        /// Specifies the billing related details of a Azure Spot virtual machine. <br><br>Minimum api-version: 2019-03-01.
        /// </summary>
        [JsonPropertyName("billingProfile")]
        public BillingProfile BillingProfile { get; set; }

        /// <summary>
        /// Specifies information about the dedicated host that the virtual machine resides in. <br><br>Minimum api-version: 2018-10-01.
        /// </summary>
        [JsonPropertyName("host")]
        public SubResource Host { get; set; }

        /// <summary>
        /// Specifies information about the dedicated host group that the virtual machine resides in. <br><br>Minimum api-version: 2020-06-01. <br><br>NOTE: User cannot specify both host and hostGroup properties.
        /// </summary>
        [JsonPropertyName("hostGroup")]
        public SubResource HostGroup { get; set; }

        /// <summary>
        /// The provisioning state, which only appears in the response.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// The virtual machine instance view.
        /// </summary>
        [JsonPropertyName("instanceView")]
        public VirtualMachineInstanceView InstanceView { get; set; }

        /// <summary>
        /// Specifies that the image or disk that is being used was licensed on-premises. <br><br> Possible values for Windows Server operating system are: <br><br> Windows_Client <br><br> Windows_Server <br><br> Possible values for Linux Server operating system are: <br><br> RHEL_BYOS (for RHEL) <br><br> SLES_BYOS (for SUSE) <br><br> For more information, see [Azure Hybrid Use Benefit for Windows Server](https://docs.microsoft.com/azure/virtual-machines/windows/hybrid-use-benefit-licensing) <br><br> [Azure Hybrid Use Benefit for Linux Server](https://docs.microsoft.com/azure/virtual-machines/linux/azure-hybrid-benefit-linux) <br><br> Minimum api-version: 2015-06-15
        /// </summary>
        [JsonPropertyName("licenseType")]
        public string LicenseType { get; set; }

        /// <summary>
        /// Specifies the VM unique ID which is a 128-bits identifier that is encoded and stored in all Azure IaaS VMs SMBIOS and can be read using platform BIOS commands.
        /// </summary>
        [JsonPropertyName("vmId")]
        public string VmId { get; set; }

        /// <summary>
        /// Specifies the time alloted for all extensions to start. The time duration should be between 15 minutes and 120 minutes (inclusive) and should be specified in ISO 8601 format. The default value is 90 minutes (PT1H30M). <br><br> Minimum api-version: 2020-06-01
        /// </summary>
        [JsonPropertyName("extensionsTimeBudget")]
        public string ExtensionsTimeBudget { get; set; }

        /// <summary>
        /// Specifies the scale set logical fault domain into which the Virtual Machine will be created. By default, the Virtual Machine will by automatically assigned to a fault domain that best maintains balance across available fault domains.<br><li>This is applicable only if the 'virtualMachineScaleSet' property of this Virtual Machine is set.<li>The Virtual Machine Scale Set that is referenced, must have 'platformFaultDomainCount' &gt; 1.<li>This property cannot be updated once the Virtual Machine is created.<li>Fault domain assignment can be viewed in the Virtual Machine Instance View.<br><br>Minimum api‐version: 2020‐12‐01
        /// </summary>
        [JsonPropertyName("platformFaultDomain")]
        public int PlatformFaultDomain { get; set; }

        /// <summary>
        /// Specifies Scheduled Event related configurations.
        /// </summary>
        [JsonPropertyName("scheduledEventsProfile")]
        public ScheduledEventsProfile ScheduledEventsProfile { get; set; }

        /// <summary>
        /// UserData for the VM, which must be base-64 encoded. Customer should not pass any secrets in here. <br><br>Minimum api-version: 2021-03-01
        /// </summary>
        [JsonPropertyName("userData")]
        public string UserData { get; set; }

        /// <summary>
        /// Specifies information about the capacity reservation that is used to allocate virtual machine. <br><br>Minimum api-version: 2021-04-01.
        /// </summary>
        [JsonPropertyName("capacityReservation")]
        public CapacityReservationProfile CapacityReservation { get; set; }

        /// <summary>
        /// Specifies the gallery applications that should be made available to the VM/VMSS
        /// </summary>
        [JsonPropertyName("applicationProfile")]
        public ApplicationProfile ApplicationProfile { get; set; }

        /// <summary>
        /// Specifies the time at which the Virtual Machine resource was created.<br><br>Minimum api-version: 2021-11-01.
        /// </summary>
        [JsonPropertyName("timeCreated")]
        public string TimeCreated { get; set; }
    }
}