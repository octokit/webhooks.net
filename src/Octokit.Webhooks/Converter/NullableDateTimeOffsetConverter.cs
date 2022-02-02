namespace Octokit.Webhooks.Converter
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class NullableDateTimeOffsetConverter : JsonConverter<DateTimeOffset?>
    {
        public override DateTimeOffset? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => reader.TokenType switch
        {
            JsonTokenType.Null => null,
            _ => DateTimeOffsetConverter.ReadInternal(ref reader),
        };

        public override void Write(Utf8JsonWriter writer, DateTimeOffset? value, JsonSerializerOptions options) =>
            throw new NotImplementedException($"The {nameof(NullableDateTimeOffsetConverter)} does not support serializing to JSON");
    }
}
