namespace Octokit.Webhooks.Models.DiscussionCommentEvent;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record DiscussionCommentChangesBody
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
