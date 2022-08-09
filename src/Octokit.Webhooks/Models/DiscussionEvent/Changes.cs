namespace Octokit.Webhooks.Models.DiscussionEvent;

[PublicAPI]
public sealed record Changes
{
    [JsonPropertyName("category")]
    public ChangesCategory? Category { get; init; }

    [JsonPropertyName("title")]
    public ChangesTitle? Title { get; init; }

    [JsonPropertyName("body")]
    public ChangesBody? Body { get; init; }

    [JsonPropertyName("new_discussion")]
    public Discussion? NewDiscussion { get; init; }

    [JsonPropertyName("new_repository")]
    public Repository? NewRepository { get; init; }
}
