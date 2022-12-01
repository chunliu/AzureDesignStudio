using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;

namespace AzureDesignStudio.SourceGeneration;

internal class DtoGeneratorSyntaxReceiver : ISyntaxReceiver
{
    public List<ClassDeclarationSyntax> ModelTypes { get; } = new();
    public string? DtoNamespace { get; set; } = default;
    public string? MapProfileNamespace { get; set; } = default;
    public string? TypeKeyNamespace { get; set; } = default;
    public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
    {
        if (syntaxNode is ClassDeclarationSyntax classSyntax)
        {
            if ("AzureNodeDto".Equals(classSyntax.Identifier.Text, StringComparison.InvariantCulture))
                DtoNamespace = classSyntax.GetNamespace();

            if ("AzureNodeProfile".Equals(classSyntax.Identifier.Text, StringComparison.InvariantCulture))
                MapProfileNamespace = classSyntax.GetNamespace();

            if ("AdsConstants".Equals(classSyntax.Identifier.Text, StringComparison.InvariantCulture))
                TypeKeyNamespace = classSyntax.GetNamespace();

            if (classSyntax.HasAttribute(GeneratorConsts.DtoAttributeName))
                ModelTypes.Add(classSyntax);
        }
    }
}
