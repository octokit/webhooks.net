namespace Octokit.Webhooks.Test.Converter;

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using AwesomeAssertions;
using Octokit.Webhooks.Converter;
using Octokit.Webhooks.Extensions;
using Octokit.Webhooks.Models.PingEvent;
using Xunit;

public class StringEnumReadOnlyListConverterTests
{
    private readonly JsonSerializerOptions options = new()
    {
        Converters =
        {
            new StringEnumReadOnlyListConverter<HookType>(),
        },
    };

    [Theory]
    [ClassData(typeof(StringEnumReadOnlyListConverterTestsKnownData))]
    public void CanDeserializeKnown(string input, IReadOnlyList<StringEnum<HookType>> expected)
    {
        var result = JsonSerializer.Deserialize<IReadOnlyList<StringEnum<HookType>>>(input, this.options);
        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [ClassData(typeof(StringEnumReadOnlyListConverterTestsUnknownData))]
    public void CanDeserializeUnknown(string input, IReadOnlyList<StringEnum<HookType>> expected)
    {
        var result = JsonSerializer.Deserialize<IReadOnlyList<StringEnum<HookType>>>(input, this.options);
        result!.Select(r => r.StringValue).Should().BeEquivalentTo(expected.Select(e => e.StringValue));
    }

    [Fact]
    public void DeserializeThrowsForNullElement()
    {
        var act = () => JsonSerializer.Deserialize<IReadOnlyList<StringEnum<HookType>>>("[null]", this.options);
        act.Should().Throw<JsonException>();
    }
}
