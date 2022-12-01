using AutoMapper;
using AzureDesignStudio.AzureResources.Base;
using AzureDesignStudio.AzureResources.Web;
using AzureDesignStudio.Core.Attributes;
using AzureDesignStudio.Core.Common;
using AzureDesignStudio.Core.DTO;
using AzureDesignStudio.Core.Storage;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AzureDesignStudio.Core.Web
{
    [MapToDto(TypeKey = AdsConstants.FunctionApp, DtoBase = "WebAppModelDto")]
    public class FunctionAppModel : WebAppModel
    {
        public override string ServiceName => "Function App";
        public override Type? DataFormType => typeof(FunctionAppForm);
        [Required, DisplayName("Hosting plan"), MapToDto]
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
            return mapper.Map<FunctionAppModelDto>(this);
        }
        private void CreateFuncAppSettings(ref SiteConfig siteConfig)
        {
            if (siteConfig.AppSettings == null)
                siteConfig.AppSettings = new List<NameValuePair>();

            var stacks = RuntimeStack.Split("|");
            if (Publish != "code" || (stacks[0] == "dotnet" && stacks[1] == "v3.1"))
            {
                siteConfig.AppSettings.Add(new()
                {
                    Name = "FUNCTIONS_EXTENSION_VERSION",
                    Value = "~3"
                });
            }
            else
            {
                siteConfig.AppSettings.Add(new()
                {
                    Name = "FUNCTIONS_EXTENSION_VERSION",
                    Value = "~4"
                });
            }

            StorageAccount.Name = "astg" + Name.ToLower();
            siteConfig.AppSettings.Add(new()
            {
                Name = "AzureWebJobsStorage",
                Value = $"[concat('DefaultEndpointsProtocol=https;AccountName={StorageAccount.Name};AccountKey=',{StorageAccount.AccountKey})]"
            });

            if (Publish == "code")
            {
                siteConfig.AppSettings.Add(new()
                {
                    Name = "FUNCTIONS_WORKER_RUNTIME",
                    Value = stacks[0]
                });
                if (stacks[0].Equals("node", StringComparison.InvariantCultureIgnoreCase))
                {
                    siteConfig.AppSettings.Add(new()
                    {
                        Name = "WEBSITE_NODE_DEFAULT_VERSION",
                        Value = stacks[1]
                    });
                }
            }
            if ((ServicePlanOS == "windows" && HostingPlan == "consumption") || HostingPlan == "premium")
            {
                siteConfig.AppSettings.Add(new()
                {
                    Name = "WEBSITE_CONTENTAZUREFILECONNECTIONSTRING",
                    Value = $"[concat('DefaultEndpointsProtocol=https;AccountName={StorageAccount.Name};AccountKey=', {StorageAccount.AccountKey})]"
                });
            }
        }
        protected override void CreateSiteConfigForLinuxCode(ref SiteConfig siteConfig)
        {
            if (Publish == "code")
            {
                var stacks = RuntimeStack.Split("|");

                siteConfig.LinuxFxVersion = stacks[0] switch
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
                siteConfig.LinuxFxVersion = "DOCKER|mcr.microsoft.com/azure-functions/dotnet:3.0-appservice-quickstart";
                siteConfig.AppSettings ??= new List<NameValuePair>();

                siteConfig.AppSettings.Add(new()
                    {
                        Name = "DOCKER_REGISTRY_SERVER_URL",
                        Value = "https://mcr.microsoft.com"
                    });
                siteConfig.AppSettings.Add(new()
                    {
                        Name = "DOCKER_REGISTRY_SERVER_USERNAME",
                        Value = string.Empty
                    });
                siteConfig.AppSettings.Add(new()
                    {
                        Name = "DOCKER_REGISTRY_SERVER_PASSWORD",
                        Value = string.Empty
                    });
                siteConfig.AppSettings.Add(new()
                    {
                        Name = "WEBSITES_ENABLE_APP_SERVICE_STORAGE",
                        Value = "false"
                    });
            }
        }
        protected override void CreateSiteConfigForWinCode(ref SiteConfig siteConfig)
        {
            var stacks = RuntimeStack.Split("|");

            switch (stacks[0])
            {
                case "dotnet":
                    siteConfig.NetFrameworkVersion = stacks[1];
                    break;
                case "java":
                    siteConfig.JavaVersion = stacks[1];
                    break;
                case "PowerShell":
                    siteConfig.PowerShellVersion = "~7";
                    break;
            }
        }
        protected override SiteConfig CreateSiteConfig()
        {
            SiteConfig siteConfig = new()
            {
                Cors = new()
                {
                    AllowedOrigins = new List<string> { "https://portal.azure.com" },
                }
            };

            CreateFuncAppSettings(ref siteConfig);

            if (ServicePlanOS == "linux")
            {
                CreateSiteConfigForLinuxCode(ref siteConfig);
            }
            else
            {
                CreateSiteConfigForWinCode(ref siteConfig);
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

        public override IList<ResourceBase> GetArmResources()
        {
            var result = base.GetArmResources().ToList();

            ArmResource.DependsOn.Add(StorageAccount.ResourceId);

            result.AddRange(StorageAccount.GetArmResources());

            return result;
        }
    }
}
