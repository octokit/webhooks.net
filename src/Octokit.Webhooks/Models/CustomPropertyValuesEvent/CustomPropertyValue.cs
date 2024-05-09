namespace Octokit.Webhooks.Models.CustomPropertyValuesEvent;

[PublicAPI]
public sealed record CustomPropertyValue
{
    [JsonPropertyName("property_name")]
    public string PropertyName { get; init; } = null!;

    [JsonPropertyName("value")]
    public string? Value { get; init; }
}
