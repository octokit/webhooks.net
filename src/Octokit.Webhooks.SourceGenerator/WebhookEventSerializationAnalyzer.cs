namespace Octokit.Webhooks.SourceGenerator;

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class WebhookEventSerializationAnalyzer : DiagnosticAnalyzer
{
    public const string DiagnosticId = "OCTOKIT_INTERNAL_001";
    private static readonly LocalizableString Title = "Missing attribute for serialized type";
    private static readonly LocalizableString MessageFormat = "Serializer class must be marked with [JsonSerializable] for type '{0}'";
    private static readonly LocalizableString Description = "Serializer for WebhookEvent requires that all its derived classes (and their dependencies) are included in the source generation context.";
    [SuppressMessage("MicrosoftCodeAnalysisReleaseTracking", "RS2008:Enable analyzer release tracking", Justification = "The analyzer is internal, so it does not require release tracking.")]
    private static readonly DiagnosticDescriptor Rule = new(DiagnosticId, Title, MessageFormat, "Octokit", DiagnosticSeverity.Error, isEnabledByDefault: true, description: Description, customTags: ["CompilationEnd"]);

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => [Rule];

    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();
        context.RegisterSymbolAction(this.AnalyzeCompilation, SymbolKind.NamedType);
    }

    /// <summary>
    /// Recursively retrieves all types from the given namespace and its nested namespaces.
    /// </summary>
    /// <remarks>
    /// Nested types are intentionally not included in this enumeration, as our types of interest are expected to be top-level types.
    /// </remarks>
    /// <param name="ns">The namespace symbol to retrieve types from.</param>
    /// <returns>An enumerable of all named type symbols within the namespace and its nested namespaces.</returns>
    private static IEnumerable<INamedTypeSymbol> GetAllTypes(INamespaceSymbol ns)
    {
        foreach (var type in ns.GetTypeMembers())
        {
            yield return type;
        }

        foreach (var nestedNs in ns.GetNamespaceMembers())
        {
            foreach (var type in GetAllTypes(nestedNs))
            {
                yield return type;
            }
        }
    }

    private static bool InheritsFrom(INamedTypeSymbol type, INamedTypeSymbol baseType)
    {
        var current = type;
        while (current is not null)
        {
            if (SymbolEqualityComparer.Default.Equals(current, baseType))
            {
                return true;
            }

            current = current.BaseType;
        }

        return false;
    }

    private static bool IsFromSystemNamespace(INamedTypeSymbol type)
    {
        var @namespace = type.ContainingNamespace?.ToDisplayString();
        return @namespace != null && @namespace.StartsWith("System", StringComparison.Ordinal);
    }

    private static void AddTypeToSet(ITypeSymbol type, HashSet<ITypeSymbol> typesNeedingAttributes)
    {
        switch (type)
        {
            case IArrayTypeSymbol arrayType:
            {
                if (typesNeedingAttributes.Add(arrayType))
                {
                    AddTypeToSet(arrayType.ElementType, typesNeedingAttributes);
                }

                break;
            }

            case INamedTypeSymbol namedType:
            {
                if (namedType.Arity is 0)
                {
                    if (!IsFromSystemNamespace(namedType) && typesNeedingAttributes.Add(namedType))
                    {
                        AddInstanceProperties(namedType, typesNeedingAttributes);
                    }
                }
                else if (typesNeedingAttributes.Add(namedType))
                {
                    // Generic types are assumed to be special, like List<>, Dictionary<,>, StringEnum<>, etc.
                    // We don't need to check the generic type itself, but we do need to check its type arguments.
                    foreach (var typeArgument in namedType.TypeArguments)
                    {
                        AddTypeToSet(typeArgument, typesNeedingAttributes);
                    }
                }

                break;
            }

            default:
                break;
        }
    }

    private static void AddInstanceProperties(INamedTypeSymbol declaringType, HashSet<ITypeSymbol> typesNeedingAttributes)
    {
        foreach (var member in declaringType.GetMembers())
        {
            if (member is IPropertySymbol { GetMethod.IsStatic: false } property && !HasJsonIgnoreAttribute(property))
            {
                AddTypeToSet(property.Type, typesNeedingAttributes);
            }
        }
    }

    private static bool HasJsonConverterAttribute(ISymbol symbol)
    {
        foreach (var attribute in symbol.GetAttributes())
        {
            if (attribute.AttributeClass?.Name is "JsonConverterAttribute" && attribute.AttributeClass.ContainingNamespace?.ToDisplayString() == "System.Text.Json.Serialization")
            {
                return true;
            }
        }

        return false;
    }

    private static bool HasJsonIgnoreAttribute(ISymbol symbol)
    {
        foreach (var attribute in symbol.GetAttributes())
        {
            if (attribute.AttributeClass?.Name is "JsonIgnoreAttribute" && attribute.AttributeClass.ContainingNamespace?.ToDisplayString() == "System.Text.Json.Serialization")
            {
                return true;
            }
        }

        return false;
    }

    private void AnalyzeCompilation(SymbolAnalysisContext context)
    {
        var serializerType = (INamedTypeSymbol)context.Symbol;
        if (serializerType.Name != "WebhookEventJsonSerializerContext" || serializerType.ContainingNamespace?.ToDisplayString() != "Octokit.Webhooks")
        {
            return;
        }

        var webhookEventType = context.Compilation.GetTypeByMetadataName("Octokit.Webhooks.WebhookEvent");
        if (webhookEventType is null)
        {
            return;
        }

        var serializedTypes = new HashSet<ITypeSymbol>(SymbolEqualityComparer.Default);
        foreach (var type in GetAllTypes(context.Compilation.GlobalNamespace))
        {
            if (InheritsFrom(type, webhookEventType))
            {
                if (!type.IsAbstract || HasJsonConverterAttribute(type))
                {
                    serializedTypes.Add(type);
                }

                AddInstanceProperties(type, serializedTypes);
            }
        }

        var attributedTypes = new HashSet<ITypeSymbol>(SymbolEqualityComparer.Default);
        foreach (var attribute in serializerType.GetAttributes())
        {
            if (attribute.AttributeClass?.Name is not "JsonSerializableAttribute" || attribute.AttributeClass.ContainingNamespace?.ToDisplayString() is not "System.Text.Json.Serialization")
            {
                continue;
            }

            // The first constructor argument of JsonSerializableAttribute is the type being marked for source generation.
            if (attribute.ConstructorArguments[0].Value is ITypeSymbol markedType)
            {
                attributedTypes.Add(markedType);
            }
        }

        foreach (var serializedType in serializedTypes)
        {
            if (!attributedTypes.Contains(serializedType))
            {
                var fullName = serializedType.ToDisplayString(NullableFlowState.NotNull);
                var properties = new Dictionary<string, string?>
                {
                    { "FullName", fullName },
                };
                var diagnostic = Diagnostic.Create(Rule, serializerType.Locations[0], properties.ToImmutableDictionary(), fullName);
                context.ReportDiagnostic(diagnostic);
            }
        }
    }
}
