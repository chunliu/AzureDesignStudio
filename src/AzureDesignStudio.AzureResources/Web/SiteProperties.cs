// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Web
{
    /// <summary>
    /// SiteProperties
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class SiteProperties
    {
        /// <summary>
        /// Current state of the app.
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }

        /// <summary>
        /// Hostnames associated with the app.
        /// </summary>
        [JsonPropertyName("hostNames")]
        public IList<string> HostNames { get; set; }

        /// <summary>
        /// Name of the repository site.
        /// </summary>
        [JsonPropertyName("repositorySiteName")]
        public string RepositorySiteName { get; set; }

        /// <summary>
        /// State indicating whether the app has exceeded its quota usage. Read-only.
        /// </summary>
        [JsonPropertyName("usageState")]
        public string UsageState { get; set; }

        /// <summary>
        /// <code>true</code> if the app is enabled; otherwise, <code>false</code>. Setting this value to false disables the app (takes the app offline).
        /// </summary>
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Enabled hostnames for the app.Hostnames need to be assigned (see HostNames) AND enabled. Otherwise,
        [JsonPropertyName("enabledHostNames")]
        public IList<string> EnabledHostNames { get; set; }

        /// <summary>
        /// Management information availability state for the app.
        /// </summary>
        [JsonPropertyName("availabilityState")]
        public string AvailabilityState { get; set; }

        /// <summary>
        /// Hostname SSL states are used to manage the SSL bindings for app's hostnames.
        /// </summary>
        [JsonPropertyName("hostNameSslStates")]
        public IList<HostNameSslState> HostNameSslStates { get; set; }

        /// <summary>
        /// Resource ID of the associated App Service plan, formatted as: "/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}".
        /// </summary>
        [JsonPropertyName("serverFarmId")]
        public string ServerFarmId { get; set; }

        /// <summary>
        /// <code>true</code> if reserved; otherwise, <code>false</code>.
        /// </summary>
        [JsonPropertyName("reserved")]
        public bool Reserved { get; set; }

        /// <summary>
        /// Obsolete: Hyper-V sandbox.
        /// </summary>
        [JsonPropertyName("isXenon")]
        public bool IsXenon { get; set; }

        /// <summary>
        /// Hyper-V sandbox.
        /// </summary>
        [JsonPropertyName("hyperV")]
        public bool HyperV { get; set; }

        /// <summary>
        /// Last time the app was modified, in UTC. Read-only.
        /// </summary>
        [JsonPropertyName("lastModifiedTimeUtc")]
        public string LastModifiedTimeUtc { get; set; }

        /// <summary>
        /// Virtual Network Route All enabled. This causes all outbound traffic to have Virtual Network Security Groups and User Defined Routes applied.
        /// </summary>
        [JsonPropertyName("vnetRouteAllEnabled")]
        public bool VnetRouteAllEnabled { get; set; }

        /// <summary>
        /// To enable pulling image over Virtual Network
        /// </summary>
        [JsonPropertyName("vnetImagePullEnabled")]
        public bool VnetImagePullEnabled { get; set; }

        /// <summary>
        /// To enable accessing content over virtual network
        /// </summary>
        [JsonPropertyName("vnetContentShareEnabled")]
        public bool VnetContentShareEnabled { get; set; }

        /// <summary>
        /// Configuration of the app.
        /// </summary>
        [JsonPropertyName("siteConfig")]
        public SiteConfig SiteConfig { get; set; }

        /// <summary>
        /// Azure Traffic Manager hostnames associated with the app. Read-only.
        /// </summary>
        [JsonPropertyName("trafficManagerHostNames")]
        public IList<string> TrafficManagerHostNames { get; set; }

        /// <summary>
        /// <code>true</code> to stop SCM (KUDU) site when the app is stopped; otherwise, <code>false</code>. The default is <code>false</code>.
        /// </summary>
        [JsonPropertyName("scmSiteAlsoStopped")]
        public bool ScmSiteAlsoStopped { get; set; }

        /// <summary>
        /// Specifies which deployment slot this app will swap into. Read-only.
        /// </summary>
        [JsonPropertyName("targetSwapSlot")]
        public string TargetSwapSlot { get; set; }

        /// <summary>
        /// App Service Environment to use for the app.
        /// </summary>
        [JsonPropertyName("hostingEnvironmentProfile")]
        public HostingEnvironmentProfile HostingEnvironmentProfile { get; set; }

        /// <summary>
        /// <code>true</code> to enable client affinity; <code>false</code> to stop sending session affinity cookies, which route client requests in the same session to the same instance. Default is <code>true</code>.
        /// </summary>
        [JsonPropertyName("clientAffinityEnabled")]
        public bool ClientAffinityEnabled { get; set; }

        /// <summary>
        /// <code>true</code> to enable client certificate authentication (TLS mutual authentication); otherwise, <code>false</code>. Default is <code>false</code>.
        /// </summary>
        [JsonPropertyName("clientCertEnabled")]
        public bool ClientCertEnabled { get; set; }

        /// <summary>
        /// This composes with ClientCertEnabled setting.
        [JsonPropertyName("clientCertMode")]
        public string ClientCertMode { get; set; }

        /// <summary>
        /// client certificate authentication comma-separated exclusion paths
        /// </summary>
        [JsonPropertyName("clientCertExclusionPaths")]
        public string ClientCertExclusionPaths { get; set; }

        /// <summary>
        /// <code>true</code> to disable the public hostnames of the app; otherwise, <code>false</code>.
        [JsonPropertyName("hostNamesDisabled")]
        public bool HostNamesDisabled { get; set; }

        /// <summary>
        /// Unique identifier that verifies the custom domains assigned to the app. Customer will add this id to a txt record for verification.
        /// </summary>
        [JsonPropertyName("customDomainVerificationId")]
        public string CustomDomainVerificationId { get; set; }

        /// <summary>
        /// List of IP addresses that the app uses for outbound connections (e.g. database access). Includes VIPs from tenants that site can be hosted with current settings. Read-only.
        /// </summary>
        [JsonPropertyName("outboundIpAddresses")]
        public string OutboundIpAddresses { get; set; }

        /// <summary>
        /// List of IP addresses that the app uses for outbound connections (e.g. database access). Includes VIPs from all tenants except dataComponent. Read-only.
        /// </summary>
        [JsonPropertyName("possibleOutboundIpAddresses")]
        public string PossibleOutboundIpAddresses { get; set; }

        /// <summary>
        /// Size of the function container.
        /// </summary>
        [JsonPropertyName("containerSize")]
        public int ContainerSize { get; set; }

        /// <summary>
        /// Maximum allowed daily memory-time quota (applicable on dynamic apps only).
        /// </summary>
        [JsonPropertyName("dailyMemoryTimeQuota")]
        public int DailyMemoryTimeQuota { get; set; }

        /// <summary>
        /// App suspended till in case memory-time quota is exceeded.
        /// </summary>
        [JsonPropertyName("suspendedTill")]
        public string SuspendedTill { get; set; }

        /// <summary>
        /// Maximum number of workers.
        [JsonPropertyName("maxNumberOfWorkers")]
        public int MaxNumberOfWorkers { get; set; }

        /// <summary>
        /// If specified during app creation, the app is cloned from a source app.
        /// </summary>
        [JsonPropertyName("cloningInfo")]
        public CloningInfo CloningInfo { get; set; }

        /// <summary>
        /// Name of the resource group the app belongs to. Read-only.
        /// </summary>
        [JsonPropertyName("resourceGroup")]
        public string ResourceGroup { get; set; }

        /// <summary>
        /// <code>true</code> if the app is a default container; otherwise, <code>false</code>.
        /// </summary>
        [JsonPropertyName("isDefaultContainer")]
        public bool IsDefaultContainer { get; set; }

        /// <summary>
        /// Default hostname of the app. Read-only.
        /// </summary>
        [JsonPropertyName("defaultHostName")]
        public string DefaultHostName { get; set; }

        /// <summary>
        /// Status of the last deployment slot swap operation.
        /// </summary>
        [JsonPropertyName("slotSwapStatus")]
        public SlotSwapStatus SlotSwapStatus { get; set; }

        /// <summary>
        /// HttpsOnly: configures a web site to accept only https requests. Issues redirect for
        [JsonPropertyName("httpsOnly")]
        public bool HttpsOnly { get; set; }

        /// <summary>
        /// Site redundancy mode
        /// </summary>
        [JsonPropertyName("redundancyMode")]
        public string RedundancyMode { get; set; }

        /// <summary>
        /// Specifies an operation id if this site has a pending operation.
        /// </summary>
        [JsonPropertyName("inProgressOperationId")]
        public string InProgressOperationId { get; set; }

        /// <summary>
        /// Property to allow or block all public traffic. Allowed Values: 'Enabled', 'Disabled' or an empty string.
        /// </summary>
        [JsonPropertyName("publicNetworkAccess")]
        public string PublicNetworkAccess { get; set; }

        /// <summary>
        /// Checks if Customer provided storage account is required
        /// </summary>
        [JsonPropertyName("storageAccountRequired")]
        public bool StorageAccountRequired { get; set; }

        /// <summary>
        /// Identity to use for Key Vault Reference authentication.
        /// </summary>
        [JsonPropertyName("keyVaultReferenceIdentity")]
        public string KeyVaultReferenceIdentity { get; set; }

        /// <summary>
        /// Azure Resource Manager ID of the Virtual network and subnet to be joined by Regional VNET Integration.
        [JsonPropertyName("virtualNetworkSubnetId")]
        public string VirtualNetworkSubnetId { get; set; }
    }
}