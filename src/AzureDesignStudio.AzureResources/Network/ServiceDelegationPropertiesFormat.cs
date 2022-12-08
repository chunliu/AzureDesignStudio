// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ServiceDelegationPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ServiceDelegationPropertiesFormat
    {
        /// <summary>
        /// The name of the service to whom the subnet should be delegated (e.g. Microsoft.Sql/servers).
        /// </summary>
        [JsonPropertyName("serviceName")]
        public string ServiceName { get; set; }

        /// <summary>
        /// The actions permitted to the service upon delegation.
        /// </summary>
        [JsonPropertyName("actions")]
        public IList<string> Actions { get; set; }

        /// <summary>
        /// The provisioning state of the service delegation resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}