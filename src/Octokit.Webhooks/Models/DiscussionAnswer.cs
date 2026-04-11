namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record DiscussionAnswer
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("html_url")]
    public required string HtmlUrl { get; init; }

    [JsonPropertyName("parent_id")]
    public int? ParentId { get; init; }

    [JsonPropertyName("child_comment_count")]
    public long ChildCommentCount { get; init; }

    [JsonPropertyName("repository_url")]
    public required string RepositoryUrl { get; init; }

    [JsonPropertyName("discussion_id")]
    public long DiscussionId { get; init; }

    [JsonPropertyName("author_association")]
    [JsonConverter(typeof(StringEnumConverter<AuthorAssociation>))]
    public required StringEnum<AuthorAssociation> AuthorAssociation { get; init; }

    [JsonPropertyName("user")]
    public required User User { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("body")]
    public required string Body { get; init; }
}
