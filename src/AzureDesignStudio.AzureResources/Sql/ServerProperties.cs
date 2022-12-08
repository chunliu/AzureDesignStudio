// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Sql
{
    /// <summary>
    /// ServerProperties
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ServerProperties
    {
        /// <summary>
        /// Administrator username for the server. Once created it cannot be changed.
        /// </summary>
        [JsonPropertyName("administratorLogin")]
        public string AdministratorLogin { get; set; }

        /// <summary>
        /// The administrator login password (required for server creation).
        /// </summary>
        [JsonPropertyName("administratorLoginPassword")]
        public string AdministratorLoginPassword { get; set; }

        /// <summary>
        /// The version of the server.
        /// </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; }

        /// <summary>
        /// The state of the server.
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }

        /// <summary>
        /// The fully qualified domain name of the server.
        /// </summary>
        [JsonPropertyName("fullyQualifiedDomainName")]
        public string FullyQualifiedDomainName { get; set; }

        /// <summary>
        /// List of private endpoint connections on a server
        /// </summary>
        [JsonPropertyName("privateEndpointConnections")]
        public IList<ServerPrivateEndpointConnection> PrivateEndpointConnections { get; set; }

        /// <summary>
        /// Minimal TLS version. Allowed values: '1.0', '1.1', '1.2'
        /// </summary>
        [JsonPropertyName("minimalTlsVersion")]
        public string MinimalTlsVersion { get; set; }

        /// <summary>
        /// Whether or not public endpoint access is allowed for this server.  Value is optional but if passed in, must be 'Enabled' or 'Disabled'
        /// </summary>
        [JsonPropertyName("publicNetworkAccess")]
        public string PublicNetworkAccess { get; set; }

        /// <summary>
        /// Whether or not existing server has a workspace created and if it allows connection from workspace
        /// </summary>
        [JsonPropertyName("workspaceFeature")]
        public string WorkspaceFeature { get; set; }

        /// <summary>
        /// The resource id of a user assigned identity to be used by default.
        /// </summary>
        [JsonPropertyName("primaryUserAssignedIdentityId")]
        public string PrimaryUserAssignedIdentityId { get; set; }

        /// <summary>
        /// The Client id used for cross tenant CMK scenario
        /// </summary>
        [JsonPropertyName("federatedClientId")]
        public string FederatedClientId { get; set; }

        /// <summary>
        /// A CMK URI of the key to use for encryption.
        /// </summary>
        [JsonPropertyName("keyId")]
        public string KeyId { get; set; }

        /// <summary>
        /// The Azure Active Directory administrator of the server. This can only be used at server create time. If used for server update, it will be ignored or it will result in an error. For updates individual APIs will need to be used.
        /// </summary>
        [JsonPropertyName("administrators")]
        public ServerExternalAdministrator Administrators { get; set; }

        /// <summary>
        /// Whether or not to restrict outbound network access for this server.  Value is optional but if passed in, must be 'Enabled' or 'Disabled'
        /// </summary>
        [JsonPropertyName("restrictOutboundNetworkAccess")]
        public string RestrictOutboundNetworkAccess { get; set; }
    }
}