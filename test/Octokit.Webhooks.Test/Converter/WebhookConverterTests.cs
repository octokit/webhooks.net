namespace Octokit.Webhooks.Test.Converter;

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using Octokit.Webhooks.Converter;
using Octokit.Webhooks.Events;
using Octokit.Webhooks.Events.BranchProtectionConfiguration;
using Xunit;

public class WebhookConverterTests
{
    [Fact]
    public void CanSerializeAdditionalProperties()
    {
        const string key = "key";
        const string value = "value";
        var original = new BranchProtectionConfigurationEnabledEvent()
        {
            AdditionalProperties = new Dictionary<string, JsonElement>
            {
                { key, JsonSerializer.SerializeToElement(value) },
            },
        };
#pragma warning disable CA1869 // Cache and reuse 'JsonSerializerOptions' instances
        var options = new JsonSerializerOptions
        {
            Converters = { new WebhookConverter<BranchProtectionConfigurationEvent>() },
        };
#pragma warning restore CA1869 // Cache and reuse 'JsonSerializerOptions' instances
        var serializedText = JsonSerializer.Serialize(original, options);
        var deserialized = JsonSerializer.Deserialize<BranchProtectionConfigurationEvent>(serializedText, options);
        Assert.NotNull(deserialized);
        Assert.NotNull(deserialized.AdditionalProperties);
        Assert.Contains(key, deserialized.AdditionalProperties.Keys);
        Assert.Equal(value, deserialized.AdditionalProperties[key].GetString());
    }
}
