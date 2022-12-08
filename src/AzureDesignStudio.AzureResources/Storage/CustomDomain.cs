// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Storage
{
    /// <summary>
    /// CustomDomain
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class CustomDomain
    {
        /// <summary>
        /// Gets or sets the custom domain name assigned to the storage account. Name is the CNAME source.
        /// </summary>
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Indicates whether indirect CName validation is enabled. Default value is false. This should only be set on updates.
        /// </summary>
        [JsonPropertyName("useSubDomainName")]
        public bool UseSubDomainName { get; set; }
    }
}