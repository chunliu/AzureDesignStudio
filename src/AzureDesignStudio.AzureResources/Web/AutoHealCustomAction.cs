// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Web
{
    /// <summary>
    /// AutoHealCustomAction
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class AutoHealCustomAction
    {
        /// <summary>
        /// Executable to be run.
        /// </summary>
        [JsonPropertyName("exe")]
        public string Exe { get; set; }

        /// <summary>
        /// Parameters for the executable.
        /// </summary>
        [JsonPropertyName("parameters")]
        public string Parameters { get; set; }
    }
}