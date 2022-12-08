using AutoMapper;
using AzureDesignStudio.AzureResources.Base;
using AzureDesignStudio.AzureResources.Web;
using AzureDesignStudio.Core.Attributes;
using AzureDesignStudio.Core.Common;
using AzureDesignStudio.Core.DTO;
using AzureDesignStudio.Core.Models;
using AzureDesignStudio.Core.Network;
using Blazor.Diagrams.Core.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AzureDesignStudio.Core.Web
{
    [MapToDto(TypeKey = AdsConstants.WebApp)]
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
        private readonly Sites _webapp = new()
        {
            Kind = "app",
            Properties = new()
            {
                ClientAffinityEnabled = false,
            }
        };
        protected override ResourceBase ArmResource => _webapp;
        public virtual string Kind => _webapp.Kind;
        [Required, DisplayName("Publish"), MapToDto]
        public string Publish { get; set; } = "code";
        [Required, DisplayName("Runtime"), MapToDto]
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
            return mapper.Map<WebAppModelDto>(this);
        }
        protected virtual SiteConfig CreateSiteConfig()
        {
            SiteConfig siteConfig = new()
            {
                AlwaysOn = true,
            };

            if (ServicePlanOS == "linux")
            {
                if (Publish == "code")
                {
                    CreateSiteConfigForLinuxCode(ref siteConfig);
                }
                else
                {
                    siteConfig.LinuxFxVersion = "DOCKER|mcr.microsoft.com/appsvc/staticsite:latest";
                    siteConfig.AppSettings = new List<NameValuePair>()
                    {
                        new()
                        {
                            Name = "DOCKER_REGISTRY_SERVER_URL",
                            Value = "https://mcr.microsoft.com",
                        },
                        new()
                        {
                            Name = "DOCKER_REGISTRY_SERVER_USERNAME",
                            Value = string.Empty,
                        },
                        new()
                        {
                            Name = "DOCKER_REGISTRY_SERVER_PASSWORD",
                            Value = string.Empty,
                        },
                        new()
                        {
                            Name = "WEBSITES_ENABLE_APP_SERVICE_STORAGE",
                            Value = "false",
                        },
                    };
                }
            }
            else
            {
                if (Publish == "code")
                {
                    CreateSiteConfigForWinCode(ref siteConfig);
                }
                else
                {
                    siteConfig.WindowsFxVersion = "DOCKER|mcr.microsoft.com/azure-app-service/windows/parkingpage:latest";
                    siteConfig.AppSettings = new List<NameValuePair>()
                    {
                        new()
                        {
                            Name = "DOCKER_REGISTRY_SERVER_URL",
                            Value = "https://mcr.microsoft.com",
                        },
                        new()
                        {
                            Name = "DOCKER_REGISTRY_SERVER_USERNAME",
                            Value = string.Empty,
                        },
                        new()
                        {
                            Name = "DOCKER_REGISTRY_SERVER_PASSWORD",
                            Value = string.Empty,
                        },
                        new()
                        {
                            Name = "WEBSITES_ENABLE_APP_SERVICE_STORAGE",
                            Value = "false",
                        },
                    };
                }
            }

            return siteConfig;
        }
        protected virtual void CreateSiteConfigForLinuxCode(ref SiteConfig siteConfig)
        {
            var stacks = RuntimeStack.Split("|");

            siteConfig.LinuxFxVersion = stacks[0] switch
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
        protected virtual void CreateSiteConfigForWinCode(ref SiteConfig siteConfig)
        {
            var stacks = RuntimeStack.Split("|");
            //siteConfig["metadata"] = new List<IDictionary<string, string>>()
            //{
            //    new Dictionary<string, string>
            //    {
            //        {"name", "CURRENT_STACK" },
            //        {"value", stacks[0] }
            //    }
            //};

            switch(stacks[0])
            {
                case "dotnet":
                    siteConfig.NetFrameworkVersion = stacks[1];
                    break;
                case "java":
                    siteConfig.JavaVersion = stacks[1];
                    siteConfig.JavaContainer = "JAVA";
                    siteConfig.JavaContainerVersion = "SE";
                    break;
                case "node":
                    siteConfig.NodeVersion = stacks[1];
                    siteConfig.AppSettings = new List<NameValuePair>()
                    {
                        new()
                        {
                            Name = "WEBSITE_NODE_DEFAULT_VERSION",
                            Value = stacks[1],
                        },
                    };
                    break;
                case "php":
                    siteConfig.PhpVersion = stacks[1];
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

        protected override void PopulateArmAttributes()
        {
            base.PopulateArmAttributes();

            if (!IsValid)
            {
                throw new Exception($"{ServiceName} is invalid for ARM exporting.");
            }

            var appSvcPlan = CreateHostingPlan();
            _webapp.Properties.SiteConfig = CreateSiteConfig();
            _webapp.Properties.ServerFarmId = appSvcPlan.ResourceId;
            _webapp.DependsOn = new List<string> { appSvcPlan.ResourceId };

            if (appSvcPlan.Group is SubnetModel subnet)
            {
                _webapp.DependsOn.Add(subnet.ResourceId);
                //_webapp.Resources = new List<ResourceBase>
                //{
                //    CreateNetworkConfig(subnet)
                //};
            }
        }
        private NetworkConfig CreateNetworkConfig(SubnetModel subnet)
        {
            return new NetworkConfig
            {
                Name = $"{Name}/virtualNetwork",
                Kind = Kind,
                Properties = new()
                {
                    SubnetResourceId = subnet.ResourceId,
                    SwiftSupported = true,
                },
                DependsOn = new List<string>
                {
                    ResourceId,
                    subnet.ResourceId,
                }
            };
        }
    }
}
