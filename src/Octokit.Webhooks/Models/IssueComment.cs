namespace Octokit.Webhooks.Models;

using System;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;

[PublicAPI]
public sealed record IssueComment
{
    [JsonPropertyName("url")]
    public string Url { get; init; } = null!;

    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; init; } = null!;

    [JsonPropertyName("issue_url")]
    public string IssueUrl { get; init; } = null!;

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public string NodeId { get; init; } = null!;

    [JsonPropertyName("user")]
    public User User { get; init; } = null!;

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("author_association")]
    public AuthorAssociation AuthorAssociation { get; init; }

    [JsonPropertyName("body")]
    public string Body { get; init; } = null!;

    [JsonPropertyName("reactions")]
    public Reactions? Reactions { get; init; }

    [JsonPropertyName("performed_via_github_app")]
    public App? PerformedViaGithubApp { get; init; }
}
