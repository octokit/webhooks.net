namespace Octokit.Webhooks.Converter;

using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;

[PublicAPI]
public class WebhookConverter<T> : JsonConverter<T>
    where T : WebhookEvent
{
    private static readonly ConcurrentDictionary<Type, Dictionary<string, Type>> TypeCache = new();
    private readonly Dictionary<string, Type> types;

    public WebhookConverter()
    {
        var type = typeof(T);
        this.types = TypeCache.GetOrAdd(type, static t =>
            t.Assembly.GetTypes()
                .Where(x => t.IsAssignableFrom(x) && x is { IsClass: true, IsAbstract: false } &&
                            x.GetCustomAttribute<WebhookActionTypeAttribute>() is not null)
                .ToDictionary(
                    y => y.GetCustomAttribute<WebhookActionTypeAttribute>()!.ActionType,
                    y => y));
    }

    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException($"Expected JSON object but found {reader.TokenType}");
        }

        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        if (!jsonDocument.RootElement.TryGetProperty("action", out var action))
        {
            throw new JsonException("Webhook payload is missing required 'action' property");
        }

        Type? type = null;
        var actionValue = action.GetString();

        if (actionValue is not null && this.types.TryGetValue(actionValue, out var payloadType))
        {
            type = payloadType;
        }

        // Special case: repository_dispatch events can have custom user-defined action values
        if (type == null && typeToConvert == typeof(Events.RepositoryDispatchEvent))
        {
            if (string.IsNullOrEmpty(actionValue))
            {
                throw new JsonException("Repository dispatch event is missing action value");
            }

            type = typeof(Events.RepositoryDispatch.RepositoryDispatchCustomEvent);
        }

        if (type is null)
        {
            var availableActions = string.Join(", ", this.types.Keys.OrderBy(k => k));
            throw new JsonException($"Unknown action '{actionValue}' for webhook event type '{typeof(T).Name}'. Available actions: {availableActions}");
        }

        var jsonObject = jsonDocument.RootElement.GetRawText();
        return (T)JsonSerializer.Deserialize(jsonObject, type, options)!;
    }

    public override bool CanConvert(Type typeToConvert) => typeof(WebhookEvent).IsAssignableFrom(typeToConvert);

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
