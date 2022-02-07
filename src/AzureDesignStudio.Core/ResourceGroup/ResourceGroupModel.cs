using AzureDesignStudio.Core.Models;

namespace AzureDesignStudio.Core.ResourceGroup
{
    public class ResourceGroupModel : AzureGroupBase
    {
        public override string ServiceName => "Resource Group";
        public override Type? DataFormType => typeof(ResourceGroupForm);
        public override string ResourceType => "Microsoft.Resources/resourceGroups";
        public override string ApiVersion => "2021-04-01";

        public override IList<IDictionary<string, dynamic>> GetArmResources()
        {
            return new List<IDictionary<string, dynamic>>()
            {
                GetArmResource(),
            };
        }
        private IDictionary<string, dynamic> GetArmResource()
        {
            return new Dictionary<string, dynamic>()
            {
                {"type", ResourceType },
                {"apiVersion", ApiVersion },
                {"name", Name},
                {"location", Location},
                {"properties", Properties },
            };
        }
    }
}
