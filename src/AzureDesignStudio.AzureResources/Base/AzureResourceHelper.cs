using System.Reflection;

namespace AzureDesignStudio.AzureResources.Base
{
    public static class AzureResourceHelper
    {
        public static Type GetTypeOfAzureResource(string resourceType, string apiVersion)
        {
            if (string.IsNullOrEmpty(resourceType)) 
            {
                throw new ArgumentNullException(resourceType);
            }
            if (string.IsNullOrEmpty(apiVersion))
            {
                throw new ArgumentNullException(apiVersion);
            }

            var type = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsDefined(typeof(AzureResourceAttribute), false))
                .Where(t =>
                {
                    var a = t.GetCustomAttribute<AzureResourceAttribute>();
                    if (a.ResourceType == resourceType && a.ApiVersion == apiVersion)
                    {
                        return true;
                    }

                    return false;
                })
                .FirstOrDefault();

            return type;
        }

        public static ResourceBase GetAzureResourceInstance(string resourceType, string apiVersion)
        {
            var resType = GetTypeOfAzureResource(resourceType, apiVersion);
            if (resType == null)
            {
                throw new TypeLoadException("Failed to load the Azure Resource type.");
            }

            return Activator.CreateInstance(resType) as ResourceBase;
        }
    }
}
