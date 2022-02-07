using AzureDesignStudio.Core.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AzureDesignStudio.Core.Firewall
{
    public class FirewallPolicyModel : IAzureResource
    {
        public string ResourceId => $"[resourceId('{ResourceType}', '{Name}')]";
        public string ResourceType => "Microsoft.Network/firewallPolicies";
        public string ApiVersion => "2021-03-01";
        [Required, DisplayName("Name")]
        public string Name { get; set; } = "fw-policies";
        private string location = string.Empty;
        public string Location
        {
            get => UseResourceGroupLocation ? "[parameters('location')]" : location;
            set => location = value;
        }
        public bool UseResourceGroupLocation { get; set; } = true;
        public IDictionary<string, string> Tags { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IDictionary<string, dynamic> Properties { get; set; } = new Dictionary<string, dynamic>();
        [DisplayName("SKU")]
        public string Sku { get; set; } = "Premium";

        private IDictionary<string, dynamic> GetArmResource()
        {
            Properties.Clear();
            Properties["sku"] = new Dictionary<string, string>()
            {
                {"tier", Sku }
            };
            return new Dictionary<string, dynamic>()
            {
                {"type", ResourceType },
                {"apiVersion", ApiVersion },
                {"name", Name},
                {"location", Location},
                {"properties", Properties },
            };
        }

        public IList<IDictionary<string, dynamic>> GetArmResources()
        {
            return new List<IDictionary<string, dynamic>>()
            {
                GetArmResource(),
            };
        }

        public IDictionary<string, dynamic> GetArmParameters()
        {
            return new Dictionary<string, dynamic>();
        }
    }
}
