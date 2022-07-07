namespace Octokit.Webhooks.Models.DiscussionCommentEvent;

using System;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;

[PublicAPI]
public sealed record DiscussionComment
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public string NodeId { get; init; } = null!;

    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; init; } = null!;

    [JsonPropertyName("parent_id")]
    public int? ParentId { get; init; }

    [JsonPropertyName("child_comment_count")]
    public long ChildCommentCount { get; init; }

    [JsonPropertyName("repository_url")]
    public string RepositoryUrl { get; init; } = null!;

    [JsonPropertyName("discussion_id")]
    public long DiscussionId { get; init; }

    [JsonPropertyName("author_association")]
    public AuthorAssociation AuthorAssociation { get; init; }

    [JsonPropertyName("user")]
    public User User { get; init; } = null!;

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("body")]
    public string Body { get; init; } = null!;

    [JsonPropertyName("reactions")]
    public Reactions Reactions { get; init; } = null!;
}
