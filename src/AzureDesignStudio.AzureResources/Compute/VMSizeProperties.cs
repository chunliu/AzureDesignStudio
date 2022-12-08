// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// VMSizeProperties
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class VMSizeProperties
    {
        /// <summary>
        /// Specifies the number of vCPUs available for the VM. <br><br> When this property is not specified in the request body the default behavior is to set it to the value of vCPUs available for that VM size exposed in api response of [List all available virtual machine sizes in a region](https://docs.microsoft.com/en-us/rest/api/compute/resource-skus/list) .
        /// </summary>
        [JsonPropertyName("vCPUsAvailable")]
        public int VCPUsAvailable { get; set; }

        /// <summary>
        /// Specifies the vCPU to physical core ratio. <br><br> When this property is not specified in the request body the default behavior is set to the value of vCPUsPerCore for the VM Size exposed in api response of [List all available virtual machine sizes in a region](https://docs.microsoft.com/en-us/rest/api/compute/resource-skus/list) <br><br> Setting this property to 1 also means that hyper-threading is disabled.
        /// </summary>
        [JsonPropertyName("vCPUsPerCore")]
        public int VCPUsPerCore { get; set; }
    }
}