namespace Octokit.Webhooks.Converter;

public class DateTimeOffsetConverter : JsonConverter<DateTimeOffset>
{
    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        ReadInternal(ref reader);

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options) =>
        throw new NotImplementedException($"The {nameof(DateTimeOffsetConverter)} does not support serializing to JSON");

    internal static DateTimeOffset ReadInternal(ref Utf8JsonReader reader) => reader.TokenType switch
    {
        JsonTokenType.String => HandleString(reader),
        JsonTokenType.Number => HandleNumber(reader),
        _ => throw new JsonException($"'{reader.TokenType}' is not an allowed token type for the {nameof(DateTimeOffsetConverter)}"),
    };

    private static DateTimeOffset HandleString(Utf8JsonReader reader)
    {
        var stringValue = reader.GetString();

        if (stringValue == null)
        {
            throw new InvalidOperationException("Cannot parse a String JsonToken with a null value");
        }

        return DateTimeOffset.Parse(stringValue, CultureInfo.InvariantCulture);
    }

    private static DateTimeOffset HandleNumber(Utf8JsonReader reader) => DateTimeOffset.FromUnixTimeSeconds(reader.GetInt32());
}
