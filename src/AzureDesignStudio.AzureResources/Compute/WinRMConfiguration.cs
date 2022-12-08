// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// WinRMConfiguration
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class WinRMConfiguration
    {
        /// <summary>
        /// The list of Windows Remote Management listeners
        /// </summary>
        [JsonPropertyName("listeners")]
        public IList<WinRMListener> Listeners { get; set; }
    }
}