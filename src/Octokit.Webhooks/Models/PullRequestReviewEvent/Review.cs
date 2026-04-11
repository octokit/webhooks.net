namespace Octokit.Webhooks.Models.PullRequestReviewEvent;

[PublicAPI]
public sealed record Review
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("user")]
    public required User User { get; init; }

    [JsonPropertyName("body")]
    public string? Body { get; init; }

    [JsonPropertyName("commit_id")]
    public required string CommitId { get; init; }

    [JsonPropertyName("submitted_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? SubmittedAt { get; init; }

    [JsonPropertyName("state")]
    [JsonConverter(typeof(StringEnumConverter<ReviewState>))]
    public StringEnum<ReviewState>? State { get; init; }

    [JsonPropertyName("html_url")]
    public required string HtmlUrl { get; init; }

    [JsonPropertyName("pull_request_url")]
    public required string PullRequestUrl { get; init; }

    [JsonPropertyName("author_association")]
    [JsonConverter(typeof(StringEnumConverter<AuthorAssociation>))]
    public required StringEnum<AuthorAssociation> AuthorAssociation { get; init; }

    [JsonPropertyName("_links")]
    public required ReviewLinks Links { get; init; }
}
