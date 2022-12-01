using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace AzureDesignStudio.SourceGeneration;

public static class RoslynExtensions
{
    public static bool HasAttribute(this ClassDeclarationSyntax classSyntax, string attributeName)
    {
        return classSyntax.AttributeLists.Count > 0 &&
               classSyntax.AttributeLists.SelectMany(al => al.Attributes
                       .Where(a => (a.Name as IdentifierNameSyntax)?.Identifier.Text == attributeName))
                   .Any();
    }

    public static AttributeSyntax? GetAttribute(this ClassDeclarationSyntax classSyntax, string attributeName)
    {
        return classSyntax.AttributeLists.SelectMany(al => al.Attributes
                       .Where(a => (a.Name as IdentifierNameSyntax)?.Identifier.Text == attributeName))
            .FirstOrDefault();
    }

    public static string? GetAttributeParameterValue(this ClassDeclarationSyntax classSyntax, 
        string attributeName, string paramName)
    {
        var attributeSyntax = classSyntax.GetAttribute(attributeName);
        var expression = attributeSyntax?.ArgumentList?.Arguments
            .Where(a => a.NameEquals?.Name.Identifier.Text == paramName)
            .FirstOrDefault()?
            .ToString();

        return expression?.Split('=').Last().Replace("\"", string.Empty);
    }

    public static bool HasAttribute(this PropertyDeclarationSyntax propertySyntax, string attributeName)
    {
        return propertySyntax.AttributeLists.Count > 0 
            && propertySyntax.AttributeLists.SelectMany(al => al.Attributes
            .Where(a => (a.Name as IdentifierNameSyntax)?.Identifier.Text == attributeName))
            .Any();
    }

    public static AttributeSyntax? GetAttribute(this PropertyDeclarationSyntax propertySyntax, string attributeName)
    {
        return propertySyntax.AttributeLists.SelectMany(al => al.Attributes
                       .Where(a => (a.Name as IdentifierNameSyntax)?.Identifier.Text == attributeName))
            .FirstOrDefault();
    }

    public static string? GetAttributeParameterValue(this PropertyDeclarationSyntax propertySyntax,
        string attributeName, string paramName)
    {
        var attributeSyntax = propertySyntax.GetAttribute(attributeName);
        var expression = attributeSyntax?.ArgumentList?.Arguments
            .Where(a => a.NameEquals?.Name.Identifier.Text == paramName)
            .FirstOrDefault()?
            .ToString();

        return expression?.Split('=').Last().Replace("\"", string.Empty);
    }

    public static string GetNamespace(this ClassDeclarationSyntax classSyntax)
    {
        return classSyntax.Ancestors().OfType<BaseNamespaceDeclarationSyntax>()
            .FirstOrDefault()
            .Name
            .ToString();            
    }
}
