using AzureDesignStudio.Core.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace AzureDesignStudio.Core.Tests
{
    public class TestBase
    {
        private readonly ResourceManagementClient managementClient;

        public TestBase()
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

        protected async Task<DeploymentValidateResultInner> ValidateTemplate(ArmTemplate armTemplate, string parameters = null!)
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
    }
}
