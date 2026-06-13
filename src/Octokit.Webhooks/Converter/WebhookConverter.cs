namespace Octokit.Webhooks.Converter;

using System.Collections.Frozen;
using System.Linq;
using System.Reflection;
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

        var jsonTypeInfo = ((IJsonTypeInfoResolver)WebhookEventJsonSerializerContext.Default).GetTypeInfo(type, options) ?? throw new JsonException();

        return (T)JsonSerializer.Deserialize(ref reader, jsonTypeInfo)!;
    }

    public override bool CanConvert(Type typeToConvert) => typeof(WebhookEvent).IsAssignableFrom(typeToConvert);

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        var jsonTypeInfo = ((IJsonTypeInfoResolver)WebhookEventJsonSerializerContext.Default).GetTypeInfo(value.GetType(), options) ?? throw new JsonException();
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
    /// <summary>
    /// This method is implemented by the source generator to return a list of all types decorated with the <see cref="WebhookActionTypeAttribute"/>, along with their corresponding action type string.
    /// </summary>
    /// <returns>An enumerable of tuples containing the type and its corresponding action type string.</returns>
    internal static partial IEnumerable<(Type Type, string ActionType)> GetActionTypes();
}
