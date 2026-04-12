namespace Octokit.Webhooks.Converter;

using System.Collections.Frozen;
using System.Linq;
using System.Reflection;

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

        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        if (!jsonDocument.RootElement.TryGetProperty("action", out var action))
        {
            throw new JsonException();
        }

        Type? type = null;

        var actionValue = action.GetString();

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

        return (T)jsonDocument.RootElement.Deserialize(type, options)!;
    }

    public override bool CanConvert(Type typeToConvert) => typeof(WebhookEvent).IsAssignableFrom(typeToConvert);

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);

    private static FrozenDictionary<string, Type> BuildTypeMap()
    {
        var type = typeof(T);
        return type.Assembly.GetTypes()
            .Where(x => type.IsAssignableFrom(x) && x is { IsClass: true, IsAbstract: false } &&
                        x.GetCustomAttribute<WebhookActionTypeAttribute>() is not null)
            .ToFrozenDictionary(
                y => y.GetCustomAttribute<WebhookActionTypeAttribute>()!.ActionType,
                y => y);
    }
}
