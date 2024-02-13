namespace Octokit.Webhooks.Test.Converter;

using System.Collections.Generic;
using Octokit.Webhooks.Extensions;
using Octokit.Webhooks.Models.PingEvent;
using Xunit;

public class StringEnumEnumerableConverterTestsUnknownData : TheoryData<string, IEnumerable<StringEnum<HookType>>>
{
    public StringEnumEnumerableConverterTestsUnknownData() => this.Add(@"[""App"", ""Organization"", ""Unknown""]", [
        new StringEnum<HookType>(HookType.App),
        new StringEnum<HookType>(HookType.Organization),
        new StringEnum<HookType>("Unknown"),
    ]);
}
