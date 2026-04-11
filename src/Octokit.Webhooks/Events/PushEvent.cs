namespace Octokit.Webhooks.Events;

using Octokit.Webhooks.Models.PushEvent;

[PublicAPI]
[WebhookEventType(WebhookEventType.Push)]
public sealed record PushEvent : WebhookEvent
{
    [JsonPropertyName("ref")]
    public required string Ref { get; init; }

    [JsonPropertyName("before")]
    public required string Before { get; init; }

    [JsonPropertyName("after")]
    public required string After { get; init; }

    [JsonPropertyName("created")]
    public bool Created { get; init; }

    [JsonPropertyName("deleted")]
    public bool Deleted { get; init; }

    [JsonPropertyName("forced")]
    public bool Forced { get; init; }

    [JsonPropertyName("base_ref")]
    public string? BaseRef { get; init; }

    [JsonPropertyName("compare")]
    public required string Compare { get; init; }

    [JsonPropertyName("commits")]
    public required IReadOnlyList<Commit> Commits { get; init; }

    [JsonPropertyName("head_commit")]
    public Commit? HeadCommit { get; init; }

    [JsonPropertyName("pusher")]
    public required Committer Pusher { get; init; }
}
