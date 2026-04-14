namespace Octokit.Webhooks.Converter;

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Octokit.Webhooks.Extensions;

[PublicAPI]
public sealed class StringEnumReadOnlyListConverter<TEnum> : JsonConverter<IReadOnlyList<StringEnum<TEnum>>>
    where TEnum : struct, Enum
{
    public override IReadOnlyList<StringEnum<TEnum>> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        ReadInternal(ref reader);

    public override void Write(Utf8JsonWriter writer, IReadOnlyList<StringEnum<TEnum>> value, JsonSerializerOptions options) =>
        WriteInternal(writer, value);

    private static List<StringEnum<TEnum>> ReadInternal(ref Utf8JsonReader reader)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
        {
            throw new JsonException($"Expected {JsonTokenType.StartArray} but found {reader.TokenType}.");
        }

        var returnValue = new List<StringEnum<TEnum>>();

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndArray)
            {
                return returnValue;
            }

            if (reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException($"Expected {JsonTokenType.String} but found {reader.TokenType}.");
            }

            var stringValue = reader.GetString()
                ?? throw new JsonException("Unexpected null value in array.");
            returnValue.Add(new StringEnum<TEnum>(stringValue));
        }

        throw new JsonException("Incomplete JSON array.");
    }

    private static void WriteInternal(Utf8JsonWriter writer, IReadOnlyList<StringEnum<TEnum>> value)
    {
        if (value == null)
        {
            throw new JsonException("Unexpected null value.");
        }

        writer.WriteStartArray();

        foreach (var data in value)
        {
            writer.WriteStringValue(data.StringValue);
        }

        writer.WriteEndArray();
    }
}
