using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using AzureDesignStudio.Core.Models;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AzureDesignStudio.Core.Tests
{
    public class TestBase
    {
        const string _testRgName = "ads-arm-test-rg";
        const string _deploymentName = "ads-test-deployment";
        readonly ArmDeploymentResource _deployment = null!;

        public TestBase()
        {
            var armClient = new ArmClient(new AzureCliCredential());
            var subResource = armClient.GetDefaultSubscription();
            var testRg = subResource.GetResourceGroup(_testRgName)?.Value;
            if (testRg == null)
            {
                throw new Exception("Resource group cannot be found.");
            }
            var deploymentId = ArmDeploymentResource.CreateResourceIdentifier(testRg.Id.ToString(), _deploymentName);
            _deployment = armClient.GetArmDeploymentResource(deploymentId);
        }

        protected async Task ValidateTemplate(ArmTemplate armTemplate, string? parameters = null)
        {
            var template = armTemplate.GenerateArmTemplate();
            var param = parameters ?? "{}";
            var operation = await _deployment.ValidateAsync(Azure.WaitUntil.Completed,
                new ArmDeploymentContent(new ArmDeploymentProperties(ArmDeploymentMode.Complete)
                {
                    Template = BinaryData.FromString(template),
                    Parameters = BinaryData.FromString(param)
                }));

            var result = operation.HasValue ? operation.Value : null;

            Assert.NotNull(result);
            Assert.Null(result.Error);
        }
    }
}
