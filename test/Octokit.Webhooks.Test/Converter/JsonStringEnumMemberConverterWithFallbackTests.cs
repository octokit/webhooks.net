namespace Octokit.Webhooks.Test.Converter;

using System;
using System.Globalization;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using Octokit.Webhooks.Models.PingEvent;
using Xunit;

public class JsonStringEnumMemberConverterWithFallbackTests
{
    private readonly JsonSerializerOptions options = new()
    {
        Converters =
        {
            new JsonStringEnumMemberConverterWithFallback(),
        },
    };

    [Theory]
    [InlineData(@"""App""", HookType.App)]
    [InlineData(@"""Organization""", HookType.Organization)]
    [InlineData(@"""Repository""", HookType.Repository)]
    [InlineData(@"""Foo""", HookType.Unknown)]
    public void CanConvertString(string input, HookType expected)
    {
        var actual = JsonSerializer.Deserialize<HookType>(input, this.options);
        actual.Should().Be(expected);
    }

    [Fact]
    public void AllEnumerationsUseJsonStringEnumMemberConverterForJsonConverter()
    {
        var assembly = typeof(WebhookEvent).Assembly;
        var types = assembly.GetTypes().ThatDeriveFrom<Enum>().ThatSatisfy(t => !IgnoreType(t));

        foreach (var type in types)
        {
            type.Should().BeDecoratedWith<JsonConverterAttribute>($"the {type.Name} enumeration must be decorated with [JsonConverter(...)]");

            var converter = type.GetCustomAttribute<JsonConverterAttribute>();
            converter.Should().NotBeNull();
            converter!.ConverterType.Should().Be(typeof(JsonStringEnumMemberConverterWithFallback));
        }
    }

    [Fact]
    public void AllEnumerationsHaveUnknownMemberWithValueOfMinusOne()
    {
        var assembly = typeof(WebhookEvent).Assembly;
        var types = assembly.GetTypes().ThatDeriveFrom<Enum>().ThatSatisfy(t => !IgnoreType(t));

        foreach (var type in types)
        {
            var names = Enum.GetNames(type);
            names.Should().Contain("Unknown", $"the {type.Name} enumeration must contain an Unknown value");

            var enumValue = Enum.Parse(type, "Unknown");
            var intValue = Convert.ToInt32(enumValue, CultureInfo.InvariantCulture);
            intValue.Should().Be(-1, $"the Unknown value of the {type.Name} enumeration must have a value of -1");
        }
    }

    private static bool IgnoreType(Type type) =>

        // This type isn't part of the JSON serialization. It's only used in-process for handling
        // validation errors.
        type.Name == "WebhookValidationError";
}
