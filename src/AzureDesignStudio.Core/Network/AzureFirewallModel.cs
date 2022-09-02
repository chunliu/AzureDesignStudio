using AutoMapper;
using AzureDesignStudio.AzureResources.Base;
using AzureDesignStudio.AzureResources.Network;
using AzureDesignStudio.Core.DTO;
using AzureDesignStudio.Core.Models;
using Blazor.Diagrams.Core.Models;
using System.ComponentModel;

namespace AzureDesignStudio.Core.Network
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
        private readonly AzureFirewalls _firewall = new();
        protected override ResourceBase ArmResource => _firewall;
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
        public override bool IsValid 
            => Group is SubnetModel subnet && subnet.Children.Count == 1 && subnet.Name.Equals("AzureFirewallSubnet");

        public override AzureNodeDto GetNodeDto(IMapper mapper)
        {
            return mapper.Map<AzureFirewallDto>(this);
        }

        protected override void PopulateArmAttributes()
        {
            base.PopulateArmAttributes();

            if (Group is not SubnetModel s)
                throw new Exception($"Firewall is not associated with a subnet.");

            // Depends on subnet is not enough. Must depend on vnet.
            if (s.Group is not VirtualNetworkModel vnet)
                throw new Exception($"Subnet must be in a vnet.");

            PublicIpModel? publicIp = null;
            foreach (var port in Ports)
            {
                publicIp = port.Links?.FirstOrDefault(l => l.SourcePort?.Parent is PublicIpModel)?.SourcePort?.Parent as PublicIpModel;
                if (publicIp != null)
                    break;
            }
            if (publicIp == null)
                throw new Exception($"Firewall needs a public IP address.");

            _firewall.Properties = new()
            {
                Sku = new()
                {
                    Name = "AZFW_VNet",
                    Tier = Sku
                },
                IpConfigurations = new List<AzureFirewallIPConfiguration> 
                { 
                    new AzureFirewallIPConfiguration
                    {
                        Name = Name + "-ipcfg",
                        Properties = new()
                        {
                            Subnet = new SubResource { Id = s.ResourceId },
                            PublicIPAddress = new SubResource { Id = publicIp.ResourceId },
                        }
                    } 
                },
                FirewallPolicy = new() { Id = FirewallPolicy.ResourceId },
            };
            _firewall.DependsOn = new List<string>
            {
                vnet.ResourceId,
                s.ResourceId,
                publicIp.ResourceId,
                FirewallPolicy.ResourceId,
            };
        }

        public override IList<ResourceBase> GetArmResources()
        {
            var result = base.GetArmResources().ToList();

            result.AddRange(FirewallPolicy.GetArmResources());

            return result;
        }
    }
}
