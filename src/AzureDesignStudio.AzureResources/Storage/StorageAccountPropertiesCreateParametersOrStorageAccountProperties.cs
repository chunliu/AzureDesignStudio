// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Storage
{
    /// <summary>
    /// StorageAccountPropertiesCreateParametersOrStorageAccountProperties
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class StorageAccountPropertiesCreateParametersOrStorageAccountProperties
    {
        /// <summary>
        /// Restrict copy to and from Storage Accounts within an AAD tenant or with Private Links to the same VNet.
        /// </summary>
        [JsonPropertyName("allowedCopyScope")]
        public string AllowedCopyScope { get; set; }

        /// <summary>
        /// Allow or disallow public network access to Storage Account. Value is optional but if passed in, must be 'Enabled' or 'Disabled'.
        /// </summary>
        [JsonPropertyName("publicNetworkAccess")]
        public string PublicNetworkAccess { get; set; }

        /// <summary>
        /// SasPolicy assigned to the storage account.
        /// </summary>
        [JsonPropertyName("sasPolicy")]
        public SasPolicy SasPolicy { get; set; }

        /// <summary>
        /// KeyPolicy assigned to the storage account.
        /// </summary>
        [JsonPropertyName("keyPolicy")]
        public KeyPolicy KeyPolicy { get; set; }

        /// <summary>
        /// User domain assigned to the storage account. Name is the CNAME source. Only one custom domain is supported per storage account at this time. To clear the existing custom domain, use an empty string for the custom domain name property.
        /// </summary>
        [JsonPropertyName("customDomain")]
        public CustomDomain CustomDomain { get; set; }

        /// <summary>
        /// Encryption settings to be used for server-side encryption for the storage account.
        /// </summary>
        [JsonPropertyName("encryption")]
        public Encryption Encryption { get; set; }

        /// <summary>
        /// Network rule set
        /// </summary>
        [JsonPropertyName("networkAcls")]
        public NetworkRuleSet NetworkAcls { get; set; }

        /// <summary>
        /// Required for storage accounts where kind = BlobStorage. The access tier is used for billing. The 'Premium' access tier is the default value for premium block blobs storage account type and it cannot be changed for the premium block blobs storage account type.
        /// </summary>
        [JsonPropertyName("accessTier")]
        public string AccessTier { get; set; }

        /// <summary>
        /// Provides the identity based authentication settings for Azure Files.
        /// </summary>
        [JsonPropertyName("azureFilesIdentityBasedAuthentication")]
        public AzureFilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get; set; }

        /// <summary>
        /// Allows https traffic only to storage service if sets to true. The default value is true since API version 2019-04-01.
        /// </summary>
        [JsonPropertyName("supportsHttpsTrafficOnly")]
        public bool SupportsHttpsTrafficOnly { get; set; }

        /// <summary>
        /// Enables Secure File Transfer Protocol, if set to true
        /// </summary>
        [JsonPropertyName("isSftpEnabled")]
        public bool IsSftpEnabled { get; set; }

        /// <summary>
        /// Enables local users feature, if set to true
        /// </summary>
        [JsonPropertyName("isLocalUserEnabled")]
        public bool IsLocalUserEnabled { get; set; }

        /// <summary>
        /// Account HierarchicalNamespace enabled if sets to true.
        /// </summary>
        [JsonPropertyName("isHnsEnabled")]
        public bool IsHnsEnabled { get; set; }

        /// <summary>
        /// Allow large file shares if sets to Enabled. It cannot be disabled once it is enabled.
        /// </summary>
        [JsonPropertyName("largeFileSharesState")]
        public string LargeFileSharesState { get; set; }

        /// <summary>
        /// Maintains information about the network routing choice opted by the user for data transfer
        /// </summary>
        [JsonPropertyName("routingPreference")]
        public RoutingPreference RoutingPreference { get; set; }

        /// <summary>
        /// Allow or disallow public access to all blobs or containers in the storage account. The default interpretation is true for this property.
        /// </summary>
        [JsonPropertyName("allowBlobPublicAccess")]
        public bool AllowBlobPublicAccess { get; set; }

        /// <summary>
        /// Set the minimum TLS version to be permitted on requests to storage. The default interpretation is TLS 1.0 for this property.
        /// </summary>
        [JsonPropertyName("minimumTlsVersion")]
        public string MinimumTlsVersion { get; set; }

        /// <summary>
        /// Indicates whether the storage account permits requests to be authorized with the account access key via Shared Key. If false, then all requests, including shared access signatures, must be authorized with Azure Active Directory (Azure AD). The default value is null, which is equivalent to true.
        /// </summary>
        [JsonPropertyName("allowSharedKeyAccess")]
        public bool AllowSharedKeyAccess { get; set; }

        /// <summary>
        /// NFS 3.0 protocol support enabled if set to true.
        /// </summary>
        [JsonPropertyName("isNfsV3Enabled")]
        public bool IsNfsV3Enabled { get; set; }

        /// <summary>
        /// Allow or disallow cross AAD tenant object replication. The default interpretation is true for this property.
        /// </summary>
        [JsonPropertyName("allowCrossTenantReplication")]
        public bool AllowCrossTenantReplication { get; set; }

        /// <summary>
        /// A boolean flag which indicates whether the default authentication is OAuth or not. The default interpretation is false for this property.
        /// </summary>
        [JsonPropertyName("defaultToOAuthAuthentication")]
        public bool DefaultToOAuthAuthentication { get; set; }

        /// <summary>
        /// The property is immutable and can only be set to true at the account creation time. When set to true, it enables object level immutability for all the new containers in the account by default.
        /// </summary>
        [JsonPropertyName("immutableStorageWithVersioning")]
        public ImmutableStorageAccount ImmutableStorageWithVersioning { get; set; }

        /// <summary>
        /// Allows you to specify the type of endpoint. Set this to AzureDNSZone to create a large number of accounts in a single subscription, which creates accounts in an Azure DNS Zone and the endpoint URL will have an alphanumeric DNS Zone identifier.
        /// </summary>
        [JsonPropertyName("dnsEndpointType")]
        public string DnsEndpointType { get; set; }

        /// <summary>
        /// Gets the status of the storage account at the time the operation was called.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets the URLs that are used to perform a retrieval of a public blob, queue, or table object. Note that Standard_ZRS and Premium_LRS accounts only return the blob endpoint.
        /// </summary>
        [JsonPropertyName("primaryEndpoints")]
        public Endpoints PrimaryEndpoints { get; set; }

        /// <summary>
        /// Gets the location of the primary data center for the storage account.
        /// </summary>
        [JsonPropertyName("primaryLocation")]
        public string PrimaryLocation { get; set; }

        /// <summary>
        /// Gets the status indicating whether the primary location of the storage account is available or unavailable.
        /// </summary>
        [JsonPropertyName("statusOfPrimary")]
        public string StatusOfPrimary { get; set; }

        /// <summary>
        /// Gets the timestamp of the most recent instance of a failover to the secondary location. Only the most recent timestamp is retained. This element is not returned if there has never been a failover instance. Only available if the accountType is Standard_GRS or Standard_RAGRS.
        /// </summary>
        [JsonPropertyName("lastGeoFailoverTime")]
        public string LastGeoFailoverTime { get; set; }

        /// <summary>
        /// Gets the location of the geo-replicated secondary for the storage account. Only available if the accountType is Standard_GRS or Standard_RAGRS.
        /// </summary>
        [JsonPropertyName("secondaryLocation")]
        public string SecondaryLocation { get; set; }

        /// <summary>
        /// Gets the status indicating whether the secondary location of the storage account is available or unavailable. Only available if the SKU name is Standard_GRS or Standard_RAGRS.
        /// </summary>
        [JsonPropertyName("statusOfSecondary")]
        public string StatusOfSecondary { get; set; }

        /// <summary>
        /// Gets the creation date and time of the storage account in UTC.
        /// </summary>
        [JsonPropertyName("creationTime")]
        public string CreationTime { get; set; }

        /// <summary>
        /// Storage account keys creation time.
        /// </summary>
        [JsonPropertyName("keyCreationTime")]
        public KeyCreationTime KeyCreationTime { get; set; }

        /// <summary>
        /// Gets the URLs that are used to perform a retrieval of a public blob, queue, or table object from the secondary location of the storage account. Only available if the SKU name is Standard_RAGRS.
        /// </summary>
        [JsonPropertyName("secondaryEndpoints")]
        public Endpoints SecondaryEndpoints { get; set; }

        /// <summary>
        /// Geo Replication Stats
        /// </summary>
        [JsonPropertyName("geoReplicationStats")]
        public GeoReplicationStats GeoReplicationStats { get; set; }

        /// <summary>
        /// If the failover is in progress, the value will be true, otherwise, it will be null.
        /// </summary>
        [JsonPropertyName("failoverInProgress")]
        public bool FailoverInProgress { get; set; }

        /// <summary>
        /// List of private endpoint connection associated with the specified storage account
        /// </summary>
        [JsonPropertyName("privateEndpointConnections")]
        public IList<PrivateEndpointConnection> PrivateEndpointConnections { get; set; }

        /// <summary>
        /// Blob restore status
        /// </summary>
        [JsonPropertyName("blobRestoreStatus")]
        public BlobRestoreStatus BlobRestoreStatus { get; set; }

        /// <summary>
        /// This property is readOnly and is set by server during asynchronous storage account sku conversion operations.
        /// </summary>
        [JsonPropertyName("storageAccountSkuConversionStatus")]
        public StorageAccountSkuConversionStatus StorageAccountSkuConversionStatus { get; set; }
    }
}