using AzureDesignStudio.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDesignStudio.Core.AKS
{
    public class AKSModel : AzureNodeBase
    {
        public override string ServiceName => "AKS";
        public override Type? DataFormType => typeof(AKSForm);
    }
}
