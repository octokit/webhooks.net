namespace Octokit.Webhooks.Test.Converter;

using System;
using System.Text.Json;
using FluentAssertions;
using Octokit.Webhooks.Converter;
using Xunit;

public class NullableDateTimeOffsetConverterTests
{
    private readonly JsonSerializerOptions options = new()
    {
        Converters =
        {
            new NullableDateTimeOffsetConverter(),
        },
    };

    private readonly DateTimeOffset? expected = new(2019, 05, 15, 15, 20, 40, default);

    [Theory]
    [InlineData(@"""2019-05-15T15:20:40Z""")]
    [InlineData(@"""2019-05-15T15:20:40.000+00:00""")]
    public void CanConvertString(string input)
    {
        var result = JsonSerializer.Deserialize<DateTimeOffset?>(input, this.options);
        result.Should().Be(this.expected);
    }

    [Fact]
    public void CanConvertNumber()
    {
        var result = JsonSerializer.Deserialize<DateTimeOffset?>(@"1557933640", this.options);
        result.Should().Be(this.expected);
    }

    [Fact]
    public void CanConvertNull()
    {
        var result = JsonSerializer.Deserialize<DateTimeOffset?>(@"null", this.options);
        result.Should().BeNull();
    }

    [Fact]
    public void ThrowsForWrite()
    {
        var result = () => JsonSerializer.Serialize(this.expected, this.options);
        result.Should().Throw<NotImplementedException>();
    }
}
