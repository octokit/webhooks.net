namespace Octokit.Webhooks.Converter;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public class WebhookConverter<T> : JsonConverter<T>
    where T : WebhookEvent
{
    private readonly IDictionary<string, Type> types;

    public WebhookConverter()
    {
        var type = typeof(T);
        this.types = this.GetType().Assembly.GetTypes()
            .Where(x => type.IsAssignableFrom(x) && x.IsClass && !x.IsAbstract &&
                        Attribute.GetCustomAttribute(x, typeof(WebhookActionTypeAttribute)) is not null)
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

        var type = this.types.FirstOrDefault(x => x.Key == action.GetString()).Value;
        if (type == null)
        {
            throw new JsonException();
        }

        var jsonObject = jsonDocument.RootElement.GetRawText();
        return (T)JsonSerializer.Deserialize(jsonObject, type, options)!;
    }

    public override bool CanConvert(Type typeToConvert) => typeof(WebhookEvent).IsAssignableFrom(typeToConvert);

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, (object)value, options);
}
