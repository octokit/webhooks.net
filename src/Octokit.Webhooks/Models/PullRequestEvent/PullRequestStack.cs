namespace Octokit.Webhooks.Models.PullRequestEvent;

[PublicAPI]
public sealed record PullRequestStack
{
    [JsonPropertyName("base")]
    public required PullRequestStackBase Base { get; init; }

    [JsonPropertyName("size")]
    public long Size { get; init; }

    [JsonPropertyName("position")]
    public long Position { get; init; }

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("number")]
    public long Number { get; init; }
}
