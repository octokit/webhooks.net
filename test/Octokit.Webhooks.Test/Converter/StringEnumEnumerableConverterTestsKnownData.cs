namespace Octokit.Webhooks.Test.Converter;

using System.Collections.Generic;
using Octokit.Webhooks.Extensions;
using Octokit.Webhooks.Models.PingEvent;
using Xunit;

public class StringEnumEnumerableConverterTestsKnownData : TheoryData<string, IEnumerable<StringEnum<HookType>>>
{
    public StringEnumEnumerableConverterTestsKnownData() => this.Add(@"[""App"", ""Organization""]", new[]
    {
        new StringEnum<HookType>(HookType.App),
        new StringEnum<HookType>(HookType.Organization),
    });
}
