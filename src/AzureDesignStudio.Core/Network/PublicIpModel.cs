using AutoMapper;
using AzureDesignStudio.AzureResources.Base;
using AzureDesignStudio.AzureResources.Network;
using AzureDesignStudio.Core.Attributes;
using AzureDesignStudio.Core.Common;
using AzureDesignStudio.Core.DTO;
using AzureDesignStudio.Core.Models;
using Blazor.Diagrams.Core.Models;
using System.ComponentModel;

namespace AzureDesignStudio.Core.Network
{
    [MapToDto(TypeKey = AdsConstants.PublicIp)]
    public class PublicIpModel : AzureNodeBase
    {
        public PublicIpModel() : base()
        {
            AddPort(PortAlignment.Left);
            AddPort(PortAlignment.Top);
            AddPort(PortAlignment.Right);
            AddPort(PortAlignment.Bottom);
        }

        public override string ServiceName => "Public IP";
        private readonly PublicIPAddresses _pipAddress = new()
        {
            Sku = new()
            {
                Name = "Standard",
                Tier = "Regional"
            },
            Properties = new()
            {
                PublicIPAddressVersion = "IPv4",
                PublicIPAllocationMethod = "Static",
            },
        };
        protected override ResourceBase ArmResource => _pipAddress;
        public override Type? DataFormType => typeof(PublicIpForm);
        [MapToDto]
        [DisplayName("IP version")]
        public string IpVersion 
        { 
            get => _pipAddress.Properties.PublicIPAddressVersion; 
            set => _pipAddress.Properties.PublicIPAddressVersion = value; 
        }
        [MapToDto]
        [DisplayName("IP assignment")]
        public string IpAllocationMethod 
        { 
            get => _pipAddress.Properties.PublicIPAllocationMethod;
            set => _pipAddress.Properties.PublicIPAllocationMethod = value; 
        }
        [MapToDto]
        [DisplayName("SKU")]
        public string Sku 
        { 
            get => _pipAddress.Sku.Name; 
            set => _pipAddress.Sku.Name = value; 
        }
        [MapToDto]
        [DisplayName("Tier")]
        public string Tier 
        { 
            get => _pipAddress.Sku.Tier; 
            set => _pipAddress.Sku.Tier = value; 
        }
        public override (bool result, string message) IsDrappable(GroupModel overlappedGroup)
        {
            if (overlappedGroup != null)
                return (false, $"Public IP cannot be in {((IAzureNode)overlappedGroup).ServiceName}.");

            return (true, string.Empty);
        }
        public override AzureNodeDto GetNodeDto(IMapper mapper)
        {
            return mapper.Map<PublicIpModelDto>(this);
        }
    }
}
