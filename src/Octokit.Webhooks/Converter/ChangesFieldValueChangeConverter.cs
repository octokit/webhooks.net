namespace Octokit.Webhooks.Converter;

using Octokit.Webhooks.Models.ProjectsV2ItemEvent;

public class ChangesFieldValueChangeConverter : JsonConverter<ChangesFieldValueChangeBase>
{
    public override ChangesFieldValueChangeBase? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.StartObject:
                var changeObject = JsonSerializer.Deserialize<ChangesFieldValueChange>(ref reader, options);
                return changeObject;
            case JsonTokenType.String:
                return new ChangesFieldValueScalarChange { StringValue = reader.GetString() };
            case JsonTokenType.Null:
                return null;
            case JsonTokenType.Number:
                return new ChangesFieldValueScalarChange { NumericValue = reader.GetDecimal() };
            case JsonTokenType.None:
            case JsonTokenType.True:
            case JsonTokenType.False:
            case JsonTokenType.EndObject:
            case JsonTokenType.StartArray:
            case JsonTokenType.EndArray:
            case JsonTokenType.PropertyName:
            case JsonTokenType.Comment:
            default:
                throw new JsonException($"Invalid JsonTokenType {reader.TokenType}");
        }
    }

    public override void Write(Utf8JsonWriter writer, ChangesFieldValueChangeBase value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case ChangesFieldValueScalarChange { StringValue: not null } scalarChange:
                writer.WriteStringValue(scalarChange.StringValue);
                break;
            case ChangesFieldValueScalarChange { NumericValue: not null } scalarChange:
                writer.WriteNumberValue(scalarChange.NumericValue.Value);
                break;
            case ChangesFieldValueScalarChange:
                writer.WriteNullValue();
                break;
            case ChangesFieldValueChange change:
                JsonSerializer.Serialize(writer, change, options);
                break;
            default:
                writer.WriteNullValue();
                break;
        }
    }
}
