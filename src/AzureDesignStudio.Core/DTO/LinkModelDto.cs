using Blazor.Diagrams.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDesignStudio.Core.DTO
{
    public class LinkModelDto
    {
        //public string Id { get; set; } = string.Empty;
        public string SourcePortParentId { get; set; } = string.Empty;
        public PortAlignment SourcePortAlignment { get; set; }
        public string TargetPortParentId { get; set; } = string.Empty;
        public PortAlignment TargetPortAlignment { get; set; }
    }
}
