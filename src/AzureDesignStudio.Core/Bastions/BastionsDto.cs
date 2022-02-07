using AzureDesignStudio.Core.DTO;

namespace AzureDesignStudio.Core.Bastions
{
    public class BastionsDto : AzureNodeDto
    {
        public string Sku { get; set; } = string.Empty;
        public int ScaleUnits { get; set; }
    }
}
