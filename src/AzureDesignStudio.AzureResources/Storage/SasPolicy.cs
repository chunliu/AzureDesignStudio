// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Storage
{
    /// <summary>
    /// SasPolicy
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class SasPolicy
    {
        /// <summary>
        /// The SAS expiration period, DD.HH:MM:SS.
        /// </summary>
        [Required]
        [JsonPropertyName("sasExpirationPeriod")]
        public string SasExpirationPeriod { get; set; }

        /// <summary>
        /// The SAS expiration action. Can only be Log.
        /// </summary>
        [Required]
        [JsonPropertyName("expirationAction")]
        public string ExpirationAction { get; set; }
    }
}