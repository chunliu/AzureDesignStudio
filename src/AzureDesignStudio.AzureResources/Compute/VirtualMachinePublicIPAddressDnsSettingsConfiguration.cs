// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// VirtualMachinePublicIPAddressDnsSettingsConfiguration
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class VirtualMachinePublicIPAddressDnsSettingsConfiguration
    {
        /// <summary>
        /// The Domain name label prefix of the PublicIPAddress resources that will be created. The generated name label is the concatenation of the domain name label and vm network profile unique ID.
        /// </summary>
        [Required]
        [JsonPropertyName("domainNameLabel")]
        public string DomainNameLabel { get; set; }
    }
}