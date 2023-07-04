namespace Octokit.Webhooks.Converter;

using System.Linq;

[PublicAPI]
public class WebhookConverter<T> : JsonConverter<T>
    where T : WebhookEvent
{
    private readonly IDictionary<string, Type> types;

    public WebhookConverter()
    {
        var type = typeof(T);
        this.types = type.Assembly.GetTypes()
            .Where(x => type.IsAssignableFrom(x) && x is { IsClass: true, IsAbstract: false } &&
                        Attribute.IsDefined(x, typeof(WebhookActionTypeAttribute)))
            .ToDictionary(
                y => ((WebhookActionTypeAttribute)Attribute.GetCustomAttribute(y, typeof(WebhookActionTypeAttribute))!).ActionType,
                y => y);
    }

    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        if (!jsonDocument.RootElement.TryGetProperty(nameof(WebhookEvent.Action).ToLower(CultureInfo.InvariantCulture), out var action))
        {
            throw new JsonException();
        }

        var type = this.types.FirstOrDefault(x => x.Key == action.GetString()).Value ?? throw new JsonException();

        var jsonObject = jsonDocument.RootElement.GetRawText();
        return (T)JsonSerializer.Deserialize(jsonObject, type, options)!;
    }

    public override bool CanConvert(Type typeToConvert) => typeof(WebhookEvent).IsAssignableFrom(typeToConvert);

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
