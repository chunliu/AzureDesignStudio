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
                       .Where(a => (a.Name as IdentifierNameSyntax)!.Identifier.Text == attributeName))
                   .Any();
    }

    public static bool HasAttribute(this PropertyDeclarationSyntax propertySyntax, string attributeName)
    {
        return propertySyntax.AttributeLists.Count > 0 
            && propertySyntax.AttributeLists.SelectMany(al => al.Attributes
            .Where(a => (a.Name as IdentifierNameSyntax)!.Identifier.Text == attributeName))
            .Any();
    }

    public static string GetNamespace(this ClassDeclarationSyntax classSyntax)
    {
        return classSyntax.Ancestors().OfType<BaseNamespaceDeclarationSyntax>()
            .FirstOrDefault()
            .Name
            .ToString();            
    }
}
