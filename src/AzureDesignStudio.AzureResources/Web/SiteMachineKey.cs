// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Web
{
    /// <summary>
    /// SiteMachineKey
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class SiteMachineKey
    {
        /// <summary>
        /// MachineKey validation.
        /// </summary>
        [JsonPropertyName("validation")]
        public string Validation { get; set; }

        /// <summary>
        /// Validation key.
        /// </summary>
        [JsonPropertyName("validationKey")]
        public string ValidationKey { get; set; }

        /// <summary>
        /// Algorithm used for decryption.
        /// </summary>
        [JsonPropertyName("decryption")]
        public string Decryption { get; set; }

        /// <summary>
        /// Decryption key.
        /// </summary>
        [JsonPropertyName("decryptionKey")]
        public string DecryptionKey { get; set; }
    }
}