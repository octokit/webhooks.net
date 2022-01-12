namespace Octokit.Webhooks.Converter
{
    using System;
    using System.Globalization;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class DateTimeStringConverter : JsonConverter<string>
    {
        private const string DateTimeStringFormat = "yyyy-MM-ddTHH:mm:ssK";
        private static readonly DateTime UnixTimestampZero = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => reader.TokenType switch
        {
            JsonTokenType.String => HandleString(reader),
            JsonTokenType.Number => HandleNumber(reader),
            _ => throw new JsonException($"'{reader.TokenType}' isn't an allowed token type for the {nameof(DateTimeStringConverter)}"),
        };

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options) => writer.WriteStringValue(value);

        private static string HandleString(Utf8JsonReader reader)
        {
            var stringValue = reader.GetString();

            if (stringValue == null)
            {
                throw new JsonException("Unable to convert string json token");
            }

            return stringValue;
        }

        private static string HandleNumber(Utf8JsonReader reader)
        {
            var dateTime = UnixTimestampZero.AddSeconds(reader.GetInt32());
            return dateTime.ToString(DateTimeStringFormat, CultureInfo.InvariantCulture);
        }
    }
}
