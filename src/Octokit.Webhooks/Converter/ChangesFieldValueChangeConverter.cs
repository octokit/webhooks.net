namespace Octokit.Webhooks.Converter;

using System.Diagnostics;
using System.Text.Json.Serialization.Metadata;
using Octokit.Webhooks.Models.ProjectsV2ItemEvent;

[PublicAPI]
public sealed class ChangesFieldValueChangeConverter : JsonConverter<ChangesFieldValueChangeBase>
{
    public override ChangesFieldValueChangeBase? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader)
        {
            case { TokenType: JsonTokenType.StartObject }:
                var changeObject = JsonSerializer.Deserialize(ref reader, GetTypeInfoForChangesFieldValueChange(options));
                return changeObject;
            case { TokenType: JsonTokenType.String }:
                return new ChangesFieldValueScalarChange { StringValue = reader.GetString() };
            case { TokenType: JsonTokenType.Null }:
                return null;
            case { TokenType: JsonTokenType.Number }:
                return new ChangesFieldValueScalarChange { NumericValue = reader.GetDecimal() };
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
                JsonSerializer.Serialize(writer, change, GetTypeInfoForChangesFieldValueChange(options));
                break;
            default:
                writer.WriteNullValue();
                break;
        }
    }

    private static JsonTypeInfo<ChangesFieldValueChange> GetTypeInfoForChangesFieldValueChange(JsonSerializerOptions options)
    {
        Debug.Assert(WebhookEventJsonSerializerContext.Default.GetTypeInfo(typeof(ChangesFieldValueChange)) != null, "The internal event serializer context should have a type info for ChangesFieldValueChange, so that this method can use the cached type info.");
        return options.TryGetTypeInfo(typeof(ChangesFieldValueChange), out var resolved) && resolved is JsonTypeInfo<ChangesFieldValueChange> typeInfo
            ? typeInfo
            : new ChangesFieldValueChangeJsonSerializerContext(new JsonSerializerOptions(options)).ChangesFieldValueChange;
    }
}
