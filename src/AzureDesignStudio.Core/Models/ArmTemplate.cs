using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDesignStudio.Core.Models
{
    public class ArmTemplate
    {
        public IDictionary<string, dynamic> Template { get; } = new Dictionary<string, dynamic>()
        {
            {"$schema", "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#" },
            {"contentVersion", "1.0.0.0" },
            //{"apiProfile", "" },
            {"parameters", new Dictionary<string, dynamic>()},
            {"variables", new Dictionary<string, dynamic>()},
            {"resources", new List<IDictionary<string, dynamic>>()}
        };

        public ArmTemplate(bool useResourceGroupLocation = true)
        {
            if (useResourceGroupLocation)
                UseLocationParameter();
        }

        protected void UseLocationParameter()
        {
            Template["parameters"].Add("location", new Dictionary<string, dynamic>()
            {
                {"type", "string" },
                {"defaultValue", "[resourceGroup().location]" },
                {"metadata", new Dictionary<string, string>()
                    {
                        {"description", "Location for all resources."},
                    }
                },
            });
        }

        public void SetApiProfile(string apiProfile)
        {
            // apiProfile is optional so don't include it by default.
            if (!string.IsNullOrEmpty(apiProfile))
                Template.Add("apiProfile", apiProfile);
        }

        public void AddResource(IDictionary<string, dynamic> resource)
        {
            Template["resources"].Add(resource);
        }

        public void AddResource(IList<IDictionary<string, dynamic>> resources)
        {
            Template["resources"].AddRange(resources);
        }

        public void AddParameters(IDictionary<string, dynamic> parameters)
        {
            //Template["parameters"].AddRange(parameters);
            foreach (var parameter in parameters)
            {
                Template["parameters"].Add(parameter.Key, parameter.Value);
            }
        }

        public void RemoveAllResources()
        {
            Template["resources"].Clear();
        }
    }
}
