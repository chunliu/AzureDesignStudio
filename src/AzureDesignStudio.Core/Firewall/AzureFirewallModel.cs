using AutoMapper;
using AzureDesignStudio.Core.DTO;
using AzureDesignStudio.Core.Models;
using AzureDesignStudio.Core.PublicIp;
using AzureDesignStudio.Core.VirtualNetwork;
using Blazor.Diagrams.Core.Models;
using System.ComponentModel;

namespace AzureDesignStudio.Core.Firewall
{
    public class AzureFirewallModel : AzureNodeBase
    {
        public AzureFirewallModel() : base()
        {
            AddPort(PortAlignment.Left);
            AddPort(PortAlignment.Top);
            AddPort(PortAlignment.Right);
            AddPort(PortAlignment.Bottom);
        }
        public override string ServiceName => "Azure Firewall";
        public override string ApiVersion => "2021-03-01";
        public override string ResourceType => "Microsoft.Network/azureFirewalls";
        public override Type? DataFormType => typeof(AzureFirewallForm);
        private string sku = "Premium";
        [DisplayName("SKU")]
        public string Sku 
        { 
            get => sku; 
            set
            {
                sku = value;
                if (sku.Equals("Standard"))
                {
                    // Premium policy cannot be assigned to Standard firewall.
                    FirewallPolicy.Sku = sku;
                }
            }
        }
        public FirewallPolicyModel FirewallPolicy { get; set; } = new FirewallPolicyModel();
        public override (bool result, string message) IsDrappable(GroupModel overlappedGroup)
        {
            if (overlappedGroup is not SubnetModel subnet || !subnet.Name.Equals("AzureFirewallSubnet"))
                return (false, "Azure Firewall needs a dedicate subnet: AzureFirewallSubnet.");

            if (subnet.Children.Count > 0)
                return (false, "The subnet is not empty.");

            return (true, string.Empty);
        }

        public override AzureNodeDto GetNodeDto(IMapper mapper)
        {
            return mapper.Map<AzureFirewallDto>(this);
        }

        public override IList<IDictionary<string, dynamic>> GetArmResources()
        {
            if (Group is not SubnetModel s)
                throw new Exception($"Firewall is not associated with a subnet.");

            PublicIpModel? publicIp = null;
            foreach (var port in Ports)
            {
                publicIp = port.Links?.FirstOrDefault(l => l.SourcePort?.Parent is PublicIpModel)?.SourcePort?.Parent as PublicIpModel;
                if (publicIp != null)
                    break;
            }
            if (publicIp == null)
                throw new Exception($"Firewall needs a public IP address.");

            var subnet = new Dictionary<string, string>()
            {
                {"id", s.ResourceId},
            };
            var publicIpAddress = new Dictionary<string, string>()
            {
                {"id", publicIp.ResourceId},
            };

            Dictionary<string, dynamic> ipConfiguration = new()
            {
                { "name", Name + "-ipcfg" },
                {
                    "properties",
                    new Dictionary<string, dynamic>()
                    {
                        { "subnet", subnet },
                        { "publicIPAddress", publicIpAddress },
                    }
                },
            };
            List<Dictionary<string, dynamic>> ipConfigurations = new()
            {
                ipConfiguration,
            };

            var result = new List<IDictionary<string, dynamic>>();
            result.AddRange(FirewallPolicy.GetArmResources());

            // Depends on subnet is not enough. Must depend on vnet.
            if (s.Group is not VirtualNetworkModel vnet)
                throw new Exception($"Subnet must be in a vnet.");
            List<string> dependsOn = new()
            {
                vnet.ResourceId,
                s.ResourceId,
                publicIp.ResourceId,
                FirewallPolicy.ResourceId,
            };

            Properties.Clear();
            Properties["sku"] = new Dictionary<string, string>()
            {
                {"name", "AZFW_VNet" },
                {"tier", Sku },
            };
            Properties["ipConfigurations"] = ipConfigurations;
            Properties["firewallPolicy"] = new Dictionary<string, string>()
            {
                {"id", FirewallPolicy.ResourceId }
            };

            var fwArm = new Dictionary<string, dynamic>()
            {
                {"type", ResourceType },
                {"apiVersion", ApiVersion },
                {"name", Name},
                {"location", Location},
                {"properties", Properties },
                {"dependsOn", dependsOn},
            };

            result.Add(fwArm);

            return result;
        }
    }
}
