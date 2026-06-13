namespace Octokit.Webhooks.Converter;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Octokit.Webhooks.Extensions;

[PublicAPI]
public sealed class StringEnumConverter<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields)] TEnum> : JsonConverter<StringEnum<TEnum>>
    where TEnum : struct, Enum
{
    public override StringEnum<TEnum> Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options) => new(reader.GetString()!);

    public override void Write(Utf8JsonWriter writer, StringEnum<TEnum> value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.StringValue);
}
