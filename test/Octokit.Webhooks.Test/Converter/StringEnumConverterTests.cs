namespace Octokit.Webhooks.Test.Converter;

using System.Text.Json;
using AwesomeAssertions;
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
        var result = JsonSerializer.Deserialize<StringEnum<HookType>>(input, this.options)!;
        result.Value.Should().Be(expected);
    }

    [Theory]
    [InlineData(@"""App""", "App")]
    [InlineData(@"""Repository""", "Repository")]
    [InlineData(@"""Organization""", "Organization")]
    [InlineData(@"""Unknown""", "Unknown")]
    public void CanDeserializeUnknown(string input, string expected)
    {
        var result = JsonSerializer.Deserialize<StringEnum<HookType>>(input, this.options)!;
        result.StringValue.Should().Be(expected);
    }

    [Theory]
    [InlineData(@"""\u0041pp""", HookType.App)]
    [InlineData(@"""Repo\u0073itory""", HookType.Repository)]
    public void CanDeserializeKnownWithEscapedCharacters(string input, HookType expected)
    {
        var result = JsonSerializer.Deserialize<StringEnum<HookType>>(input, this.options)!;
        result.Value.Should().Be(expected);
        result.StringValue.Should().Be(expected.ToString());
        result.Should().Be(new StringEnum<HookType>(expected));
    }

    [Theory]
    [InlineData(@"""Unkn\u006fwn""", "Unknown")]
    [InlineData(@"""""", "")]
    [InlineData(@"""app""", "app")]
    public void CanDeserializeUnknownWithEscapedCharacters(string input, string expected)
    {
        var result = JsonSerializer.Deserialize<StringEnum<HookType>>(input, this.options)!;
        result.StringValue.Should().Be(expected);
        result.TryParse(out _).Should().BeFalse();
    }

    [Theory]
    [InlineData(127)]
    [InlineData(128)]
    [InlineData(129)]
    [InlineData(1000)]
    public void CanDeserializeUnknownOfAnyLength(int length)
    {
        var value = new string('x', length);

        var result = JsonSerializer.Deserialize<StringEnum<HookType>>($"\"{value}\"", this.options)!;

        result.StringValue.Should().Be(value);
        result.TryParse(out _).Should().BeFalse();
    }

#if NET9_0_OR_GREATER
    [Fact]
    public void DeserializeKnownValuesReusesTheSameString()
    {
        var first = JsonSerializer.Deserialize<StringEnum<HookType>>(@"""Repository""", this.options)!;
        var second = JsonSerializer.Deserialize<StringEnum<HookType>>(@"""Repo\u0073itory""", this.options)!;

        first.StringValue.Should().BeSameAs(second.StringValue);
    }
#endif

    [Fact]
    public void DeserializeNullReturnsNull()
    {
        var result = JsonSerializer.Deserialize<StringEnum<HookType>>("null", this.options);
        result.Should().BeNull();
    }
}
