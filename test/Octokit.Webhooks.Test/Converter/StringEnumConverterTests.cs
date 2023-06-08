namespace Octokit.Webhooks.Test.Converter;

using System.Text.Json;
using FluentAssertions;
using Octokit.Webhooks.Converter;
using Octokit.Webhooks.Extensions;
using Octokit.Webhooks.Models.PingEvent;
using Xunit;

public class StringEnumConverterTests
{
    private readonly JsonSerializerOptions options = new()
    {
        Converters =
        {
            new StringEnumConverter<HookType>(),
        },
    };

    [Theory]
    [InlineData(@"""App""", HookType.App)]
    [InlineData(@"""Repository""", HookType.Repository)]
    [InlineData(@"""Organization""", HookType.Organization)]
    public void CanDeserializeKnown(string input, HookType expected)
    {
        var result = JsonSerializer.Deserialize<StringEnum<HookType>>(input, this.options);
        result!.Value.Should().Be(expected);
    }

    [Theory]
    [InlineData(@"""App""", "App")]
    [InlineData(@"""Repository""", "Repository")]
    [InlineData(@"""Organization""", "Organization")]
    [InlineData(@"""Unknown""", "Unknown")]
    public void CanDeserializeUnknown(string input, string expected)
    {
        var result = JsonSerializer.Deserialize<StringEnum<HookType>>(input, this.options);
        result!.StringValue.Should().Be(expected);
    }
}
