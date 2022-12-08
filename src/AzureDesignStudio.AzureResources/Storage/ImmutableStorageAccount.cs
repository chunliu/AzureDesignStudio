// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Storage
{
    /// <summary>
    /// ImmutableStorageAccount
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ImmutableStorageAccount
    {
        /// <summary>
        /// A boolean flag which enables account-level immutability. All the containers under such an account have object-level immutability enabled by default.
        /// </summary>
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Specifies the default account-level immutability policy which is inherited and applied to objects that do not possess an explicit immutability policy at the object level. The object-level immutability policy has higher precedence than the container-level immutability policy, which has a higher precedence than the account-level immutability policy.
        /// </summary>
        [JsonPropertyName("immutabilityPolicy")]
        public AccountImmutabilityPolicyProperties ImmutabilityPolicy { get; set; }
    }
}