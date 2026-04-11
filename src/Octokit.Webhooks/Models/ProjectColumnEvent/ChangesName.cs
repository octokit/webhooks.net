namespace Octokit.Webhooks.Models.ProjectColumnEvent;

[PublicAPI]
public sealed record ChangesName
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
