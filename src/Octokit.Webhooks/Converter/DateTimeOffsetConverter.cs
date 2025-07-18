namespace Octokit.Webhooks.Converter;

public class DateTimeOffsetConverter : JsonConverter<DateTimeOffset>
{
    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        ReadInternal(ref reader);

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options) =>
        WriteInternal(writer, value);

    internal static DateTimeOffset ReadInternal(ref Utf8JsonReader reader) => reader.TokenType switch
    {
        JsonTokenType.String => HandleString(reader),
        JsonTokenType.Number => HandleNumber(reader),
        _ => throw new JsonException($"'{reader.TokenType}' is not an allowed token type for the {nameof(DateTimeOffsetConverter)}"),
    };

    internal static void WriteInternal(Utf8JsonWriter writer, DateTimeOffset value) =>
        writer.WriteStringValue(value.ToString("o"));

    private static DateTimeOffset HandleString(Utf8JsonReader reader)
    {
        var stringValue = reader.GetString() ?? throw new InvalidOperationException("Cannot parse a String JsonToken with a null value");

        var span = stringValue.AsSpan();
        if (!DateTimeOffset.TryParse(span, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
        {
            throw new JsonException($"Unable to parse '{stringValue}' as DateTimeOffset");
        }

        return result;
    }

    private static DateTimeOffset HandleNumber(Utf8JsonReader reader) => DateTimeOffset.FromUnixTimeSeconds(reader.GetInt64());
}
