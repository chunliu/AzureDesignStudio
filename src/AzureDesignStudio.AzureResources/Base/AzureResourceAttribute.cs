namespace AzureDesignStudio.AzureResources.Base
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AzureResourceAttribute : Attribute
    {
        public AzureResourceAttribute(string resourceType, string apiVersion)
        {
            ResourceType = resourceType;
            ApiVersion = apiVersion;
        }

        public string ResourceType { get; private set; }
        public string ApiVersion { get; private set; }
    }
}
