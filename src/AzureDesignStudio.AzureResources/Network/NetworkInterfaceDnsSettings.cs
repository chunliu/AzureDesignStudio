// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// NetworkInterfaceDnsSettings
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class NetworkInterfaceDnsSettings
    {
        /// <summary>
        /// List of DNS servers IP addresses. Use 'AzureProvidedDNS' to switch to azure provided DNS resolution. 'AzureProvidedDNS' value cannot be combined with other IPs, it must be the only value in dnsServers collection.
        /// </summary>
        [JsonPropertyName("dnsServers")]
        public IList<string> DnsServers { get; set; }

        /// <summary>
        /// If the VM that uses this NIC is part of an Availability Set, then this list will have the union of all DNS servers from all NICs that are part of the Availability Set. This property is what is configured on each of those VMs.
        /// </summary>
        [JsonPropertyName("appliedDnsServers")]
        public IList<string> AppliedDnsServers { get; set; }

        /// <summary>
        /// Relative DNS name for this NIC used for internal communications between VMs in the same virtual network.
        /// </summary>
        [JsonPropertyName("internalDnsNameLabel")]
        public string InternalDnsNameLabel { get; set; }

        /// <summary>
        /// Fully qualified DNS name supporting internal communications between VMs in the same virtual network.
        /// </summary>
        [JsonPropertyName("internalFqdn")]
        public string InternalFqdn { get; set; }

        /// <summary>
        /// Even if internalDnsNameLabel is not specified, a DNS entry is created for the primary NIC of the VM. This DNS name can be constructed by concatenating the VM name with the value of internalDomainNameSuffix.
        /// </summary>
        [JsonPropertyName("internalDomainNameSuffix")]
        public string InternalDomainNameSuffix { get; set; }
    }
}