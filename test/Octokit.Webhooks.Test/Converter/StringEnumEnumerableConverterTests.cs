namespace Octokit.Webhooks.Test.Converter;

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using AwesomeAssertions;
using Octokit.Webhooks.Converter;
using Octokit.Webhooks.Extensions;
using Octokit.Webhooks.Models.PingEvent;
using Xunit;

public class StringEnumEnumerableConverterTests
{
    private readonly JsonSerializerOptions options = new()
    {
        Converters =
        {
            new StringEnumEnumerableConverter<HookType>(),
        },
    };

    [Theory]
    [ClassData(typeof(StringEnumEnumerableConverterTestsKnownData))]
    public void CanDeserializeKnown(string input, IEnumerable<StringEnum<HookType>> expected)
    {
        var result = JsonSerializer.Deserialize<IEnumerable<StringEnum<HookType>>>(input, this.options);
        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [ClassData(typeof(StringEnumEnumerableConverterTestsUnknownData))]
    public void CanDeserializeUnknown(string input, IEnumerable<StringEnum<HookType>> expected)
    {
        var result = JsonSerializer.Deserialize<IEnumerable<StringEnum<HookType>>>(input, this.options);
        result!.Select(r => r.StringValue).Should().BeEquivalentTo(expected.Select(e => e.StringValue));
    }
}
