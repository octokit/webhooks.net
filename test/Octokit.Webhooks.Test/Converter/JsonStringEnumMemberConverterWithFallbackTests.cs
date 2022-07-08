namespace Octokit.Webhooks.Test.Converter;

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
    [InlineData(@"""Foo""", HookType.Repository)]
    public void CanConvertString(string input, HookType expected)
    {
        var actual = JsonSerializer.Deserialize<HookType>(input, this.options);
        actual.Should().Be(expected);
    }
}
