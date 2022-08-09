namespace Octokit.Webhooks.Models.ProjectColumnEvent;

[PublicAPI]
public sealed record ChangesName
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
