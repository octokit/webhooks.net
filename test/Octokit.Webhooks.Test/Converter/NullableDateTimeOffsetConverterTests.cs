namespace Octokit.Webhooks.Test.Converter;

using System;
using System.Text.Json;
using AwesomeAssertions;
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
    public void CanDeserializeString(string input)
    {
        var result = JsonSerializer.Deserialize<DateTimeOffset?>(input, this.options);
        result.Should().Be(this.expected);
    }

    [Fact]
    public void CanDeserializeNumber()
    {
        var result = JsonSerializer.Deserialize<DateTimeOffset?>(@"1557933640", this.options);
        result.Should().Be(this.expected);
    }

    [Fact]
    public void CanDeserializeNull()
    {
        var result = JsonSerializer.Deserialize<DateTimeOffset?>(@"null", this.options);
        result.Should().BeNull();
    }

    [Fact]
    public void CanSerializeDateTimeOffset()
    {
        var result = JsonSerializer.Serialize(this.expected, this.options);
        result.Should().Be(@"""2019-05-15T15:20:40.0000000\u002B00:00""");
    }

    [Fact]
    public void CanSerializeNull()
    {
        var result = JsonSerializer.Serialize((DateTimeOffset?)null, this.options);
        result.Should().Be(@"null");
    }
}
