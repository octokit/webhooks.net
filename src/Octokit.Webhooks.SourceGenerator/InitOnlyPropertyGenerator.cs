namespace Octokit.Webhooks.SourceGenerator;

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

/// <summary>
/// Generates <c>WebhookConverter.ConfigureInitOnlyProperties()</c>, which configures the <c>JsonTypeInfo</c> of
/// the models so that <c>System.Text.Json</c> deserializes them with its default object converter.
/// </summary>
/// <remarks>
/// <para>
/// The <c>System.Text.Json</c> source generator cannot call <see langword="init"/> accessors or set <see langword="required"/>
/// members. Instead, it emits metadata that creates each instance with an object initializer from an <c>object[]</c> of all
/// of the property values, which is deserialized by the same path as a type with a parameterized constructor. That path boxes
/// every value, allocates argument state for each object and is slower than the default object converter.
/// </para>
/// <para>
/// Instead, for each model, this generator emits a factory delegate that creates an instance, and setter delegates that call the
/// <see langword="init"/> accessors via <c>UnsafeAccessor</c>. Assigning these to <c>JsonTypeInfo.CreateObject</c> and
/// <c>JsonPropertyInfo.Set</c> makes <c>System.Text.Json</c> use its default object converter for the type.
/// </para>
/// </remarks>
[Generator]
public sealed class InitOnlyPropertyGenerator : IIncrementalGenerator
{
    private const string JsonIgnoreAttribute = "System.Text.Json.Serialization.JsonIgnoreAttribute";
    private const string JsonIgnoreConditionAlways = "Always";
    private const string JsonPropertyNameAttribute = "System.Text.Json.Serialization.JsonPropertyNameAttribute";

    private static readonly SymbolDisplayFormat TypeFormat = SymbolDisplayFormat.FullyQualifiedFormat
        .WithMiscellaneousOptions(SymbolDisplayFormat.FullyQualifiedFormat.MiscellaneousOptions | SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier);

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var typeProvider = context.SyntaxProvider.CreateSyntaxProvider(
            static (syntaxNode, cancellationToken) => IsCandidate(syntaxNode),
            static (context, cancellationToken) => GetTypeModel(context, cancellationToken))
            .Where(static model => model is not null)
            .Select(static (model, cancellationToken) => model!)
            .Collect()
            .Select(static (models, cancellationToken) => new ImmutableArrayWrapper<TypeModel>([.. models.Distinct().OrderBy(static model => model.FullName, StringComparer.Ordinal)]));

