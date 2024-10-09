namespace Octokit.Webhooks.Test.Converter;

using System;
using System.Text.Json;
using FluentAssertions;
using Octokit.Webhooks.Converter;
using Xunit;

public class DateTimeOffsetConverterTests
{
    private readonly JsonSerializerOptions options = new()
    {
        Converters =
        {
            new DateTimeOffsetConverter(),
        },
    };

    private readonly DateTimeOffset expected = new(2019, 05, 15, 15, 20, 40, default);
    private readonly DateTimeOffset expectedY2038 = DateTimeOffset.FromUnixTimeSeconds(int.MaxValue + 1L);

    [Theory]
    [InlineData(@"""2019-05-15T15:20:40Z""")]
    [InlineData(@"""2019-05-15T15:20:40.000+00:00""")]
    public void CanDeserializeString(string input)
    {
        var result = JsonSerializer.Deserialize<DateTimeOffset>(input, this.options);
        result.Should().Be(this.expected);
    }

    [Theory]
    [InlineData(@"""2038-01-19T03:14:08Z""")]
    [InlineData(@"""2038-01-19T03:14:08.000+00:00""")]
    public void CanDeserializeStringY2038(string input)
    {
        var result = JsonSerializer.Deserialize<DateTimeOffset>(input, this.options);
        result.Should().Be(this.expectedY2038);
    }

    [Fact]
    public void CanDeserializeNumber()
    {
        var result = JsonSerializer.Deserialize<DateTimeOffset>("1557933640", this.options);
        result.Should().Be(this.expected);
    }

    [Fact]
    public void CanDeserializeNumberY2038()
    {
        var result = JsonSerializer.Deserialize<DateTimeOffset>("2147483648", this.options);
        result.Should().Be(this.expectedY2038);
    }

    [Fact]
    public void DeserializeThrowsForNull()
    {
        var result = () => JsonSerializer.Deserialize<DateTimeOffset>("null", this.options);
        result.Should().Throw<JsonException>();
    }

    [Fact]
    public void CanSerialize()
    {
        var result = JsonSerializer.Serialize(this.expected, this.options);
        result.Should().Be(@"""2019-05-15T15:20:40.0000000\u002B00:00""");
    }
}
