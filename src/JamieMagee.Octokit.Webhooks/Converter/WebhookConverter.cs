namespace JamieMagee.Octokit.Webhooks.Converter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class WebhookConverter<T> : JsonConverter<T>
        where T : WebhookEvent
    {
        private readonly IEnumerable<Type> types;

        public WebhookConverter()
        {
            var type = typeof(T);
            this.types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract)
                .ToList();
        }

        /// <inheritdoc />
        public override T?
            Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            if (!jsonDocument.RootElement.TryGetProperty(nameof(WebhookEvent.Action), out var typeProperty))
            {
                throw new JsonException();
            }

            var type = this.types.FirstOrDefault(x => x.Name == typeProperty.GetString());
            if (type == null)
            {
                throw new JsonException();
            }

            var jsonObject = jsonDocument.RootElement.GetRawText();
            var result = (T)JsonSerializer.Deserialize(jsonObject, type, options);

            return result;
        }

        public override bool CanConvert(Type typeToConvert) => typeof(T).IsAssignableFrom(typeToConvert);

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) =>
            throw new NotImplementedException();
    }
}