        context.RegisterSourceOutput(typeProvider, ImplementConfigureInitOnlyProperties);
    }

    private static bool IsCandidate(SyntaxNode syntaxNode)
    {
        if (syntaxNode is not (ClassDeclarationSyntax or RecordDeclarationSyntax))
        {
            return false;
        }

        var typeNode = (TypeDeclarationSyntax)syntaxNode;

        return typeNode.TypeParameterList is null &&
            !typeNode.Modifiers.Any(SyntaxKind.AbstractKeyword) &&
            !typeNode.Modifiers.Any(SyntaxKind.StaticKeyword) &&
            typeNode.Modifiers.Any(SyntaxKind.PublicKeyword);
    }

    private static TypeModel? GetTypeModel(GeneratorSyntaxContext context, System.Threading.CancellationToken cancellationToken)
    {
        if (context.SemanticModel.GetDeclaredSymbol(context.Node, cancellationToken) is not INamedTypeSymbol type ||
            type.IsAbstract ||
            type.IsStatic ||
            type.IsGenericType ||
            type.TypeKind != TypeKind.Class ||
            type.DeclaredAccessibility != Accessibility.Public ||
            !type.InstanceConstructors.Any(static constructor => constructor.Parameters.Length == 0 && constructor.DeclaredAccessibility == Accessibility.Public))
        {
            return null;
        }

        // System.Text.Json uses the most derived declaration of a property, so a property hidden
        // or overridden by a derived type is ignored in favor of the derived type's declaration.
        var seen = new HashSet<string>(StringComparer.Ordinal);
        var jsonPropertyNames = new HashSet<string>(StringComparer.Ordinal);
        var properties = ImmutableArray.CreateBuilder<PropertyModel>();
        var requiredProperties = ImmutableArray.CreateBuilder<string>();

        for (var current = type; current is not null && current.SpecialType != SpecialType.System_Object; current = current.BaseType)
        {
            foreach (var property in current.GetMembers().OfType<IPropertySymbol>())
            {
                if (property.IsStatic || property.IsIndexer || property.IsImplicitlyDeclared || !seen.Add(property.Name))
                {
                    continue;
                }

                if (property.IsRequired)
                {
                    requiredProperties.Add(property.Name);
                }

                if (property.DeclaredAccessibility != Accessibility.Public ||
                    property.GetMethod is not { DeclaredAccessibility: Accessibility.Public } ||
                    property.SetMethod is not { IsInitOnly: true, DeclaredAccessibility: Accessibility.Public } ||
                    IsIgnored(property))
                {
                    continue;
                }

                var jsonPropertyName = GetJsonPropertyName(property);

                if (jsonPropertyName is null || !jsonPropertyNames.Add(jsonPropertyName))
                {
                    // Without an explicit and unique name, the JSON property name depends on the naming policy of the
                    // serializer options, so it is not possible to reliably match the property to its JsonPropertyInfo.
                    return null;
                }

                properties.Add(new(
                    property.Name,
                    jsonPropertyName,
                    property.SetMethod.ContainingType.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat),
                    property.Type.ToDisplayString(TypeFormat)));
            }
        }

        if (properties.Count == 0)
        {
            return null;
        }

        return new(
            type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat),
            new(properties.ToImmutable()),
            new(requiredProperties.ToImmutable()));
    }

    private static bool IsIgnored(IPropertySymbol property)
    {
        foreach (var attribute in property.GetAttributes())
        {
            if (attribute.AttributeClass?.ToDisplayString() != JsonIgnoreAttribute)
            {
                continue;
            }

            var condition = attribute.NamedArguments.FirstOrDefault(static argument => argument.Key == "Condition");

            // The default is JsonIgnoreCondition.Always
            return condition.Key is null ||
                (condition.Value.Type is INamedTypeSymbol conditionType &&
                 conditionType.GetMembers().OfType<IFieldSymbol>().FirstOrDefault(field => Equals(field.ConstantValue, condition.Value.Value))?.Name == JsonIgnoreConditionAlways);
        }

        return false;
    }

    private static string? GetJsonPropertyName(IPropertySymbol property)
    {
        foreach (var attribute in property.GetAttributes())
        {
            if (attribute.AttributeClass?.ToDisplayString() == JsonPropertyNameAttribute &&
                attribute.ConstructorArguments.Length == 1 &&
                attribute.ConstructorArguments[0].Value is string name)
            {
                return name;
            }
        }

        return null;
    }

    private static void ImplementConfigureInitOnlyProperties(SourceProductionContext context, ImmutableArrayWrapper<TypeModel> data)
    {
        var sb = new StringBuilder();
        sb.AppendLine("// <auto-generated />");
        sb.AppendLine("#nullable enable");
        sb.AppendLine("namespace Octokit.Webhooks.Converter;");
        sb.AppendLine();
        sb.AppendLine("internal static partial class WebhookConverter");
        sb.AppendLine("{");
        sb.AppendLine("    private static readonly global::System.Collections.Frozen.FrozenDictionary<global::System.Type, global::System.Action<global::System.Text.Json.Serialization.Metadata.JsonTypeInfo>> InitOnlyPropertyConfigurators =");
        sb.AppendLine("        global::System.Collections.Frozen.FrozenDictionary.ToFrozenDictionary(new global::System.Collections.Generic.KeyValuePair<global::System.Type, global::System.Action<global::System.Text.Json.Serialization.Metadata.JsonTypeInfo>>[]");
        sb.AppendLine("        {");

        foreach (var type in data.Array)
        {
            sb.AppendLine($"            new(typeof({type.FullName}), {GetConfiguratorName(type)}),");
        }

        sb.AppendLine("        });");
        sb.AppendLine();
        sb.AppendLine("    internal static partial void ConfigureInitOnlyProperties(global::System.Text.Json.Serialization.Metadata.JsonTypeInfo jsonTypeInfo)");
        sb.AppendLine("    {");
        sb.AppendLine("        if (jsonTypeInfo.Kind == global::System.Text.Json.Serialization.Metadata.JsonTypeInfoKind.Object &&");
        sb.AppendLine("            jsonTypeInfo.CreateObject is null &&");
        sb.AppendLine("            InitOnlyPropertyConfigurators.TryGetValue(jsonTypeInfo.Type, out var configure))");
        sb.AppendLine("        {");
        sb.AppendLine("            configure(jsonTypeInfo);");
        sb.AppendLine("        }");
        sb.AppendLine("    }");

        var accessors = new Dictionary<string, PropertyModel>(StringComparer.Ordinal);

        foreach (var type in data.Array)
        {
            sb.AppendLine();
            sb.AppendLine($"    private static void {GetConfiguratorName(type)}(global::System.Text.Json.Serialization.Metadata.JsonTypeInfo jsonTypeInfo)");
            sb.AppendLine("    {");
            sb.AppendLine("        foreach (var property in jsonTypeInfo.Properties)");
            sb.AppendLine("        {");
            sb.AppendLine("            switch (property.Name)");
            sb.AppendLine("            {");

            foreach (var property in type.Properties.Array)
            {
                var accessor = GetAccessorName(property);
                accessors[accessor] = property;

                sb.AppendLine($"                case {SymbolDisplay.FormatLiteral(property.JsonPropertyName, true)}:");
                sb.AppendLine($"                    property.Set = static (obj, value) => {accessor}(({property.DeclaringTypeName})obj, ({property.TypeName})value!);");
                sb.AppendLine("                    break;");
            }

            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.Append($"        jsonTypeInfo.CreateObject = static () => new {type.FullName}()");

            if (type.RequiredProperties.Array.Length > 0)
            {
                sb.AppendLine();
                sb.AppendLine("        {");

                foreach (var required in type.RequiredProperties.Array)
                {
                    sb.AppendLine($"            {required} = default!,");
                }

                sb.Append("        }");
            }

            sb.AppendLine(";");
            sb.AppendLine("    }");
        }

        foreach (var accessor in accessors.OrderBy(static pair => pair.Key, StringComparer.Ordinal))
        {
            var property = accessor.Value;
            sb.AppendLine();
            sb.AppendLine($"    [global::System.Runtime.CompilerServices.UnsafeAccessor(global::System.Runtime.CompilerServices.UnsafeAccessorKind.Method, Name = \"set_{property.Name}\")]");
            sb.AppendLine($"    private static extern void {accessor.Key}({property.DeclaringTypeName} obj, {property.TypeName} value);");
        }

        sb.AppendLine("}");

        context.AddSource("WebhookConverter.InitOnlyProperties.g.cs", sb.ToString());
    }

    private static string GetConfiguratorName(TypeModel type) => "Configure_" + GetIdentifier(type.FullName);

    private static string GetAccessorName(PropertyModel property) => "Set_" + GetIdentifier(property.DeclaringTypeName) + "_" + property.Name;

    private static string GetIdentifier(string fullName)
    {
        var sb = new StringBuilder(fullName.Length);

        foreach (var c in fullName.StartsWith("global::", StringComparison.Ordinal) ? fullName.Substring("global::".Length) : fullName)
        {
            sb.Append(char.IsLetterOrDigit(c) ? c : '_');
        }

        return sb.ToString();
    }

    private sealed record TypeModel(
        string FullName,
        ImmutableArrayWrapper<PropertyModel> Properties,
        ImmutableArrayWrapper<string> RequiredProperties);

    private sealed record PropertyModel(
        string Name,
        string JsonPropertyName,
        string DeclaringTypeName,
        string TypeName);
}
