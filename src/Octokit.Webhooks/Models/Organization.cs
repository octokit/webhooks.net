namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record Organization
{
    [JsonPropertyName("login")]
    public required string Login { get; init; }

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("html_url")]
    public string? HtmlUrl { get; init; }

    [JsonPropertyName("repos_url")]
    public string? ReposUrl { get; init; }

    [JsonPropertyName("events_url")]
    public string? EventsUrl { get; init; }

    [JsonPropertyName("hooks_url")]
    public string? HooksUrl { get; init; }

    [JsonPropertyName("issues_url")]
    public string? IssuesUrl { get; init; }

    [JsonPropertyName("members_url")]
    public string? MembersUrl { get; init; }

    [JsonPropertyName("public_members_url")]
    public string? PublicMembersUrl { get; init; }

    [JsonPropertyName("avatar_url")]
    public required string AvatarUrl { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }
}
