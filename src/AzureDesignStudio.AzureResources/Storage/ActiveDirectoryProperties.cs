// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Storage
{
    /// <summary>
    /// ActiveDirectoryProperties
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ActiveDirectoryProperties
    {
        /// <summary>
        /// Specifies the primary domain that the AD DNS server is authoritative for.
        /// </summary>
        [Required]
        [JsonPropertyName("domainName")]
        public string DomainName { get; set; }

        /// <summary>
        /// Specifies the NetBIOS domain name.
        /// </summary>
        [JsonPropertyName("netBiosDomainName")]
        public string NetBiosDomainName { get; set; }

        /// <summary>
        /// Specifies the Active Directory forest to get.
        /// </summary>
        [JsonPropertyName("forestName")]
        public string ForestName { get; set; }

        /// <summary>
        /// Specifies the domain GUID.
        /// </summary>
        [Required]
        [JsonPropertyName("domainGuid")]
        public string DomainGuid { get; set; }

        /// <summary>
        /// Specifies the security identifier (SID).
        /// </summary>
        [JsonPropertyName("domainSid")]
        public string DomainSid { get; set; }

        /// <summary>
        /// Specifies the security identifier (SID) for Azure Storage.
        /// </summary>
        [JsonPropertyName("azureStorageSid")]
        public string AzureStorageSid { get; set; }

        /// <summary>
        /// Specifies the Active Directory SAMAccountName for Azure Storage.
        /// </summary>
        [JsonPropertyName("samAccountName")]
        public string SamAccountName { get; set; }

        /// <summary>
        /// Specifies the Active Directory account type for Azure Storage.
        /// </summary>
        [JsonPropertyName("accountType")]
        public string AccountType { get; set; }
    }
}