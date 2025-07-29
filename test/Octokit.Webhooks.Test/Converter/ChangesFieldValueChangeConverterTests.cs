namespace Octokit.Webhooks.Test.Converter;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using AwesomeAssertions;
using Octokit.Webhooks.Models.ProjectsV2ItemEvent;
using Xunit;

public class ChangesFieldValueChangeConverterTests(ITestOutputHelper output)
{
    private readonly JsonSerializerOptions options = new()
    {
        WriteIndented = true,
        Converters =
        {
            new ChangesFieldValueChangeConverter(),
        },
    };

    [Fact]
    public void Roundtrip()
    {
        var test = new TestObject
        {
            AsString = new ChangesFieldValueScalarChange { StringValue = "Hello world" },
            AsNumber = new ChangesFieldValueScalarChange { NumericValue = 3.1415926m },
            AsObject = new ChangesFieldValueChange
            {
                Color = "color",
                Description = "description",
                Id = "12345",
                Name = "Name",
            },
        };

        var serialized = JsonSerializer.Serialize(test, this.options);
        output.WriteLine(serialized);

        var deserialized = JsonSerializer.Deserialize<TestObject>(serialized, this.options);

        deserialized.Should().NotBeNull();
        deserialized.AsString.Should().NotBeNull().And.BeOfType<ChangesFieldValueScalarChange>();
        deserialized.AsNumber.Should().NotBeNull().And.BeOfType<ChangesFieldValueScalarChange>();

        (deserialized.AsString as ChangesFieldValueScalarChange)?.StringValue.Should().Be("Hello world");
        (deserialized.AsString as ChangesFieldValueScalarChange)?.NumericValue.Should().BeNull();

        (deserialized.AsNumber as ChangesFieldValueScalarChange)?.StringValue.Should().BeNull();
        (deserialized.AsNumber as ChangesFieldValueScalarChange)?.NumericValue.Should().Be(3.1415926m);

        deserialized.AsObject.Should().NotBeNull().And.BeOfType<ChangesFieldValueChange>();
        var changeObject = deserialized.AsObject.As<ChangesFieldValueChange>();

        changeObject.Color.Should().Be("color");
        changeObject.Description.Should().Be("description");
        changeObject.Id.Should().Be("12345");
        changeObject.Name.Should().Be("Name");
    }

    internal sealed class TestObject
    {
        [JsonPropertyName("as_string")]
        public ChangesFieldValueChangeBase AsString { get; init; } = null!;

        [JsonPropertyName("as_number")]
        public ChangesFieldValueChangeBase AsNumber { get; init; } = null!;

        [JsonPropertyName("as_object")]
        public ChangesFieldValueChangeBase AsObject { get; init; } = null!;
    }
}
