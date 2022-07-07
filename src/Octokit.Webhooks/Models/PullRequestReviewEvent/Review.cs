namespace Octokit.Webhooks.Models.PullRequestReviewEvent;

using System;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;

[PublicAPI]
public sealed record Review
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public string NodeId { get; init; } = null!;

    [JsonPropertyName("user")]
    public User User { get; init; } = null!;

    [JsonPropertyName("body")]
    public string? Body { get; init; }

    [JsonPropertyName("commit_id")]
    public string CommitId { get; init; } = null!;

    [JsonPropertyName("submitted_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset SubmittedAt { get; init; }

    [JsonPropertyName("state")]
    public ReviewState? State { get; init; }

    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; init; } = null!;

    [JsonPropertyName("pull_request_url")]
    public string PullRequestUrl { get; init; } = null!;

    [JsonPropertyName("author_association")]
    public AuthorAssociation AuthorAssociation { get; init; }

    [JsonPropertyName("_links")]
    public ReviewLinks Links { get; init; } = null!;
}
