namespace Octokit.Webhooks.Converter;

using System.Collections.Frozen;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization.Metadata;

[PublicAPI]
public sealed class WebhookConverter<T> : JsonConverter<T>
    where T : WebhookEvent
{
    private static readonly FrozenDictionary<string, Type> Types = BuildTypeMap();

    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        var actionValue = PeekAction(reader);

        Type? type = null;

        if (actionValue is not null && Types.TryGetValue(actionValue, out var payloadType))
        {
            type = payloadType;
        }

        // repository_dispatch events can have custom user-defined actions values
        if (type == null && typeToConvert == typeof(Events.RepositoryDispatchEvent))
        {
            type = typeof(Events.RepositoryDispatch.RepositoryDispatchCustomEvent);
        }

        if (type is null)
        {
            throw new JsonException();
        }

        var jsonTypeInfo = WebhookConverter.GetTypeInfo(type, options);

        return (T)JsonSerializer.Deserialize(ref reader, jsonTypeInfo)!;
    }

    public override bool CanConvert(Type typeToConvert) => typeof(WebhookEvent).IsAssignableFrom(typeToConvert);

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        var jsonTypeInfo = WebhookConverter.GetTypeInfo(value.GetType(), options);
        JsonSerializer.Serialize(writer, value, jsonTypeInfo);
    }

    private static string? PeekAction(Utf8JsonReader reader)
    {
        // Use a copy of the reader to scan for the "action" property
        // without advancing the original reader past StartObject.
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.PropertyName && reader.ValueTextEquals("action"u8))
            {
                return reader.Read() ? reader.GetString() : null;
            }

            // Skip nested objects/arrays at the root level
            if (reader.TokenType is JsonTokenType.StartObject or JsonTokenType.StartArray)
            {
                reader.Skip();
            }
        }

        throw new JsonException("Missing required 'action' property.");
    }

    private static FrozenDictionary<string, Type> BuildTypeMap() => WebhookConverter.GetActionTypes()
        .Where(x => typeof(T).IsAssignableFrom(x.Type))
        .ToFrozenDictionary(x => x.ActionType, x => x.Type);
}

/// <summary>
/// The non-generic static class for <see cref="WebhookConverter{T}"/>.
/// </summary>
internal static partial class WebhookConverter
{
    private static readonly ConditionalWeakTable<JsonSerializerOptions, JsonSerializerOptions> SerializerOptions = [];

    internal static JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
    {
        var serializerOptions = SerializerOptions.GetValue(options, static key => CreateSerializerOptions(key));
        var typeInfo = serializerOptions.GetTypeInfo(type);

        return !IsWebhookConverter(typeInfo.Converter)
            ? typeInfo
            : throw new JsonException($"Unable to resolve JSON metadata for webhook event type '{type}'.");
    }

    /// <summary>
    /// This method is implemented by the source generator to return a list of all types decorated with the <see cref="WebhookActionTypeAttribute"/>, along with their corresponding action type string.
    /// </summary>
    /// <returns>An enumerable of tuples containing the type and its corresponding action type string.</returns>
    internal static partial IEnumerable<(Type Type, string ActionType)> GetActionTypes();

    private static JsonSerializerOptions CreateSerializerOptions(JsonSerializerOptions options)
    {
        var serializerOptions = new JsonSerializerOptions(options);

        for (var index = serializerOptions.Converters.Count - 1; index >= 0; index--)
        {
            if (IsWebhookConverter(serializerOptions.Converters[index]))
            {
                serializerOptions.Converters.RemoveAt(index);
            }
        }

        var typeInfoResolvers = serializerOptions.TypeInfoResolverChain.ToArray();
        if (typeInfoResolvers.Length == 0 && serializerOptions.TypeInfoResolver is { } typeInfoResolver)
        {
            typeInfoResolvers = [typeInfoResolver];
        }

        serializerOptions.TypeInfoResolverChain.Clear();

        IJsonTypeInfoResolver generatedResolver = WebhookEventJsonSerializerContext.Default;
        foreach (var modifier in typeInfoResolvers
            .OfType<DefaultJsonTypeInfoResolver>()
            .SelectMany(static resolver => resolver.Modifiers))
        {
            generatedResolver = generatedResolver.WithAddedModifier(modifier);
        }

        foreach (var resolver in typeInfoResolvers.Where(static resolver => resolver is not DefaultJsonTypeInfoResolver))
        {
            serializerOptions.TypeInfoResolverChain.Add(new NonRecursiveTypeInfoResolver(resolver));
        }

        serializerOptions.TypeInfoResolverChain.Add(generatedResolver);
        serializerOptions.MakeReadOnly();

        return serializerOptions;
    }

    private static bool IsWebhookConverter(JsonConverter converter)
    {
        var converterType = converter.GetType();
        return converterType.IsGenericType &&
               converterType.GetGenericTypeDefinition() == typeof(WebhookConverter<>);
    }

    private sealed class NonRecursiveTypeInfoResolver(IJsonTypeInfoResolver resolver) : IJsonTypeInfoResolver
    {
        public JsonTypeInfo? GetTypeInfo(Type type, JsonSerializerOptions options)
        {
            var typeInfo = resolver.GetTypeInfo(type, options);

            return typeInfo is not null && IsWebhookConverter(typeInfo.Converter)
                ? null
                : typeInfo;
        }
    }
}
