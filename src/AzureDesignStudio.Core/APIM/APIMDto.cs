using AzureDesignStudio.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDesignStudio.Core.APIM
{
    public class APIMDto : AzureNodeDto
    {
        public string SkuName { get; set; } = null!;
        public int SkuCapacity { get; set; }
        public string PublisherEmail { get; set; } = null!;
        public string PublisherName { get; set; } = null!;
        public string VnetType { get; set; } = null!;
    }
}
