using AzureDesignStudio.Core.AppService;
using AzureDesignStudio.Core.Models;
//using AzureDesignStudio.Core.ResourceGroup;
using AzureDesignStudio.Core.SQL;
using AzureDesignStudio.Core.Network;
using Blazor.Diagrams.Core.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace AzureDesignStudio.Core.Tests
{
    public class ArmTests
    {
        private readonly ResourceManagementClient managementClient;

        public ArmTests()
        {
            var credentials = SdkContext.AzureCredentialsFactory
                .FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

            var azure = Azure.Configure().Authenticate(credentials).WithDefaultSubscription();
            var restClient = RestClient.Configure()
                .WithEnvironment(AzureEnvironment.AzureGlobalCloud)
                .WithCredentials(credentials)
                .Build();

            managementClient = new ResourceManagementClient(restClient)
            {
                SubscriptionId = azure.SubscriptionId
            };
        }

        async Task<DeploymentValidateResultInner> ValidateTemplate(ArmTemplate armTemplate, string parameters = null!)
        {
            var armString = armTemplate.GenerateArmTemplate();

            var obj = JObject.Parse(armString);
            DeploymentInner di;
            if (parameters == null)
                di = new DeploymentInner()
                {
                    Properties = new DeploymentProperties()
                    {
                        Template = obj,
                    }
                };
            else
            {
                var p = JObject.Parse(parameters);
                di = new DeploymentInner()
                {
                    Properties = new DeploymentProperties()
                    {
                        Template = obj,
                        Parameters = p
                    }
                };
            }
            var validateRes = await managementClient.Deployments.ValidateAsync("ads-arm-test-rg", "ads-arm-test",
                                di);

            return validateRes;
        }

        //[Fact]
        //public async void RgTest()
        //{
        //    var rg = new ResourceGroupModel()
        //    {
        //        Name = "ads-test-rg",
        //        Location = "southeastasia",
        //    };

        //    var armTemplate = new ArmTemplate(false);
        //    armTemplate.AddResource(rg.GetArmResources());
        //    var armString = JsonSerializer.Serialize(armTemplate.Template,
        //        new JsonSerializerOptions(JsonSerializerDefaults.Web)
        //        {
        //            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        //            WriteIndented = true,
        //        }
        //    );
        //    var template = JObject.Parse(armString);
        //    //var template = JsonConvert.DeserializeObject<JObject>(armString);

        //    var validateRes = await managementClient.Deployments.ValidateAtSubscriptionScopeAsync("ads-arm-test",
        //        new DeploymentInner()
        //        {
        //            Location = "westus",
        //            Properties = new DeploymentProperties()
        //            {
        //                Template = template
        //            }
        //        });

        //    Assert.Null(validateRes.Error);
        //}

        [Fact]
        public async void VnetTest()
        {
            var armTemplate = new ArmTemplate();

            var vnet = new VirtualNetworkModel()
            {
                Name = "ads-vnet",
            };

            armTemplate.AddResource(vnet.GetArmResources());
            var validateRes = await ValidateTemplate(armTemplate);

            Assert.Null(validateRes.Error);

            vnet.UseResourceGroupLocation = false;
            vnet.Location = "westus";

            armTemplate.RemoveAllResources();
            armTemplate.AddResource(vnet.GetArmResources());
            validateRes = await ValidateTemplate(armTemplate);

            Assert.Null(validateRes.Error);

            vnet.UseResourceGroupLocation = true;
            vnet.AddSubnet(new SubnetModel()
            {
                Name = "subnet1",
                AddressPrefix = "10.0.0.0/24"
            });
            vnet.AddSubnet(new SubnetModel()
            {
                Name = "subnet2",
                AddressPrefix = "10.0.1.0/24"
            });

            armTemplate.RemoveAllResources();
            armTemplate.AddResource(vnet.GetArmResources());
            validateRes = await ValidateTemplate(armTemplate);
            Assert.Null(validateRes.Error);
        }

        [Fact]
        public async Task PipAndBastionTest()
        {
            var vnet = new VirtualNetworkModel()
            {
                Name = "ads-vnet",
            };
            var bastionSubnet = vnet.AddSubnet(new SubnetModel()
            {
                Name = "AzureBastionSubnet",
                AddressPrefix = "10.0.0.0/24"
            });
            var bastion = new BastionsModel()
            {
                Name = "bastion-host",
            };
            bastionSubnet.AddChild(bastion);

            var firewallSubnet = vnet.AddSubnet(new SubnetModel()
            {
                Name = "AzureFirewallSubnet",
                AddressPrefix = "10.0.1.0/24",
            });
            var firewall = new AzureFirewallModel()
            {
                Name = "firewall"
            };
            firewallSubnet.AddChild(firewall);

            var pip = new PublicIpModel()
            {
                Name = "bastion-pip",
            };
            var link = new LinkModel(pip.Ports[0]);
            link.SetSourcePort(pip.Ports[1]);
            link.SetTargetPort(bastion.Ports[0]);

            var fwpip = new PublicIpModel()
            {
                Name = "firewall-pip",
            };
            var fwlink = new LinkModel(fwpip.Ports[0]);
            fwlink.SetSourcePort(fwpip.Ports[1]);
            fwlink.SetTargetPort(firewall.Ports[0]);

            var armTemplate = new ArmTemplate();
            armTemplate.AddResource(vnet.GetArmResources());
            armTemplate.AddResource(pip.GetArmResources());
            armTemplate.AddResource(bastion.GetArmResources());
            armTemplate.AddResource(fwpip.GetArmResources());
            armTemplate.AddResource(firewall.GetArmResources());

            var validateRes = await ValidateTemplate(armTemplate);
            Assert.Null(validateRes.Error);
        }

        [Fact]
        public async Task SqlServerTest()
        {
            var armTemplate = new ArmTemplate();

            var sqlServer = new SqlServerModel()
            {
                Name = "azsqlserver"
            };

            var parameters = new Dictionary<string, dynamic>()
            {
                {"sqlAdmin", new Dictionary<string, string>()
                    {
                        {"value", "dbadmin" }
                    }
                },
                {"sqlAdminPassword", new Dictionary<string, string>()
                    {
                        {"value", "password" }
                    }
                }
            };

            string p = JsonSerializer.Serialize(parameters,
                new JsonSerializerOptions(JsonSerializerDefaults.Web)
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true,
                }
            );

            armTemplate.AddParameters(sqlServer.GetArmParameters());
            armTemplate.AddResource(sqlServer.GetArmResources());

            var validateRes = await ValidateTemplate(armTemplate, p);
            Assert.Null(validateRes?.Error);
        }

        [Fact]
        public async Task SqlDatabaseTest()
        {
            var armTemplate = new ArmTemplate();

            var sqlServer = new SqlServerModel()
            {
                Name = "azsqlserver"
            };

            var parameters = new Dictionary<string, dynamic>()
            {
                {"sqlAdmin", new Dictionary<string, string>()
                    {
                        {"value", "dbadmin" }
                    }
                },
                {"sqlAdminPassword", new Dictionary<string, string>()
                    {
                        {"value", "password" }
                    }
                }
            };

            string p = JsonSerializer.Serialize(parameters,
                new JsonSerializerOptions(JsonSerializerDefaults.Web)
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true,
                }
            );

            armTemplate.AddParameters(sqlServer.GetArmParameters());
            armTemplate.AddResource(sqlServer.GetArmResources());

            var sqlDatabase = new SqlDatabaseModel()
            {
                Name = "azsqldb1",
                Group = sqlServer,
            };

            armTemplate.AddResource(sqlDatabase.GetArmResources());

            var validateRes = await ValidateTemplate(armTemplate, p);
            Assert.Null(validateRes?.Error);
        }

        [Fact]
        public async Task AppServicePlanTest()
        {
            var armTemplate = new ArmTemplate();

            var appServicePlan = new AppServicePlanModel()
            {
                Name = "azappserviceplan"
            };

            armTemplate.AddResource(appServicePlan.GetArmResources());

            var validateRes = await ValidateTemplate(armTemplate);
            Assert.Null(validateRes?.Error);
        }
        [Fact]
        public async Task WebAppTest()
        {
            var armTemplate = new ArmTemplate();

            var appServicePlan = new AppServicePlanModel()
            {
                Name = "azappserviceplan"
            };
            armTemplate.AddResource(appServicePlan.GetArmResources());

            var webApp = new WebAppModel()
            {
                Name = "testwebapp4365",
                //Group = appServicePlan,
                RuntimeStack = "NODE|14-lts"
            };
            appServicePlan.AddChild(webApp);

            armTemplate.AddResource(webApp.GetArmResources());

            var validateRes = await ValidateTemplate(armTemplate);
            Assert.Null(validateRes?.Error);
        }
    }
}