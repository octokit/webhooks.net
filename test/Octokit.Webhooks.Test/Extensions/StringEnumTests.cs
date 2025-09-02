namespace Octokit.Webhooks.Test.Extensions;

using System;
using AwesomeAssertions;
using Octokit.Webhooks.Extensions;
using Octokit.Webhooks.Models.PingEvent;
using Xunit;

public class StringEnumTests
{
    [Theory]
    [InlineData("App")]
    [InlineData("Organization")]
    [InlineData("Repository")]
    [InlineData("Unknown")]
    public void CanConstructFromString(string stringValue)
    {
        var stringEnum = () => new StringEnum<HookType>(stringValue);
        stringEnum.Should().NotThrow();
    }

    [Theory]
    [InlineData(HookType.App)]
    [InlineData(HookType.Organization)]
    [InlineData(HookType.Repository)]
    public void CanConstructFromEnum(HookType enumValue)
    {
        var stringEnum = () => new StringEnum<HookType>(enumValue);
        stringEnum.Should().NotThrow();
    }

    [Theory]
    [InlineData("App")]
    [InlineData("Organization")]
    [InlineData("Repository")]
    [InlineData("Unknown")]
    public void CanGetStringValue(string stringValue)
    {
        var stringEnum = new StringEnum<HookType>(stringValue);
        stringEnum.StringValue.Should().Be(stringValue);
    }

    [Theory]
    [InlineData(HookType.App)]
    [InlineData(HookType.Organization)]
    [InlineData(HookType.Repository)]
    public void CanGetEnumValue(HookType enumValue)
    {
        var stringEnum = new StringEnum<HookType>(enumValue);
        stringEnum.Value.Should().Be(enumValue);
    }

    [Theory]
    [InlineData("Unknown")]
    public void ThrowsForUnknownEnumValue(string stringValue)
    {
        var stringEnum = () => new StringEnum<HookType>(stringValue).Value;
        stringEnum.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData("App", true)]
    [InlineData("Organization", true)]
    [InlineData("Repository", true)]
    [InlineData("Unknown", false)]
    public void CanTryParse(string stringValue, bool expected)
    {
        var actual = new StringEnum<HookType>(stringValue).TryParse(out _);
        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData("App")]
    [InlineData("Organization")]
    [InlineData("Repository")]
    [InlineData("Unknown")]
    public void ShouldEquals(string stringValue)
    {
        var stringEnum = new StringEnum<HookType>(stringValue);
        stringEnum.Should().Be(new StringEnum<HookType>(stringValue));
    }

    [Theory]
    [InlineData("App", HookType.App)]
    [InlineData("Organization", HookType.Organization)]
    [InlineData("Repository", HookType.Repository)]
    public void CanCompareToEnumValue(string stringValue, HookType enumValue)
    {
        var stringEnum = new StringEnum<HookType>(stringValue);
        stringEnum.Should().Be(new StringEnum<HookType>(enumValue));
    }

    [Theory]
    [InlineData("App", HookType.App)]
    [InlineData("Organization", HookType.Organization)]
    [InlineData("Repository", HookType.Repository)]
    public void CanCompareImplicitlyToEnumValue(string stringValue, HookType enumValue)
    {
        var stringEnum = new StringEnum<HookType>(stringValue);
        stringEnum.Equals(enumValue).Should().BeTrue();
    }
}
