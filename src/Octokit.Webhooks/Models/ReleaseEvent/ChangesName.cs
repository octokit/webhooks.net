namespace Octokit.Webhooks.Models.ReleaseEvent;

[PublicAPI]
public sealed record ChangesName
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
