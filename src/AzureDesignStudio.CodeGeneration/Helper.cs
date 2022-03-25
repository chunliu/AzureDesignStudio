using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Json.Schema;
using System.Diagnostics;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace AzureDesignStudio.CodeGeneration
{
    public class Helper
    {
        public static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// method to process a JsonSchema object model and create C# classes using the DotNet Roslyn compiler API
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="ns"></param>
        /// <returns>NamespaceDeclarationSyntax</returns>
        public static NamespaceDeclarationSyntax FromSchema(JsonSchema schema, NamespaceDeclarationSyntax ns)
        {
            try
            {
                var resourceDefinitions = schema.ResourceDefinitions;
                var definitions = schema.Definitions;

                if (resourceDefinitions != null)
                {
                    foreach (var resDef in resourceDefinitions)
                    {
                        Debug.WriteLine("Resource Definition: " + resDef.Key);
                        var cd = CreateClass(resDef.Key);

                        foreach (var property in resDef.Value.Properties)
                        {
                            var description = string.Empty;

                            if (property.Value.Description != null)
                            {
                                description = @"// " + property.Value.Description;
                            }

                            if (property.Key == "resources")
                            {
                                continue;
                            }

                            Debug.WriteLine("Name: " + property.Key);

                            if (property.Value.OneOf != null && property.Value.OneOf.Count > 0)
                            {
                                if (property.Value.OneOf.First().Reference != null)
                                {
                                    string jsonDefinitionReference = property.Value.OneOf.First().Reference.Fragment.Split("/").Last();
                                    var propertyDefinition = CreateCustomProperty(property.Key, jsonDefinitionReference, description);
                                    cd = cd.AddMembers(propertyDefinition);

                                    Debug.WriteLine("Type: " + jsonDefinitionReference);
                                }
                                else if (property.Value.OneOf.First().Type is List<Microsoft.Json.Schema.SchemaType>)
                                {
                                    var type1 = property.Value.OneOf.First().Type.First().ToString();
                                    var type2 = String.Empty;

                                    if (property.Value.OneOf.First().Items != null)
                                    {
                                        type1 = property.Value.OneOf.First().Type.First().ToString();
                                        type2 = GetEquivalentType(property.Value.OneOf.First().Items.Schemas.First().Type.First().ToString(), String.Empty);
                                    }
                                    var propertyDefinition = CreateProperty(property.Key, ParseTypeName(GetEquivalentType(type1, type2)), description);
                                    cd = cd.AddMembers(propertyDefinition);

                                    Debug.WriteLine("Type: " + type1);
                                }
                            }
                            else if (property.Value.Enum != null)
                            {
                                var propertyDefinition = CreatePropertyWithInitializer(property.Key, "string", property.Value.Enum.First().ToString(), description);
                                cd = cd.AddMembers(propertyDefinition);
                            }
                            else
                            {
                                var type = property.Value.Type.First().ToString();
                                var propertyDefinition = CreateProperty(property.Key, ParseTypeName(GetEquivalentType(type, String.Empty)), description);
                                cd = cd.AddMembers(propertyDefinition);

                                Debug.WriteLine("Type: " + property.Value.Type.First());
                            }
                        }
                        ns = ns.AddMembers(cd);
                    }
                }

                if (definitions != null)
                {
                    foreach (var def in definitions)
                    {
                        Debug.WriteLine("Definition: " + def.Key);
                        var cd = CreateClass(def.Key);


                        if (def.Value.Properties != null)
                        {
                            foreach (var property in def.Value.Properties)
                            {
                                var description = string.Empty;

                                if (property.Value.Description != null)
                                {
                                    description = @"// " + property.Value.Description;
                                }

                                if (property.Value.OneOf != null && property.Value.OneOf.Count > 0)
                                {
                                    if (property.Value.OneOf.First().Reference != null)
                                    {
                                        string jsonDefinitionReference = property.Value.OneOf.First().Reference.Fragment.Split("/").Last();
                                        var propertyDefinition = CreateCustomProperty(property.Key, jsonDefinitionReference, description);
                                        cd = cd.AddMembers(propertyDefinition);

                                        Debug.WriteLine("Name: " + property.Key + " Type: " + jsonDefinitionReference);
                                    }
                                    else if (property.Value.OneOf.First().Type is List<Microsoft.Json.Schema.SchemaType>)
                                    {
                                        var type2 = String.Empty;
                                        var type = property.Value.OneOf.First().Type.First().ToString();

                                        if (property.Value.OneOf.First().Items != null)
                                        {
                                            if (property.Value.OneOf.First().Items.Schemas.First().Type != null)
                                            {
                                                var type1 = property.Value.OneOf.First().Items.Schemas.First().Type.First().ToString();
                                                type2 = GetEquivalentType(type1, String.Empty);
                                            }
                                            else if (property.Value.OneOf.First().Items.Schemas.First().Reference.Fragment != null)
                                            {
                                                type2 = property.Value.OneOf.First().Items.Schemas.First().Reference.Fragment.Split("/").Last();
                                            }
                                        }

                                        var propertyDefinition = CreateProperty(property.Key, ParseTypeName(GetEquivalentType(type, type2)), description);
                                        cd = cd.AddMembers(propertyDefinition);

                                        Debug.WriteLine("Name: " + property.Key + " Type: " + type);
                                    }
                                }
                                else if (property.Value.Type == null)
                                {
                                    Debug.WriteLine("Type is null for property: " + property.Key);
                                    var propertyDefinition = CreateProperty(property.Key, ParseTypeName(GetEquivalentType("String", String.Empty)), description);
                                }
                                else if (property.Value.Enum != null)
                                {
                                    var p = property.Value.Enum.First();
                                    var propertyDefinition = CreateProperty(property.Key, ParseTypeName(GetEquivalentType("String", String.Empty)), description);
                                }
                                else
                                {
                                    var type = property.Value.Type.First().ToString();
                                    var propertyDefinition = CreateProperty(property.Key, ParseTypeName(GetEquivalentType(type, String.Empty)), description);
                                    cd = cd.AddMembers(propertyDefinition);

                                    Debug.WriteLine("Name: " + property.Key + " Type: " + property.Value.Type.First());
                                }
                            }
                        }
                        else if (def.Value.Description == null)
                        {
                            Debug.WriteLine("Description is null for property: " + def.Key);
                        }
                        else if (def.Value.AnyOf != null)
                        {
                            var enumList = def.Value.AnyOf.Select(p => p.Reference.Fragment.Split("/").Last().ToList());
                            var members = new List<EnumMemberDeclarationSyntax>();

                            foreach (var en in enumList)
                            {
                                EnumMemberDeclarationSyntax member = EnumMemberDeclaration(identifier: Identifier(en.ToString()));
                                members.Add(member);
                            }

                            var enumDeclaration = EnumDeclaration(
                                   identifier: Identifier(def.Key)).WithMembers(
                                   members: SeparatedList<EnumMemberDeclarationSyntax>(members));
                            cd = cd.AddMembers(enumDeclaration);
                        }
                        else
                        {
                            var description = string.Empty;

                            if (def.Value.Description != null)
                            {
                                description = @"// " + def.Value.Description;
                            }

                            var type = def.Value.Description.ToString();
                            var propertyDefinition = CreateProperty(def.Value.Description.ToString(), ParseTypeName(GetEquivalentType("String", String.Empty)), description);
                            cd = cd.AddMembers(propertyDefinition);

                            Debug.WriteLine("Name: " + def.Key + " Type: " + def.Value);
                        }
                        ns = ns.AddMembers(cd);
                    }
                }
                return ns;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }


        /// <summary>
        /// method to generate C# class syntax
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ClassDeclarationSyntax CreateClass(string name) =>
            ClassDeclaration(Identifier(name))
                .AddModifiers(Token(SyntaxKind.PublicKeyword)
        );


        /// <summary>
        /// method to generate C# comment syntax
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public static SyntaxTrivia CreateComment(string description) =>
            SyntaxTrivia(SyntaxKind.SingleLineCommentTrivia, description);

        public static PropertyDeclarationSyntax CreateProperty(string name, TypeSyntax type, string description) =>
            PropertyDeclaration(type, name)
            .WithModifiers(
                        TokenList(
                            Token(
                                TriviaList(
                                    Comment(description)),
                                SyntaxKind.PublicKeyword,
                                TriviaList())))
               // .AddModifiers(Token(SyntaxKind.PublicKeyword))
                .AddAccessorListAccessors(
                    AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                        .WithSemicolonToken(Token(SyntaxKind.SemicolonToken)),
                    AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                    .WithSemicolonToken(Token(SyntaxKind.SemicolonToken)
        ));

        /// <summary>
        /// method to generate alternate C# property syntax
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static PropertyDeclarationSyntax CreatePropertyWithInitializer(string name, string type, string value, string description) =>
            PropertyDeclaration(ParseTypeName(type), name)
            .WithModifiers(
                TokenList(Token(TriviaList(Comment(description)),
                SyntaxKind.PublicKeyword,TriviaList())))
               // .AddModifiers(Token(SyntaxKind.PublicKeyword))
                .AddAccessorListAccessors(
                    AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                        .WithSemicolonToken(Token(SyntaxKind.SemicolonToken)),
                    AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                    .WithSemicolonToken(Token(SyntaxKind.SemicolonToken)))
            .WithInitializer(EqualsValueClause(LiteralExpression(SyntaxKind.StringLiteralExpression, Literal(value))))
            .WithSemicolonToken(Token(SyntaxKind.SemicolonToken)
                );

        /// <summary>
        /// method to generate alternate C# property syntax
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static PropertyDeclarationSyntax CreateCustomProperty(string name, string type, string description) =>
            PropertyDeclaration(ParseTypeName(type), name)
            .WithModifiers(
                        TokenList(
                            Token(
                                TriviaList(
                                    Comment(description)),
                                SyntaxKind.PublicKeyword,
                                TriviaList())))
               // .AddModifiers(Token(SyntaxKind.PublicKeyword))
                .AddAccessorListAccessors(
                    AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                        .WithSemicolonToken(Token(SyntaxKind.SemicolonToken)),
                    AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                    .WithSemicolonToken(Token(SyntaxKind.SemicolonToken)

             ));

        /// <summary>
        /// method to generate C# enum syntax
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static EnumDeclarationSyntax CreateEnum(string name) =>
            EnumDeclaration(name)
            .AddModifiers(Token(SyntaxKind.EnumDeclaration)
        );


        /// <summary>
        /// method to download ARM schema file
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="outputFilePath"></param>
        /// <returns></returns>
        public static async Task DownloadSchema(string uri, string outputFilePath)
        {
            try
            {
                Console.WriteLine("Downloading schema file: " + uri);

                using (HttpResponseMessage response = await client.GetAsync(uri))
                using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
                {
                    using (Stream streamToWriteTo = File.Open(outputFilePath, FileMode.Create))
                    {
                        await streamToReadFrom.CopyToAsync(streamToWriteTo);
                    }

                    response.Content = null;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }


        /// <summary>
        /// method to convert string to equivalent C# syntax string
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetEquivalentType(string type, string name)
        {
            string outputType;

            switch (type)
            {
                case "Array":
                    outputType = ArrayType(IdentifierName(name), SingletonList(ArrayRankSpecifier())).ToString();
                    break;
                case "Boolean":
                    outputType = ParseTypeName("bool").ToString();
                    break;
                case "Integer":
                    outputType = ParseTypeName("int").ToString();
                    break;
                case "Object":
                    outputType = ParseTypeName("object").ToString();
                    break;
                default:
                    outputType = ParseTypeName("string").ToString();
                    break;
            }
            return outputType;
        }
    }
}