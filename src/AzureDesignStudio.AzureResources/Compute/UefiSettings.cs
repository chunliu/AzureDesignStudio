// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// UefiSettings
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class UefiSettings
    {
        /// <summary>
        /// Specifies whether secure boot should be enabled on the virtual machine. <br><br>Minimum api-version: 2020-12-01
        /// </summary>
        [JsonPropertyName("secureBootEnabled")]
        public bool SecureBootEnabled { get; set; }

        /// <summary>
        /// Specifies whether vTPM should be enabled on the virtual machine. <br><br>Minimum api-version: 2020-12-01
        /// </summary>
        [JsonPropertyName("vTpmEnabled")]
        public bool VTpmEnabled { get; set; }
    }
}