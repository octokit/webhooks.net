namespace Octokit.Webhooks.Models.CustomPropertyValues;

[PublicAPI]
public record CustomPropertyValue
{
    [JsonPropertyName("property_name")]
    public string PropertyName { get; set; } = null!;

    [JsonPropertyName("value")]
    public string? Value { get; set; }
}
