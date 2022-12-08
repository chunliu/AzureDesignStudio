// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Storage
{
    /// <summary>
    /// IPRule
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class IPRule
    {
        /// <summary>
        /// Specifies the IP or IP range in CIDR format. Only IPV4 address is allowed.
        /// </summary>
        [Required]
        [JsonPropertyName("value")]
        public string Value { get; set; }

        /// <summary>
        /// The action of IP ACL rule.
        /// </summary>
        [JsonPropertyName("action")]
        public string Action { get; set; }
    }
}