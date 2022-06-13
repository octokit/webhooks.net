namespace Octokit.Webhooks.Models.DiscussionCommentEvent;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record Changes
{
    [JsonPropertyName("body")]
    public Changes? Body { get; init; }
}