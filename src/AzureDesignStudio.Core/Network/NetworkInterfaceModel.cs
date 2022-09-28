using AutoMapper;
using AzureDesignStudio.AzureResources.Base;
using AzureDesignStudio.AzureResources.Network;
using AzureDesignStudio.Core.Web;
using AzureDesignStudio.Core.DTO;
using AzureDesignStudio.Core.Models;
using AzureDesignStudio.Core.SQL;
using Blazor.Diagrams.Core.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AzureDesignStudio.Core.Network
{
    public class NetworkInterfaceModel : AzureGroupBase
    {
        public override string ServiceName => "NetworkInterface";
        public NetworkInterfaceModel() : base()
        {
            AddPort(new NetworkInterfacePort(this, PortAlignment.Left));
            AddPort(new NetworkInterfacePort(this, PortAlignment.Top));
            AddPort(new NetworkInterfacePort(this, PortAlignment.Right));
            AddPort(new NetworkInterfacePort(this, PortAlignment.Bottom));
        }
        public override Type? DataFormType => typeof(NetworkInterfaceForm);
        private readonly NetworkInterfaces _nic = new();
        protected override ResourceBase ArmResource => _nic;
        
        public List<NetworkInterfaceIPConfiguration> IPConfigs = new List<NetworkInterfaceIPConfiguration>();
        
        public override IList<ResourceBase> GetArmResources()
        {
            var result = base.GetArmResources().ToList();

            var ports = Ports.Where(p => p.Links.Count > 0).ToList();

            int publicIPCount = 0;
            foreach (var port in ports)
            {
                foreach (var link in port.Links)
                {
                    var node = link.TargetPort?.Parent != this ? link.TargetPort?.Parent : link.SourcePort?.Parent;
                    if (node is PublicIpModel n)
                    {
                        if (publicIPCount >= IPConfigs.Count)
                        {
                            throw new Exception("Only one Public IP can be added to an IP Configuration");
                        }

                        _nic.DependsOn.Add(n.ResourceId);
                        _nic.Properties.IpConfigurations[publicIPCount].Properties.PublicIPAddress = new SubResource();
                        _nic.Properties.IpConfigurations[publicIPCount].Properties.PublicIPAddress.Id = n.ResourceId;
                        publicIPCount++;
                    }
                }
            }

            return result;
        }

        protected override void PopulateArmAttributes()
        {
            base.PopulateArmAttributes();

            if (Group is not SubnetModel subnet)
                throw new Exception($"Network Interface Must be in a subnet");

            _nic.DependsOn = new List<string>()
            {
                subnet.ResourceId,
            };

            _nic.Properties = new()
            {
                IpConfigurations = IPConfigs
            };
        }

        public override (bool result, string message) IsDrappable(GroupModel overlappedGroup)
        {
            if (overlappedGroup is not SubnetModel subnet)
                return (false, "Network interface needs a to be in a subnet.");

            return (true, string.Empty);
        }

        public override AzureNodeDto GetNodeDto(IMapper mapper)
        {
            var nicDto = mapper.Map<NetworkInterfaceDto>(this);

            return nicDto;
        }
    }
}
