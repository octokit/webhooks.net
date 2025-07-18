namespace Octokit.Webhooks.Converter;

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Octokit.Webhooks.Extensions;

public sealed class StringEnumEnumerableConverter<TEnum> : JsonConverter<IEnumerable<StringEnum<TEnum>>>
    where TEnum : struct
{
    private static readonly JsonSerializerOptions Options = new()
    {
        Converters = { Activator.CreateInstance<StringEnumConverter<TEnum>>() },
    };

    public override IEnumerable<StringEnum<TEnum>> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        ReadInternal(ref reader);

    public override void Write(Utf8JsonWriter writer, IEnumerable<StringEnum<TEnum>> value, JsonSerializerOptions options) =>
        WriteInternal(writer, value);

    private static List<StringEnum<TEnum>> ReadInternal(ref Utf8JsonReader reader)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            throw new JsonException("Unexpected null value.");
        }

        if (reader.TokenType != JsonTokenType.StartArray)
        {
            throw new JsonException("Expected JSON array.");
        }

        var returnValue = new List<StringEnum<TEnum>>();

        while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
        {
            returnValue.Add(JsonSerializer.Deserialize<StringEnum<TEnum>>(ref reader, Options)!);
        }

        return returnValue;
    }

    private static void WriteInternal(Utf8JsonWriter writer, IEnumerable<StringEnum<TEnum>> value)
    {
        if (value == null)
        {
            throw new JsonException("Unexpected null value.");
        }

        writer.WriteStartArray();

        foreach (var data in value)
        {
            JsonSerializer.Serialize(writer, data, Options);
        }

        writer.WriteEndArray();
    }
}
