namespace Octokit.Webhooks.Models.CustomPropertyEvent;

[PublicAPI]
public sealed record CustomPropertyLite
{
    [JsonPropertyName("property_name")]
    public required string PropertyName { get; init; }
}
