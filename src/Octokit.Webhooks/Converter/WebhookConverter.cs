namespace Octokit.Webhooks.Converter;

using System.Linq;
using System.Reflection;

[PublicAPI]
public class WebhookConverter<T> : JsonConverter<T>
    where T : WebhookEvent
{
    private readonly Dictionary<string, Type> types;

    public WebhookConverter()
    {
        var type = typeof(T);
        this.types = this.GetType().Assembly.GetTypes()
            .Where(x => type.IsAssignableFrom(x) && x is { IsClass: true, IsAbstract: false } &&
                        x.GetCustomAttribute<WebhookActionTypeAttribute>() is not null)
            .ToDictionary(
                y => y.GetCustomAttribute<WebhookActionTypeAttribute>()!.ActionType,
                y => y);
    }

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

        if (actionValue is not null && this.types.TryGetValue(actionValue, out var payloadType))
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

        var jsonObject = jsonDocument.RootElement.GetRawText();
        return (T)JsonSerializer.Deserialize(jsonObject, type, options)!;
    }

    public override bool CanConvert(Type typeToConvert) => typeof(WebhookEvent).IsAssignableFrom(typeToConvert);

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
