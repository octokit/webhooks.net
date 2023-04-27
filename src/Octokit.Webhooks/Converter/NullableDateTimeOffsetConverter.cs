namespace Octokit.Webhooks.Converter;

public class NullableDateTimeOffsetConverter : JsonConverter<DateTimeOffset?>
{
    public override DateTimeOffset? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => reader.TokenType switch
    {
        JsonTokenType.Null => null,
        _ => DateTimeOffsetConverter.ReadInternal(ref reader),
    };

    public override void Write(Utf8JsonWriter writer, DateTimeOffset? value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case null:
                writer.WriteNullValue();
                break;
            default:
                DateTimeOffsetConverter.WriteInternal(writer, (DateTimeOffset)value);
                break;
        }
    }
}
