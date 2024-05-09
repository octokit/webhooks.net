namespace Octokit.Webhooks.Models.CustomPropertyEvent;

[PublicAPI]
public sealed record CustomPropertyLite
{
    [JsonPropertyName("property_name")]
    public string PropertyName { get; init; } = null!;
}
