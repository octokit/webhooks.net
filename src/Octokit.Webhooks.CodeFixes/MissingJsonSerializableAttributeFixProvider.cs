namespace Octokit.Webhooks.CodeFixes;

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Octokit.Webhooks.SourceGenerator;

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(MissingJsonSerializableAttributeFixProvider))]
[Shared]
public sealed class MissingJsonSerializableAttributeFixProvider : CodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds
        => [WebhookEventSerializationAnalyzer.DiagnosticId];

    public override FixAllProvider GetFixAllProvider()
        => MissingJsonSerializableAttributeFixAllProvider.Instance;

    public override async Task RegisterCodeFixesAsync(CodeFixContext context)
    {
        var codeAction = await GetCodeActionAsync(context.Document, [context.Diagnostics[0]], context.CancellationToken).ConfigureAwait(false);
        if (codeAction is not null)
        {
            context.RegisterCodeFix(codeAction, context.Diagnostics);
        }
    }

    private static async Task<CodeAction?> GetCodeActionAsync(Document document, ImmutableArray<Diagnostic> diagnostics, CancellationToken cancellationToken)
    {
        if (await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false) is not CompilationUnitSyntax root)
        {
            return null;
        }

        if (root.FindNode(diagnostics.First().Location.SourceSpan) is not TypeDeclarationSyntax typeNode)
        {
            return null;
        }

        var fullNames = new List<string>();
        foreach (var diagnostic in diagnostics)
        {
            if (diagnostic.Properties.TryGetValue("FullName", out var fullName) && fullName is not null)
            {
                fullNames.Add(fullName);
            }
        }

        return CodeAction.Create(
            title: "Add JsonSerializable attribute",
            createChangedDocument: ct => Task.FromResult(ApplyFix(document, root, typeNode, fullNames)),
            equivalenceKey: $"{nameof(MissingJsonSerializableAttributeFixProvider)}_{string.Join(",", fullNames)}");
    }

    private static Document ApplyFix(
        Document document,
        CompilationUnitSyntax root,
        TypeDeclarationSyntax typeNode,
        List<string> fullNames)
    {
        var newAttributeLists = new List<AttributeListSyntax>();
        foreach (var fullName in fullNames)
        {
            var cleanName = fullName.Replace('.', '_').Replace('+', '_').Replace('<', '_').Replace('>', '_').TrimEnd('_');
            var argument1 = SyntaxFactory.AttributeArgument(SyntaxFactory.ParseExpression($"typeof({fullName})"));
            var argument2 = SyntaxFactory.AttributeArgument(SyntaxFactory.ParseExpression($"TypeInfoPropertyName = \"{cleanName}\""));
            var newAttribute = SyntaxFactory.Attribute(SyntaxFactory.ParseName("JsonSerializable")).AddArgumentListArguments(argument1, argument2);
            var newAttributeList = SyntaxFactory.AttributeList(SyntaxFactory.SingletonSeparatedList(newAttribute));
            newAttributeLists.Add(newAttributeList);
        }

        var newTypeNode = typeNode.AddAttributeLists([.. newAttributeLists]);
        root = root.ReplaceNode(typeNode, newTypeNode);

        return document.WithSyntaxRoot(root);
    }

    private sealed class MissingJsonSerializableAttributeFixAllProvider : FixAllProvider
    {
        public static readonly MissingJsonSerializableAttributeFixAllProvider Instance = new();

        public override IEnumerable<FixAllScope> GetSupportedFixAllScopes() => [FixAllScope.Document];

        public override async Task<CodeAction?> GetFixAsync(FixAllContext fixAllContext)
        {
            if (fixAllContext.Scope != FixAllScope.Document || fixAllContext.Document is null)
            {
                return null;
            }

            var diagnostics = await fixAllContext.GetDocumentDiagnosticsAsync(fixAllContext.Document).ConfigureAwait(false);
            return await GetCodeActionAsync(fixAllContext.Document, diagnostics, fixAllContext.CancellationToken).ConfigureAwait(false);
        }
    }
}
