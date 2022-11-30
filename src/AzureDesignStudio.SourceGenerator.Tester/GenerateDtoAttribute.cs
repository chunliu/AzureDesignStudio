namespace AzureDesignStudio.SourceGeneration.Tester;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class GenerateDtoAttribute : Attribute
{
}

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class MapToDtoAttribute : Attribute
{

}
