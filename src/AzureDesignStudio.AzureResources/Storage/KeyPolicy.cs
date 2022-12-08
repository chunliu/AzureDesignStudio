// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Storage
{
    /// <summary>
    /// KeyPolicy
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class KeyPolicy
    {
        /// <summary>
        /// The key expiration period in days.
        /// </summary>
        [Required]
        [JsonPropertyName("keyExpirationPeriodInDays")]
        public int KeyExpirationPeriodInDays { get; set; }
    }
}