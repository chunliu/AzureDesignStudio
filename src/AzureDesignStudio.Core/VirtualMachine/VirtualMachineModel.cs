using AzureDesignStudio.Core.Models;

namespace AzureDesignStudio.Core.VirtualMachine
{
    public class VirtualMachineModel : AzureNodeBase
    {
        public override string ServiceName => "Virtual Machine";
        public override Type? DataFormType => typeof(VirtualMachineForm);
    }
}
