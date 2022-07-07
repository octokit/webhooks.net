namespace Octokit.Webhooks.Models;

using System;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;

[PublicAPI]
public sealed record Discussion
{
    [JsonPropertyName("repository_url")]
    public string RepositoryUrl { get; init; } = null!;

    [JsonPropertyName("category")]
    public DiscussionCategory Category { get; init; } = null!;

    [JsonPropertyName("answer_html_url")]
    public string? AnswerHtmlUrl { get; init; }

    [JsonPropertyName("answer_chosen_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? AnswerChosenAt { get; init; }

    [JsonPropertyName("answer_chosen_by")]
    public User? AnswerChosenBy { get; init; }

    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; init; } = null!;

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public string NodeId { get; init; } = null!;

    [JsonPropertyName("number")]
    public long Number { get; init; }

    [JsonPropertyName("title")]
    public string Title { get; init; } = null!;

    [JsonPropertyName("user")]
    public User User { get; init; } = null!;

    [JsonPropertyName("state")]
    public DiscussionState State { get; init; }

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
    public AuthorAssociation AuthorAssociation { get; init; }

    [JsonPropertyName("active_lock_reason")]
    public string? ActiveLockReason { get; init; }

    [JsonPropertyName("body")]
    public string Body { get; init; } = null!;

    [JsonPropertyName("reactions")]
    public Reactions? Reactions { get; init; }
}
