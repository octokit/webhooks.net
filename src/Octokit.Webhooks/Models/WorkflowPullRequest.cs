namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record WorkflowPullRequest
{
    [JsonPropertyName("url")]
    public string Url { get; init; } = null!;

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("number")]
    public long Number { get; init; }

    [JsonPropertyName("head")]
    public WorkflowPullRequestHead Head { get; init; } = null!;

    [JsonPropertyName("base")]
    public WorkflowPullRequestBase Base { get; init; } = null!;
}
