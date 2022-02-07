using AutoMapper;
using AzureDesignStudio.Core.DTO;
using AzureDesignStudio.Core.Models;
using Blazor.Diagrams.Core.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AzureDesignStudio.Core.PublicIp
{
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
        public override string ApiVersion => "2021-03-01";
        public override string ResourceType => "Microsoft.Network/publicIPAddresses";
        public override Type? DataFormType => typeof(PublicIpForm);
        [DisplayName("IP version")]
        public string IpVersion { get; set; } = "IPv4";
        [DisplayName("IP assignment")]
        public string IpAllocationMethod { get; set; } = "Static";
        [DisplayName("SKU")]
        public string Sku { get; set; } = "Standard";
        [DisplayName("Tier")]
        public string Tier { get; set; } = "Regional";
        public override (bool result, string message) IsDrappable(GroupModel overlappedGroup)
        {
            if (overlappedGroup != null)
                return (false, $"Public IP cannot be in {((IAzureNode)overlappedGroup).ServiceName}.");

            return (true, string.Empty);
        }
        public override AzureNodeDto GetNodeDto(IMapper mapper)
        {
            return mapper.Map<PublicIpDto>(this);
        }
        public override IList<IDictionary<string, dynamic>> GetArmResources()
        {
            return new List<IDictionary<string, dynamic>>()
            {
                GetArmResource(),
            };
        }
        private IDictionary<string, dynamic> GetArmResource()
        {
            var sku = new Dictionary<string, string>()
            {
                {"name", Sku},
                {"tier", Tier},
            };
            Properties.Clear();
            Properties["publicIPAllocationMethod"] = IpAllocationMethod;
            Properties["publicIPAddressVersion"] = IpVersion;
            return new Dictionary<string, dynamic>()
            {
                {"type", ResourceType },
                {"apiVersion", ApiVersion },
                {"name", Name},
                {"location", Location},
                {"sku", sku},
                {"properties", Properties },
            };
        }
    }
}
