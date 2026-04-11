namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record WorkflowPullRequest
{
    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("number")]
    public long Number { get; init; }

    [JsonPropertyName("head")]
    public required WorkflowPullRequestHead Head { get; init; }

    [JsonPropertyName("base")]
    public required WorkflowPullRequestBase Base { get; init; }
}
