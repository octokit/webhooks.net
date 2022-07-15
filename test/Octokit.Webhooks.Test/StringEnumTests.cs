namespace Octokit.Webhooks.Test;

using System;
using System.Linq;
using FluentAssertions;
using Xunit;

public class StringEnumTests
{
    [Fact]
    public void NoPropertiesUseBareEnums()
    {
        var assembly = typeof(WebhookEvent).Assembly;
        var types = assembly.GetTypes()
            .Where(type => type.IsClass && type.IsPublic && type.FullName!.StartsWith(assembly.GetName().Name!, StringComparison.Ordinal))
            .Select(t => t.GetProperties());
        foreach (var properties in types)
        {
            foreach (var property in properties)
            {
                property.PropertyType.IsEnum.Should().BeFalse();
            }
        }
    }
}
