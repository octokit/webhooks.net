namespace Octokit.Webhooks.Test.Converter;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using Octokit.Webhooks.Converter;
using Octokit.Webhooks.Events;
using Octokit.Webhooks.Events.BranchProtectionConfiguration;
using Octokit.Webhooks.Events.RepositoryDispatch;
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

    [Fact]
    public void CanUseCallerOptionsWhenDeserializing()
    {
        var options = CreateRepositoryDispatchOptions();
        options.PropertyNameCaseInsensitive = true;

        const string json = """{"action":"custom","BRANCH":"main","CLIENT_PAYLOAD":{}}""";
        var deserialized = JsonSerializer.Deserialize<RepositoryDispatchEvent>(json, options);

        var repositoryDispatchEvent = Assert.IsType<RepositoryDispatchCustomEvent>(deserialized);
        Assert.Equal("main", repositoryDispatchEvent.Branch);
    }

    [Fact]
    public void CanUseCallerOptionsWhenSerializing()
    {
        var options = CreateRepositoryDispatchOptions();
        options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;

        var serialized = JsonSerializer.Serialize<RepositoryDispatchEvent>(CreateRepositoryDispatchEvent(), options);
        using var document = JsonDocument.Parse(serialized);

        Assert.False(document.RootElement.TryGetProperty("repository", out _));
    }

    [Fact]
    public void CanUseCallerConverters()
    {
        var options = CreateRepositoryDispatchOptions();
        options.Converters.Add(new PrefixStringConverter());

        const string json = """{"action":"custom","branch":"main","client_payload":{}}""";
        var deserialized = JsonSerializer.Deserialize<RepositoryDispatchEvent>(json, options);

        var repositoryDispatchEvent = Assert.IsType<RepositoryDispatchCustomEvent>(deserialized);
        Assert.Equal("converted:main", repositoryDispatchEvent.Branch);
    }

    [Fact]
    public void CanUseCallerTypeInfoResolver()
    {
        var resolver = new DefaultJsonTypeInfoResolver();
        resolver.Modifiers.Add(static typeInfo =>
        {
            if (typeInfo.Type == typeof(RepositoryDispatchCustomEvent))
            {
                typeInfo.Properties.Single(x => x.Name == "branch").Name = "custom_branch";
            }
        });

        var options = CreateRepositoryDispatchOptions();
        options.TypeInfoResolver = resolver;

        var serialized = JsonSerializer.Serialize<RepositoryDispatchEvent>(CreateRepositoryDispatchEvent(), options);
        using var document = JsonDocument.Parse(serialized);

        Assert.True(document.RootElement.TryGetProperty("custom_branch", out _));
        Assert.False(document.RootElement.TryGetProperty("branch", out _));
    }

    private static JsonSerializerOptions CreateRepositoryDispatchOptions()
    {
#pragma warning disable CA1869 // Cache and reuse 'JsonSerializerOptions' instances
        var options = new JsonSerializerOptions();
#pragma warning restore CA1869 // Cache and reuse 'JsonSerializerOptions' instances
        options.Converters.Add(new WebhookConverter<RepositoryDispatchEvent>());
        return options;
    }

    private static RepositoryDispatchCustomEvent CreateRepositoryDispatchEvent() => new()
    {
        Action = "custom",
        Branch = "main",
        ClientPayload = JsonSerializer.SerializeToElement(new JsonObject()),
    };

    private sealed class PrefixStringConverter : JsonConverter<string>
    {
        public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            $"converted:{reader.GetString()}";

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options) =>
            writer.WriteStringValue($"converted:{value}");
    }
}
