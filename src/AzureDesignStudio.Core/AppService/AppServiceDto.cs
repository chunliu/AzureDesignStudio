using AzureDesignStudio.Core.DTO;

namespace AzureDesignStudio.Core.AppService
{
    public class AppServicePlanDto : AzureNodeDto
    {
        public string Kind { get; set; } = null!;
        public string SkuName { get; set; } = null!;
        public string SkuTier { get; set; } = null!;
    }

    public class WebAppDto : AzureNodeDto
    {
        // public string Kind { get; set; } = null!;
        public string Publish { get; set; } = null!;
        public string RuntimeStack { get; set; } = null!;
        //public string ServicePlanOS { get; set; } = null!;

    }

    public class FunctionAppDto : WebAppDto
    {
        public string HostingPlan { get; set; } = null!;
    }
}
