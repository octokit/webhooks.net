namespace Octokit.Webhooks.Converter;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Octokit.Webhooks.Extensions;

public sealed class StringEnumConverter<TEnum> : JsonConverter<StringEnum<TEnum>>
    where TEnum : struct
{
    public override StringEnum<TEnum> Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        var stringValue = reader.GetString() ?? throw new JsonException("Unexpected null value when deserializing StringEnum.");

        return new(stringValue);
    }

    public override void Write(Utf8JsonWriter writer, StringEnum<TEnum> value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value.StringValue, options);
}
