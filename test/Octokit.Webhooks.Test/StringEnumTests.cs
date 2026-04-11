namespace Octokit.Webhooks.Test;

using System;
using System.Linq;
using AwesomeAssertions;
using Octokit.Webhooks.Extensions;
using Octokit.Webhooks.Models.PingEvent;
using Xunit;

public class StringEnumTests
{
    [Fact]
    public void NoPropertiesUseBareEnums()
    {
        var assembly = typeof(WebhookEvent).Assembly;
        var types = assembly.GetTypes()
            .Where(type => type is { IsClass: true, IsPublic: true } && type.FullName!.StartsWith(assembly.GetName().Name!, StringComparison.Ordinal))
            .Select(t => t.GetProperties());
        foreach (var properties in types)
        {
            foreach (var property in properties)
            {
                property.PropertyType.IsEnum.Should().BeFalse();
            }
        }
    }

    [Fact]
    public void EqualityOperator_SameEnumValues_ReturnsTrue()
    {
        StringEnum<HookType> a = HookType.App;
        StringEnum<HookType> b = HookType.App;

        (a == b).Should().BeTrue();
        (a != b).Should().BeFalse();
    }

    [Fact]
    public void EqualityOperator_DifferentEnumValues_ReturnsFalse()
    {
        StringEnum<HookType> a = HookType.App;
        StringEnum<HookType> b = HookType.Repository;

        (a == b).Should().BeFalse();
        (a != b).Should().BeTrue();
    }

    [Fact]
    public void EqualityOperator_NullComparisons()
    {
        StringEnum<HookType> a = HookType.App;
        StringEnum<HookType>? b = null;

        (a == b).Should().BeFalse();
        (a != b).Should().BeTrue();
        (b == a).Should().BeFalse();
        (b != a).Should().BeTrue();
    }

    [Fact]
    public void EqualityOperator_SameInstance_ReturnsTrue()
    {
        StringEnum<HookType> a = HookType.App;
#pragma warning disable CS1718 // Comparison made to same variable
        (a == a).Should().BeTrue();
        (a != a).Should().BeFalse();
#pragma warning restore CS1718
    }

    [Fact]
    public void EqualityOperator_UnknownValues()
    {
        StringEnum<HookType> a = "Unknown";
        StringEnum<HookType> b = "Unknown";
        StringEnum<HookType> c = "Other";

        (a == b).Should().BeTrue();
        (a != b).Should().BeFalse();
        (a == c).Should().BeFalse();
        (a != c).Should().BeTrue();
    }

    [Fact]
    public void EqualityOperator_KnownVsUnknown_ReturnsFalse()
    {
        StringEnum<HookType> a = HookType.App;
        StringEnum<HookType> b = "Unknown";

        (a == b).Should().BeFalse();
        (a != b).Should().BeTrue();
    }
}
