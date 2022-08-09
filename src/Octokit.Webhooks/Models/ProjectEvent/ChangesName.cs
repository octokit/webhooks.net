namespace Octokit.Webhooks.Models.ProjectEvent;

[PublicAPI]
public sealed record ChangesName
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
