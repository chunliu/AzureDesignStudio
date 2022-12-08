// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// PublicIPAddressDnsSettings
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class PublicIPAddressDnsSettings
    {
        /// <summary>
        /// The domain name label. The concatenation of the domain name label and the regionalized DNS zone make up the fully qualified domain name associated with the public IP address. If a domain name label is specified, an A DNS record is created for the public IP in the Microsoft Azure DNS system.
        /// </summary>
        [JsonPropertyName("domainNameLabel")]
        public string DomainNameLabel { get; set; }

        /// <summary>
        /// The Fully Qualified Domain Name of the A DNS record associated with the public IP. This is the concatenation of the domainNameLabel and the regionalized DNS zone.
        /// </summary>
        [JsonPropertyName("fqdn")]
        public string Fqdn { get; set; }

        /// <summary>
        /// The reverse FQDN. A user-visible, fully qualified domain name that resolves to this public IP address. If the reverseFqdn is specified, then a PTR DNS record is created pointing from the IP address in the in-addr.arpa domain to the reverse FQDN.
        /// </summary>
        [JsonPropertyName("reverseFqdn")]
        public string ReverseFqdn { get; set; }
    }
}