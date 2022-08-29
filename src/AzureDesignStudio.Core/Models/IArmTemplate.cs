using AzureDesignStudio.AzureResources.Base;

namespace AzureDesignStudio.Core.Models
{
    public interface IArmTemplate
    {
        DeploymentTemplate Template { get; }
    }
}
