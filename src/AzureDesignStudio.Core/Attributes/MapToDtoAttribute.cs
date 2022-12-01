namespace AzureDesignStudio.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct
        | AttributeTargets.Property | AttributeTargets.Field)]
    internal class MapToDtoAttribute : Attribute
    {
        public string DtoBase = default!;
        public string TypeKey = default!; // Only for class
        public string DtoPropertyType = default!; // Only for property
    }
}
