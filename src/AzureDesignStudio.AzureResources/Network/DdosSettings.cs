// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// DdosSettings
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class DdosSettings
    {
        /// <summary>
        /// The DDoS protection mode of the public IP
        /// </summary>
        [JsonPropertyName("protectionMode")]
        public string ProtectionMode { get; set; }

        /// <summary>
        /// The DDoS protection plan associated with the public IP. Can only be set if ProtectionMode is Enabled
        /// </summary>
        [JsonPropertyName("ddosProtectionPlan")]
        public SubResource DdosProtectionPlan { get; set; }
    }
}