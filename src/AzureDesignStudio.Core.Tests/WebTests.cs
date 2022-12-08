using AzureDesignStudio.Core.Web;
using AzureDesignStudio.Core.Models;
using System.Threading.Tasks;
using Xunit;
using AzureDesignStudio.Core.Network;

namespace AzureDesignStudio.Core.Tests
{
    public class WebTests : TestBase
    {
        public WebTests() : base() { }

        [Fact]
        public async Task AppServicePlanTest()
        {
            var armTemplate = new ArmTemplate();

            var appServicePlan = new AppServicePlanModel()
            {
                Name = "azappserviceplan"
            };

            armTemplate.AddResource(appServicePlan.GetArmResources());

            await ValidateTemplate(armTemplate);
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

            await ValidateTemplate(armTemplate);
        }
        [Fact]
        public async Task FuncAppTest()
        {
            var armTemplate = new ArmTemplate();

            var appServicePlan = new AppServicePlanModel()
            {
                Name = "azappserviceplan"
            };
            armTemplate.AddResource(appServicePlan.GetArmResources());

            var funcApp = new FunctionAppModel()
            {
                Name = "funcapp3425",
                RuntimeStack = "NODE|14-lts",
                HostingPlan = "asp"
            };
            appServicePlan.AddChild(funcApp);
            armTemplate.AddResource(funcApp.GetArmResources());

            await ValidateTemplate(armTemplate);
        }
        [Fact]
        public async Task WebAppInVnetTest()
        {
            var armTemplate = new ArmTemplate();

            var vnet = new VirtualNetworkModel()
            {
                Name = "ads-vnet",
            };

            var webappSubnet = new SubnetModel()
            {
                Name = "subnet1",
                AddressPrefix = "10.0.0.0/24"
            };
            vnet.AddSubnet(webappSubnet);

            var appServicePlan = new AppServicePlanModel()
            {
                Name = "azappserviceplan"
            };
            webappSubnet.AddChild(appServicePlan);

            var webApp = new WebAppModel()
            {
                Name = "testwebapp4365",
                //Group = appServicePlan,
                RuntimeStack = "NODE|14-lts"
            };
            appServicePlan.AddChild(webApp);

            armTemplate.AddResource(vnet.GetArmResources());
            armTemplate.AddResource(appServicePlan.GetArmResources());
            armTemplate.AddResource(webApp.GetArmResources());

            await ValidateTemplate(armTemplate);
        }
    }
}
