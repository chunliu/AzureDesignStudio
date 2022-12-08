// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Web
{
    /// <summary>
    /// SiteLimits
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class SiteLimits
    {
        /// <summary>
        /// Maximum allowed CPU usage percentage.
        /// </summary>
        [JsonPropertyName("maxPercentageCpu")]
        public int MaxPercentageCpu { get; set; }

        /// <summary>
        /// Maximum allowed memory usage in MB.
        /// </summary>
        [JsonPropertyName("maxMemoryInMb")]
        public int MaxMemoryInMb { get; set; }

        /// <summary>
        /// Maximum allowed disk size usage in MB.
        /// </summary>
        [JsonPropertyName("maxDiskSizeInMb")]
        public int MaxDiskSizeInMb { get; set; }
    }
}