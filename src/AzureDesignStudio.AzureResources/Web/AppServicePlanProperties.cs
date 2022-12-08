// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Web
{
    /// <summary>
    /// AppServicePlanProperties
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class AppServicePlanProperties
    {
        /// <summary>
        /// Target worker tier assigned to the App Service plan.
        /// </summary>
        [JsonPropertyName("workerTierName")]
        public string WorkerTierName { get; set; }

        /// <summary>
        /// App Service plan status.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// App Service plan subscription.
        /// </summary>
        [JsonPropertyName("subscription")]
        public string Subscription { get; set; }

        /// <summary>
        /// Specification for the App Service Environment to use for the App Service plan.
        /// </summary>
        [JsonPropertyName("hostingEnvironmentProfile")]
        public HostingEnvironmentProfile HostingEnvironmentProfile { get; set; }

        /// <summary>
        /// Maximum number of instances that can be assigned to this App Service plan.
        /// </summary>
        [JsonPropertyName("maximumNumberOfWorkers")]
        public int MaximumNumberOfWorkers { get; set; }

        /// <summary>
        /// The number of instances that are assigned to this App Service plan.
        /// </summary>
        [JsonPropertyName("numberOfWorkers")]
        public int NumberOfWorkers { get; set; }

        /// <summary>
        /// Geographical location for the App Service plan.
        /// </summary>
        [JsonPropertyName("geoRegion")]
        public string GeoRegion { get; set; }

        /// <summary>
        /// If <code>true</code>, apps assigned to this App Service plan can be scaled independently.
        [JsonPropertyName("perSiteScaling")]
        public bool PerSiteScaling { get; set; }

        /// <summary>
        /// ServerFarm supports ElasticScale. Apps in this plan will scale as if the ServerFarm was ElasticPremium sku
        /// </summary>
        [JsonPropertyName("elasticScaleEnabled")]
        public bool ElasticScaleEnabled { get; set; }

        /// <summary>
        /// Maximum number of total workers allowed for this ElasticScaleEnabled App Service Plan
        /// </summary>
        [JsonPropertyName("maximumElasticWorkerCount")]
        public int MaximumElasticWorkerCount { get; set; }

        /// <summary>
        /// Number of apps assigned to this App Service plan.
        /// </summary>
        [JsonPropertyName("numberOfSites")]
        public int NumberOfSites { get; set; }

        /// <summary>
        /// If <code>true</code>, this App Service Plan owns spot instances.
        /// </summary>
        [JsonPropertyName("isSpot")]
        public bool IsSpot { get; set; }

        /// <summary>
        /// The time when the server farm expires. Valid only if it is a spot server farm.
        /// </summary>
        [JsonPropertyName("spotExpirationTime")]
        public string SpotExpirationTime { get; set; }

        /// <summary>
        /// The time when the server farm free offer expires.
        /// </summary>
        [JsonPropertyName("freeOfferExpirationTime")]
        public string FreeOfferExpirationTime { get; set; }

        /// <summary>
        /// Resource group of the App Service plan.
        /// </summary>
        [JsonPropertyName("resourceGroup")]
        public string ResourceGroup { get; set; }

        /// <summary>
        /// If Linux app service plan <code>true</code>, <code>false</code> otherwise.
        /// </summary>
        [JsonPropertyName("reserved")]
        public bool Reserved { get; set; }

        /// <summary>
        /// Obsolete: If Hyper-V container app service plan <code>true</code>, <code>false</code> otherwise.
        /// </summary>
        [JsonPropertyName("isXenon")]
        public bool IsXenon { get; set; }

        /// <summary>
        /// If Hyper-V container app service plan <code>true</code>, <code>false</code> otherwise.
        /// </summary>
        [JsonPropertyName("hyperV")]
        public bool HyperV { get; set; }

        /// <summary>
        /// Scaling worker count.
        /// </summary>
        [JsonPropertyName("targetWorkerCount")]
        public int TargetWorkerCount { get; set; }

        /// <summary>
        /// Scaling worker size ID.
        /// </summary>
        [JsonPropertyName("targetWorkerSizeId")]
        public int TargetWorkerSizeId { get; set; }

        /// <summary>
        /// Provisioning state of the App Service Plan.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Specification for the Kubernetes Environment to use for the App Service plan.
        /// </summary>
        [JsonPropertyName("kubeEnvironmentProfile")]
        public KubeEnvironmentProfile KubeEnvironmentProfile { get; set; }

        /// <summary>
        /// If <code>true</code>, this App Service Plan will perform availability zone balancing.
        [JsonPropertyName("zoneRedundant")]
        public bool ZoneRedundant { get; set; }
    }
}