namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record Discussion
{
    [JsonPropertyName("repository_url")]
    public required string RepositoryUrl { get; init; }

    [JsonPropertyName("category")]
    public required DiscussionCategory Category { get; init; }

    [JsonPropertyName("answer_html_url")]
    public string? AnswerHtmlUrl { get; init; }

    [JsonPropertyName("answer_chosen_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? AnswerChosenAt { get; init; }

    [JsonPropertyName("answer_chosen_by")]
    public User? AnswerChosenBy { get; init; }

    [JsonPropertyName("html_url")]
    public required string HtmlUrl { get; init; }

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("number")]
    public long Number { get; init; }

    [JsonPropertyName("title")]
    public required string Title { get; init; }

    [JsonPropertyName("user")]
    public required User User { get; init; }

    [JsonPropertyName("state")]
    [JsonConverter(typeof(StringEnumConverter<DiscussionState>))]
    public required StringEnum<DiscussionState> State { get; init; }

    [JsonPropertyName("locked")]
    public bool Locked { get; init; }

    [JsonPropertyName("comments")]
    public long Comments { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("author_association")]
    [JsonConverter(typeof(StringEnumConverter<AuthorAssociation>))]
    public required StringEnum<AuthorAssociation> AuthorAssociation { get; init; }

    [JsonPropertyName("active_lock_reason")]
    public string? ActiveLockReason { get; init; }

    [JsonPropertyName("body")]
    public required string Body { get; init; }

    [JsonPropertyName("reactions")]
    public Reactions? Reactions { get; init; }
}
