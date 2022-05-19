using AzureDesignStudio.Core.DTO;

namespace AzureDesignStudio.Core.Network
{
    public class PublicIpDto : AzureNodeDto
    {
        public string IpVersion { get; set; } = string.Empty;
        public string IpAllocationMethod { get; set; } = string.Empty;
        public string Sku { get; set; } = string.Empty;
        public string Tier { get; set; } = string.Empty;
    }
}
