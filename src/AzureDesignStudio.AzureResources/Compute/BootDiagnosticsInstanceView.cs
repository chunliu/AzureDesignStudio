// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// BootDiagnosticsInstanceView
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class BootDiagnosticsInstanceView
    {
        /// <summary>
        /// The console screenshot blob URI. <br><br>NOTE: This will **not** be set if boot diagnostics is currently enabled with managed storage.
        /// </summary>
        [JsonPropertyName("consoleScreenshotBlobUri")]
        public string ConsoleScreenshotBlobUri { get; set; }

        /// <summary>
        /// The serial console log blob Uri. <br><br>NOTE: This will **not** be set if boot diagnostics is currently enabled with managed storage.
        /// </summary>
        [JsonPropertyName("serialConsoleLogBlobUri")]
        public string SerialConsoleLogBlobUri { get; set; }

        /// <summary>
        /// The boot diagnostics status information for the VM. <br><br> NOTE: It will be set only if there are errors encountered in enabling boot diagnostics.
        /// </summary>
        [JsonPropertyName("status")]
        public InstanceViewStatus Status { get; set; }
    }
}