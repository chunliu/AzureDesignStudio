// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Web
{
    /// <summary>
    /// AutoHealActions
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class AutoHealActions
    {
        /// <summary>
        /// Predefined action to be taken.
        /// </summary>
        [JsonPropertyName("actionType")]
        public string ActionType { get; set; }

        /// <summary>
        /// Custom action to be taken.
        /// </summary>
        [JsonPropertyName("customAction")]
        public AutoHealCustomAction CustomAction { get; set; }

        /// <summary>
        /// Minimum time the process must execute
        [JsonPropertyName("minProcessExecutionTime")]
        public string MinProcessExecutionTime { get; set; }
    }
}