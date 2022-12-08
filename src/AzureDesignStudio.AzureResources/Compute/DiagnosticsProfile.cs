// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// DiagnosticsProfile
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class DiagnosticsProfile
    {
        /// <summary>
        /// Boot Diagnostics is a debugging feature which allows you to view Console Output and Screenshot to diagnose VM status. <br>**NOTE**: If storageUri is being specified then ensure that the storage account is in the same region and subscription as the VM. <br><br> You can easily view the output of your console log. <br><br> Azure also enables you to see a screenshot of the VM from the hypervisor.
        /// </summary>
        [JsonPropertyName("bootDiagnostics")]
        public BootDiagnostics BootDiagnostics { get; set; }
    }
}