using AzureDesignStudio.AzureResources.Base;
using AzureDesignStudio.AzureResources.Compute;
using AzureDesignStudio.Core.Models;
using Blazor.Diagrams.Core.Models;

namespace AzureDesignStudio.Core.Compute
{
    public class VirtualMachineModel : AzureNodeBase
    {
        public VirtualMachineModel()
        {
            AddPort(PortAlignment.Left);
            AddPort(PortAlignment.Top);
            AddPort(PortAlignment.Right);
            AddPort(PortAlignment.Bottom);
        }
        public override string ServiceName => "Virtual Machine";
        public override Type? DataFormType => typeof(VirtualMachineForm);
        private readonly VirtualMachines _vm = new();
        protected override ResourceBase ArmResource => _vm;
    }
}
