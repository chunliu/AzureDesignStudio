using AzureDesignStudio.AzureResources.Base;
using AzureDesignStudio.Core.Common;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.Core.Models
{
    public class ArmTemplate : IArmTemplate
    {
        public DeploymentTemplate Template { get; } = new()
        {
            Schema = "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#",
            ContentVersion = "1.0.0.0",
            Parameters = new Dictionary<string, Parameter>(),
            Variables = new Dictionary<string, object>(),
            Resources = new List<ResourceBase>()
        };

        public ArmTemplate(bool useResourceGroupLocation = true)
        {
            if (useResourceGroupLocation)
                UseLocationParameter();
        }

        protected void UseLocationParameter()
        {
            Template.Parameters.Add("location", new Parameter()
            {
                Type = "string",
                DefaultValue = "[resourceGroup().location]",
                Metadata = new Dictionary<string, string>()
                {
                    {"description", "Location for all resources."}
                }
            });
        }

        public void SetApiProfile(string apiProfile)
        {
            // apiProfile is optional so don't include it by default.
            if (!string.IsNullOrEmpty(apiProfile))
                Template.ApiProfile = apiProfile;
        }

        public void AddResource(ResourceBase resource)
        {
            Template.Resources.Add(resource);
        }

        public void AddResource(IList<ResourceBase> resources)
        {
            foreach(var resource in resources)
            {
                Template.Resources.Add(resource);
            }
        }

        public void AddParameters(IDictionary<string, Parameter> parameters)
        {
            //Template["parameters"].AddRange(parameters);
            foreach (var parameter in parameters)
            {
                Template.Parameters.Add(parameter.Key, parameter.Value);
            }
        }

        public void RemoveAllResources()
        {
            Template.Resources.Clear();
        }

        public string GenerateArmTemplate()
        {
            return JsonSerializer.Serialize(Template,
                new JsonSerializerOptions(JsonSerializerDefaults.Web)
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true,
                    Converters = { new ResourceBaseJsonConverter() }
                });
        }
    }
}
