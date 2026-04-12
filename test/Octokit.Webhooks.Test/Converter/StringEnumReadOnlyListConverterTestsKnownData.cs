namespace Octokit.Webhooks.Test.Converter;

using System.Collections.Generic;
using Octokit.Webhooks.Extensions;
using Octokit.Webhooks.Models.PingEvent;
using Xunit;

public class StringEnumReadOnlyListConverterTestsKnownData : TheoryData<string, IReadOnlyList<StringEnum<HookType>>>
{
    public StringEnumReadOnlyListConverterTestsKnownData() => this.Add(@"[""App"", ""Organization""]", [
        new StringEnum<HookType>(HookType.App),
        new StringEnum<HookType>(HookType.Organization),
    ]);
}
