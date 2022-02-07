using AutoMapper;
using AzureDesignStudio.Core.DTO;
using AzureDesignStudio.Core.Storage;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AzureDesignStudio.Core.AppService
{
    public class FunctionAppModel : WebAppModel
    {
        public override string ServiceName => "Function App";
        public override Type? DataFormType => typeof(FunctionAppForm);
        [Required, DisplayName("Hosting plan")]
        public string HostingPlan { get; set; } = null!;
        public StorageAccountModel StorageAccount = new()
        {
            Kind = "StorageV2",
            SkuName = "Standard_LRS"
        };
        public override string Kind
        {
            get => ServicePlanOS == "linux" ? "functionapp,linux" : "functionapp";
        }
        public override bool IsValid
        {
            get => !string.IsNullOrEmpty(HostingPlan) 
                && (HostingPlan != "consumption" || Publish != "docker")
                && base.IsValid;
        }
        public override AzureNodeDto GetNodeDto(IMapper mapper)
        {
            return mapper.Map<FunctionAppDto>(this);
        }
        private void CreateFuncAppSettings(IDictionary<string, dynamic> siteConfig)
        {
            var appSettings = new List<IDictionary<string, string>>();

            var stacks = RuntimeStack.Split("|");
            if (Publish != "code" || (stacks[0] == "dotnet" && stacks[1] == "v3.1"))
            {
                appSettings.Add(new Dictionary<string, string>
                {
                    {"name", "FUNCTIONS_EXTENSION_VERSION" },
                    {"value", "~3" }
                });
            }
            else
            {
                appSettings.Add(new Dictionary<string, string>
                {
                    {"name", "FUNCTIONS_EXTENSION_VERSION" },
                    {"value", "~4" }
                });
            }

            StorageAccount.Name = "astg" + Name.ToLower();
            appSettings.Add(new Dictionary<string, string>
            {
                {"name", "AzureWebJobsStorage" },
                {"value", $"[concat('DefaultEndpointsProtocol=https;AccountName={StorageAccount.Name};AccountKey=',{StorageAccount.AccountKey})]" }
            });

            if (Publish == "code")
            {
                appSettings.Add(new Dictionary<string, string>
                {
                    {"name", "FUNCTIONS_WORKER_RUNTIME" },
                    {"value", stacks[0] }
                });
                if (stacks[0].Equals("node", StringComparison.InvariantCultureIgnoreCase))
                {
                    appSettings.Add(new Dictionary<string, string>
                    {
                        {"name", "WEBSITE_NODE_DEFAULT_VERSION" },
                        {"value", stacks[1] }
                    });
                }
            }
            if ((ServicePlanOS == "windows" && HostingPlan == "consumption") || HostingPlan == "premium")
            {
                appSettings.Add(new Dictionary<string, string>
                {
                    {"name", "WEBSITE_CONTENTAZUREFILECONNECTIONSTRING" },
                    {"value", $"[concat('DefaultEndpointsProtocol=https;AccountName={StorageAccount.Name};AccountKey=', {StorageAccount.AccountKey})]" }
                });
            }

            siteConfig["appSettings"] = appSettings;
        }
        protected override void CreateSiteConfigForLinuxCode(Dictionary<string, dynamic> siteConfig)
        {
            if (Publish == "code")
            {
                var stacks = RuntimeStack.Split("|");

                siteConfig["linuxFxVersion"] = stacks[0] switch
                {
                    "dotnet" => stacks[1] switch
                    {
                        "v6.0" => "DOTNET|6.0",
                        "v3.1" => "DOTNET|3.1",
                        _ => throw new NotImplementedException(),
                    },
                    "java" => stacks[1] switch
                    {
                        "11" => "JAVA|11",
                        "1.8" => "JAVA|8",
                        _ => throw new NotImplementedException(),
                    },
                    "node" => stacks[1] switch
                    {
                        "~14" => "NODE|14",
                        "~12" => "NODE|12",
                        _ => throw new NotImplementedException(),
                    },
                    _ => RuntimeStack,
                };
            }
            else
            {
                siteConfig["linuxFxVersion"] = "DOCKER|mcr.microsoft.com/azure-functions/dotnet:3.0-appservice-quickstart";
                var appSettings = (siteConfig["appSettings"] as List<IDictionary<string, string>>)!;
                appSettings.Add(new Dictionary<string, string>
                    {
                        {"name", "DOCKER_REGISTRY_SERVER_URL" },
                        {"value", "https://mcr.microsoft.com" }
                    });
                appSettings.Add(new Dictionary<string, string>
                    {
                        {"name", "DOCKER_REGISTRY_SERVER_USERNAME" },
                        {"value", string.Empty }
                    });
                appSettings.Add(new Dictionary<string, string>
                    {
                        {"name", "DOCKER_REGISTRY_SERVER_PASSWORD" },
                        {"value", string.Empty }
                    });
                appSettings.Add(new Dictionary<string, string>
                    {
                        {"name", "WEBSITES_ENABLE_APP_SERVICE_STORAGE" },
                        {"value", "false" }
                    });
            }
        }
        protected override void CreateSiteConfigForWinCode(Dictionary<string, dynamic> siteConfig)
        {
            var stacks = RuntimeStack.Split("|");

            switch (stacks[0])
            {
                case "dotnet":
                    siteConfig["netFrameworkVersion"] = stacks[1];
                    break;
                case "java":
                    siteConfig["javaVersion"] = stacks[1];
                    break;
                case "PowerShell":
                    siteConfig["powerShellVersion"] = "~7";
                    break;
            }
        }
        protected override IDictionary<string, dynamic> CreateSiteConfig()
        {
            var siteConfig = new Dictionary<string, dynamic>
            {
                {"cors", new Dictionary<string, IList<string>>
                    {
                        {"allowedOrigins", new List<string>{ "https://portal.azure.com" } }
                    }
                }
            };

            CreateFuncAppSettings(siteConfig);

            if (ServicePlanOS == "linux")
            {
                CreateSiteConfigForLinuxCode(siteConfig);
            }
            else
            {
                CreateSiteConfigForWinCode(siteConfig);
            }

            return siteConfig;
        }

        public override AppServicePlanModel CreateHostingPlan()
        {
            if (Group is not AppServicePlanModel servicePlan)
                throw new Exception($"{ServiceName} must be in a service plan");

            if (HostingPlan == "consumption" && Publish == "docker")
            {
                throw new Exception($"{ServiceName} doesn't support using docker container on Consumption plan.");
            }

            switch (HostingPlan)
            {
                case "consumption":
                {
                    servicePlan.Kind = ServicePlanOS;
                    servicePlan.SkuName = "Y1";
                    servicePlan.SkuTier = "Dynamic";
                    break;
                }
                case "premium":
                {
                    servicePlan.Kind = ServicePlanOS;
                    servicePlan.SkuName = "EP1";
                    servicePlan.SkuTier = "ElasticPremium";
                    break;
                }
                case "asp":
                {
                    servicePlan.Kind = ServicePlanOS;
                    servicePlan.SkuName = "P1V2";
                    servicePlan.SkuTier = "PremiumV2";
                    break;
                }
                default:
                    base.CreateHostingPlan();
                    break;
            };

            return servicePlan;
        }

        public override IList<IDictionary<string, dynamic>> GetArmResources()
        {
            var result = (base.GetArmResources() as List<IDictionary<string, dynamic>>)!;

            var funcApp = result.FirstOrDefault(d => d["type"] == ResourceType);
            if (funcApp is null || funcApp["dependsOn"] is not List<string> dependsOn)
            {
                throw new Exception($"{ServiceName} is null or has no dependsOn");
            }

            dependsOn.Add(StorageAccount.ResourceId);

            result.AddRange(StorageAccount.GetArmResources());

            return result;
        }
    }
}
