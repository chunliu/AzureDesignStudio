// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// IpTag
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class IpTag
    {
        /// <summary>
        /// The IP tag type. Example: FirstPartyUsage.
        /// </summary>
        [JsonPropertyName("ipTagType")]
        public string IpTagType { get; set; }

        /// <summary>
        /// The value of the IP tag associated with the public IP. Example: SQL.
        /// </summary>
        [JsonPropertyName("tag")]
        public string Tag { get; set; }
    }
}