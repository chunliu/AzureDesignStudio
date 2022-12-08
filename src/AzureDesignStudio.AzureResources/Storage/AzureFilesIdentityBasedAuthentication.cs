// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Storage
{
    /// <summary>
    /// AzureFilesIdentityBasedAuthentication
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class AzureFilesIdentityBasedAuthentication
    {
        /// <summary>
        /// Indicates the directory service used. Note that this enum may be extended in the future.
        /// </summary>
        [Required]
        [JsonPropertyName("directoryServiceOptions")]
        public string DirectoryServiceOptions { get; set; }

        /// <summary>
        /// Required if directoryServiceOptions are AD, optional if they are AADKERB.
        /// </summary>
        [JsonPropertyName("activeDirectoryProperties")]
        public ActiveDirectoryProperties ActiveDirectoryProperties { get; set; }

        /// <summary>
        /// Default share permission for users using Kerberos authentication if RBAC role is not assigned.
        /// </summary>
        [JsonPropertyName("defaultSharePermission")]
        public string DefaultSharePermission { get; set; }
    }
}