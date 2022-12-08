// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;
using AzureDesignStudio.AzureResources.Base;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// Microsoft.Network/firewallPolicies
    /// </summary>
    [AzureResource("Microsoft.Network/firewallPolicies", "2022-07-01")]
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class FirewallPolicies : ResourceBase
    {
        /// <summary>
        /// The resource id
        /// </summary>
        [JsonIgnore]
        public string Id { get; private set; }

        /// <summary>
        /// The resource type
        /// </summary>
        [JsonPropertyName("type")]
        public override string Type => "Microsoft.Network/firewallPolicies";

        /// <summary>
        /// The resource api version
        /// </summary>
        [JsonPropertyName("apiVersion")]
        public override string ApiVersion => "2022-07-01";

        /// <summary>
        /// Properties of the firewall policy.
        /// </summary>
        [JsonPropertyName("properties")]
        public FirewallPolicyPropertiesFormat Properties { get; set; }

        /// <summary>
        /// A unique read-only string that changes whenever the resource is updated.
        /// </summary>
        [JsonIgnore]
        public string Etag { get; private set; }

        /// <summary>
        /// The identity of the firewall policy.
        /// </summary>
        [JsonPropertyName("identity")]
        public ManagedServiceIdentity Identity { get; set; }
    }
}