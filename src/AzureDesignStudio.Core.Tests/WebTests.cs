using AzureDesignStudio.Core.Web;
using AzureDesignStudio.Core.Models;
using System.Threading.Tasks;
using Xunit;

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

            var validateRes = await ValidateTemplate(armTemplate);
            Assert.Null(validateRes?.Error);
        }
    }
}
