using AzureDesignStudio.Core.DTO;

namespace AzureDesignStudio.Core.Network
{
    public class AzureFirewallDto : AzureNodeDto
    {
        public string Sku { get; set; } = string.Empty;
        public FirewallPolicyDto? FirewallPolicy { get; set; }
    }

    public class FirewallPolicyDto : AzureNodeDto
    {
        public string Sku { get; set; } = string.Empty;
    }
}
