namespace Octokit.Webhooks.Models.CheckRunEvent;

[PublicAPI]
public sealed record CheckRunPullRequest
{
    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("number")]
    public long Number { get; init; }

    [JsonPropertyName("head")]
    public required CheckRunPullRequestHead Head { get; init; }

    [JsonPropertyName("base")]
    public required CheckRunPullRequestBase Base { get; init; }
}
