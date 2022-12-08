// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// HardwareProfile
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class HardwareProfile
    {
        /// <summary>
        /// Specifies the size of the virtual machine. <br><br> The enum data type is currently deprecated and will be removed by December 23rd 2023. <br><br> Recommended way to get the list of available sizes is using these APIs: <br><br> [List all available virtual machine sizes in an availability set](https://docs.microsoft.com/rest/api/compute/availabilitysets/listavailablesizes) <br><br> [List all available virtual machine sizes in a region]( https://docs.microsoft.com/rest/api/compute/resourceskus/list) <br><br> [List all available virtual machine sizes for resizing](https://docs.microsoft.com/rest/api/compute/virtualmachines/listavailablesizes). For more information about virtual machine sizes, see [Sizes for virtual machines](https://docs.microsoft.com/azure/virtual-machines/sizes). <br><br> The available VM sizes depend on region and availability set.
        /// </summary>
        [JsonPropertyName("vmSize")]
        public string VmSize { get; set; }

        /// <summary>
        /// Specifies the properties for customizing the size of the virtual machine. Minimum api-version: 2021-07-01. <br><br> This feature is still in preview mode and is not supported for VirtualMachineScaleSet. <br><br> Please follow the instructions in [VM Customization](https://aka.ms/vmcustomization) for more details.
        /// </summary>
        [JsonPropertyName("vmSizeProperties")]
        public VMSizeProperties VmSizeProperties { get; set; }
    }
}