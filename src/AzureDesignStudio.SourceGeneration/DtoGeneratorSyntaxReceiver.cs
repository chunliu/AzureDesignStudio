using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;

namespace AzureDesignStudio.SourceGeneration;

internal class DtoGeneratorSyntaxReceiver : ISyntaxReceiver
{
    public List<ClassDeclarationSyntax> ModelTypes { get; } = new();
    public string? DtoNamespace { get; set; } = default;
    public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
    {
        if (syntaxNode is ClassDeclarationSyntax classSyntax)
        {
            if ("AzureNodeDto".Equals(classSyntax.Identifier.Text, StringComparison.InvariantCulture))
            {
                DtoNamespace = classSyntax.GetNamespace();
            }

            if (classSyntax.HasAttribute("GenerateDto"))
                ModelTypes.Add(classSyntax);
        }
    }
}
