// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// SshConfiguration
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class SshConfiguration
    {
        /// <summary>
        /// The list of SSH public keys used to authenticate with linux based VMs.
        /// </summary>
        [JsonPropertyName("publicKeys")]
        public IList<SshPublicKey> PublicKeys { get; set; }
    }
}