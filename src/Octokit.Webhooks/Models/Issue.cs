namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record Issue
{
    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("repository_url")]
    public required string RepositoryUrl { get; init; }

    [JsonPropertyName("labels_url")]
    public required string LabelsUrl { get; init; }

    [JsonPropertyName("comments_url")]
    public required string CommentsUrl { get; init; }

    [JsonPropertyName("events_url")]
    public required string EventsUrl { get; init; }

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

    [JsonPropertyName("labels")]
    public IReadOnlyList<Label>? Labels { get; init; }

    [JsonPropertyName("state")]
    [JsonConverter(typeof(StringEnumConverter<IssueState>))]
    public StringEnum<IssueState>? State { get; init; }

    [JsonPropertyName("locked")]
    public bool? Locked { get; init; }

    [JsonPropertyName("assignee")]
    public User? Assignee { get; init; }

    [JsonPropertyName("assignees")]
    public required IReadOnlyList<User> Assignees { get; init; }

    [JsonPropertyName("milestone")]
    public Milestone? Milestone { get; init; }

    [JsonPropertyName("comments")]
    public long Comments { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("closed_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? ClosedAt { get; init; }

    [JsonPropertyName("author_association")]
    [JsonConverter(typeof(StringEnumConverter<AuthorAssociation>))]
    public StringEnum<AuthorAssociation>? AuthorAssociation { get; init; }

    [JsonPropertyName("active_lock_reason")]
    [JsonConverter(typeof(StringEnumConverter<ActiveLockReason>))]
    public StringEnum<ActiveLockReason>? ActiveLockReason { get; init; }

    [JsonPropertyName("performed_via_github_app")]
    public App? PerformedViaGithubApp { get; init; }

    [JsonPropertyName("pull_request")]
    public IssuePullRequest? PullRequest { get; init; }

    [JsonPropertyName("body")]
    public string? Body { get; init; }

    [JsonPropertyName("reactions")]
    public Reactions? Reactions { get; init; }

    [JsonPropertyName("state_reason")]
    public string? StateReason { get; init; }

    [JsonPropertyName("type")]
    public IssueType? Type { get; init; }
}
