namespace Octokit.Webhooks.Models.SecurityAdvisoryEvent;

[PublicAPI]
public sealed record SecurityAdvisoryIdentifier
{
    [JsonPropertyName("value")]
    public string Value { get; init; } = null!;

    [JsonPropertyName("type")]
    public string Type { get; init; } = null!;
}
