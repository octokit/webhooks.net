namespace Octokit.Webhooks.Models.ProjectEvent;

[PublicAPI]
public sealed record ChangesName
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
