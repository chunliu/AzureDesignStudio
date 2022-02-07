using AutoMapper;
using AzureDesignStudio.Core.DTO;
using AzureDesignStudio.Core.Models;
using AzureDesignStudio.Core.VirtualNetwork;
using Blazor.Diagrams.Core.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AzureDesignStudio.Core.AppService
{
    public class WebAppModel : AzureNodeBase
    {
        public WebAppModel() : base()
        {
            AddPort(PortAlignment.Left);
            AddPort(PortAlignment.Top);
            AddPort(PortAlignment.Right);
            AddPort(PortAlignment.Bottom);
        }
        public override (bool result, string message) IsDrappable(GroupModel overlappedGroup)
        {
            if (overlappedGroup is not AppServicePlanModel)
                return (false, $"{ServiceName} can only be deployed in an App Service Plan");

            return (true, string.Empty);
        }
        public override string ServiceName => "Web App";
        public override Type? DataFormType => typeof(WebAppForm);
        public override string ResourceType => "Microsoft.Web/sites";
        public override string ApiVersion => "2021-02-01";
        public virtual string Kind { get; } = "app";
        [Required, DisplayName("Publish")]
        public string Publish { get; set; } = "code";
        [Required, DisplayName("Runtime")]
        public string RuntimeStack { get; set; } = null!;
        [Required, DisplayName("OS")]
        public string ServicePlanOS 
        {
            get => (Group as AppServicePlanModel)!.Kind;
            set => (Group as AppServicePlanModel)!.Kind = value;
        }
        public override bool IsValid
        {
            get => !(Publish == "code" && string.IsNullOrEmpty(RuntimeStack));
        }
        public override AzureNodeDto GetNodeDto(IMapper mapper)
        {
            return mapper.Map<WebAppDto>(this);
        }
        protected virtual IDictionary<string, dynamic> CreateSiteConfig()
        {
            var siteConfig = new Dictionary<string, dynamic>
            {
                {"alwaysOn", "true" }
            };

            if (ServicePlanOS == "linux")
            {
                if (Publish == "code")
                {
                    CreateSiteConfigForLinuxCode(siteConfig);
                }
                else
                {
                    siteConfig["linuxFxVersion"] = "DOCKER|mcr.microsoft.com/appsvc/staticsite:latest";
                    siteConfig["appSettings"] = new List<IDictionary<string, string>>()
                    {
                        new Dictionary<string, string>
                        {
                            {"name", "DOCKER_REGISTRY_SERVER_URL" },
                            {"value", "https://mcr.microsoft.com" }
                        },
                        new Dictionary<string, string>
                        {
                            {"name", "DOCKER_REGISTRY_SERVER_USERNAME" },
                            {"value", string.Empty }
                        },
                        new Dictionary<string, string>
                        {
                            {"name", "DOCKER_REGISTRY_SERVER_PASSWORD" },
                            {"value", string.Empty }
                        },
                        new Dictionary<string, string>
                        {
                            {"name", "WEBSITES_ENABLE_APP_SERVICE_STORAGE" },
                            {"value", "false" }
                        },
                    };
                }
            }
            else
            {
                if (Publish == "code")
                {
                    CreateSiteConfigForWinCode(siteConfig);
                }
                else
                {
                    siteConfig["windowsFxVersion"] = "DOCKER|mcr.microsoft.com/azure-app-service/windows/parkingpage:latest";
                    siteConfig["appSettings"] = new List<IDictionary<string, string>>()
                    {
                        new Dictionary<string, string>
                        {
                            {"name", "DOCKER_REGISTRY_SERVER_URL" },
                            {"value", "https://mcr.microsoft.com" }
                        },
                        new Dictionary<string, string>
                        {
                            {"name", "DOCKER_REGISTRY_SERVER_USERNAME" },
                            {"value", string.Empty }
                        },
                        new Dictionary<string, string>
                        {
                            {"name", "DOCKER_REGISTRY_SERVER_PASSWORD" },
                            {"value", string.Empty }
                        },
                        new Dictionary<string, string>
                        {
                            {"name", "WEBSITES_ENABLE_APP_SERVICE_STORAGE" },
                            {"value", "false" }
                        },
                    };
                }
            }

            return siteConfig;
        }
        protected virtual void CreateSiteConfigForLinuxCode(Dictionary<string, dynamic> siteConfig)
        {
            var stacks = RuntimeStack.Split("|");

            siteConfig["linuxFxVersion"] = stacks[0] switch
            {
                "dotnet" => stacks[1] switch
                {
                    "v6.0" => "DOTNETCORE|6.0",
                    "v5.0" => "DOTNETCORE|5.0",
                    "v3.1" => "DOTNETCORE|3.1",
                    _ => throw new NotImplementedException(),
                },
                "java" => stacks[1] switch
                {
                    "11" => "JAVA|11-java11",
                    "1.8" => "JAVA|8-jre8",
                    _ => throw new NotImplementedException(),
                },
                "node" => stacks[1] switch
                {
                    "~14" => "NODE|14-lts",
                    "~12" => "NODE|12-lts",
                    _ => throw new NotImplementedException(),
                },
                _ => RuntimeStack,
            };
        }
        protected virtual void CreateSiteConfigForWinCode(Dictionary<string, dynamic> siteConfig)
        {
            var stacks = RuntimeStack.Split("|");
            siteConfig["metadata"] = new List<IDictionary<string, string>>()
            {
                new Dictionary<string, string>
                {
                    {"name", "CURRENT_STACK" },
                    {"value", stacks[0] }
                }
            };

            switch(stacks[0])
            {
                case "dotnet":
                    siteConfig["netFrameworkVersion"] = stacks[1];
                    break;
                case "java":
                    siteConfig["javaVersion"] = stacks[1];
                    siteConfig["javaContainer"] = "JAVA";
                    siteConfig["javaContainerVersion"] = "SE";
                    break;
                case "node":
                    siteConfig["nodeVersion"] = stacks[1];
                    siteConfig["appSettings"] = new List<IDictionary<string, string>>()
                    {
                        new Dictionary<string, string>
                        {
                            {"name", "WEBSITE_NODE_DEFAULT_VERSION" },
                            {"value", stacks[1] }
                        },
                    };
                    break;
                case "php":
                    siteConfig["phpVersion"] = stacks[1];
                    break;
            }
        }

        public virtual AppServicePlanModel CreateHostingPlan()
        {
            if (Group is not AppServicePlanModel servicePlan)
                throw new Exception($"{ServiceName} must be in a service plan");
            
            servicePlan.Kind = ServicePlanOS;

            return servicePlan;
        }

        public override IList<IDictionary<string, dynamic>> GetArmResources()
        {
            if (!IsValid)
            {
                throw new Exception($"{ServiceName} is invalid for ARM exporting.");
            }

            var appSvcPlan = CreateHostingPlan();

            Properties.Clear();
            Properties["name"] = Name;
            Properties["siteConfig"] = CreateSiteConfig();
            Properties["clientAffinityEnabled"] = "false";
            Properties["serverFarmId"] = appSvcPlan.ResourceId;

            var dependsOn = new List<string>
            {
                appSvcPlan.ResourceId
            };

            var webapp = new Dictionary<string, dynamic>
            {
                {"type", ResourceType },
                {"apiVersion", ApiVersion },
                {"name", Name },
                {"location", Location },
                {"kind", Kind },
                {"dependsOn", dependsOn },
                {"properties", Properties }
            };

            if (appSvcPlan.Group is SubnetModel subnet)
            {
                dependsOn.Add(subnet.ResourceId);
                webapp["resources"] = new List<IDictionary<string, dynamic>>
                {
                    CreateNetworkConfig(subnet),
                };
            }

            var result = new List<IDictionary<string, dynamic>>
            {
                webapp,
            };

            return result;
        }

        private Dictionary<string, dynamic> CreateNetworkConfig(SubnetModel subnet)
        {
            return new Dictionary<string, dynamic>
            {
                {"type", "networkConfig" },
                {"apiVersion", "2021-02-01" },
                {"name", "virtualNetwork" },
                {"kind", Kind },
                {"properties", new Dictionary<string, string>
                    {
                        {"subnetResourceId", subnet.ResourceId },
                        {"swiftSupported", "true" }
                    }
                },
                {"dependsOn", new List<string>
                    {
                        ResourceId,
                        subnet.ResourceId
                    } 
                }
            };
        }
    }
}
