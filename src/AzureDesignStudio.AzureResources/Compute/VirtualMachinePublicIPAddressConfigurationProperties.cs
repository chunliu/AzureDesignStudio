// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// VirtualMachinePublicIPAddressConfigurationProperties
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class VirtualMachinePublicIPAddressConfigurationProperties
    {
        /// <summary>
        /// The idle timeout of the public IP address.
        /// </summary>
        [JsonPropertyName("idleTimeoutInMinutes")]
        public int IdleTimeoutInMinutes { get; set; }

        /// <summary>
        /// Specify what happens to the public IP address when the VM is deleted
        /// </summary>
        [JsonPropertyName("deleteOption")]
        public string DeleteOption { get; set; }

        /// <summary>
        /// The dns settings to be applied on the publicIP addresses .
        /// </summary>
        [JsonPropertyName("dnsSettings")]
        public VirtualMachinePublicIPAddressDnsSettingsConfiguration DnsSettings { get; set; }

        /// <summary>
        /// The list of IP tags associated with the public IP address.
        /// </summary>
        [JsonPropertyName("ipTags")]
        public IList<VirtualMachineIpTag> IpTags { get; set; }

        /// <summary>
        /// The PublicIPPrefix from which to allocate publicIP addresses.
        /// </summary>
        [JsonPropertyName("publicIPPrefix")]
        public SubResource PublicIPPrefix { get; set; }

        /// <summary>
        /// Available from Api-Version 2019-07-01 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4. Possible values are: 'IPv4' and 'IPv6'.
        /// </summary>
        [JsonPropertyName("publicIPAddressVersion")]
        public string PublicIPAddressVersion { get; set; }

        /// <summary>
        /// Specify the public IP allocation type
        /// </summary>
        [JsonPropertyName("publicIPAllocationMethod")]
        public string PublicIPAllocationMethod { get; set; }
    }
}