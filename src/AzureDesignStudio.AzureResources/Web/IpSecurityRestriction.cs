// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Web
{
    /// <summary>
    /// IpSecurityRestriction
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class IpSecurityRestriction
    {
        /// <summary>
        /// IP address the security restriction is valid for.
        [JsonPropertyName("ipAddress")]
        public string IpAddress { get; set; }

        /// <summary>
        /// Subnet mask for the range of IP addresses the restriction is valid for.
        /// </summary>
        [JsonPropertyName("subnetMask")]
        public string SubnetMask { get; set; }

        /// <summary>
        /// Virtual network resource id
        /// </summary>
        [JsonPropertyName("vnetSubnetResourceId")]
        public string VnetSubnetResourceId { get; set; }

        /// <summary>
        /// (internal) Vnet traffic tag
        /// </summary>
        [JsonPropertyName("vnetTrafficTag")]
        public int VnetTrafficTag { get; set; }

        /// <summary>
        /// (internal) Subnet traffic tag
        /// </summary>
        [JsonPropertyName("subnetTrafficTag")]
        public int SubnetTrafficTag { get; set; }

        /// <summary>
        /// Allow or Deny access for this IP range.
        /// </summary>
        [JsonPropertyName("action")]
        public string Action { get; set; }

        /// <summary>
        /// Defines what this IP filter will be used for. This is to support IP filtering on proxies.
        /// </summary>
        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        /// <summary>
        /// Priority of IP restriction rule.
        /// </summary>
        [JsonPropertyName("priority")]
        public int Priority { get; set; }

        /// <summary>
        /// IP restriction rule name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// IP restriction rule description.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// IP restriction rule headers.
        [JsonPropertyName("headers")]
        public IpSecurityRestrictionHeaders Headers { get; set; }
    }
}