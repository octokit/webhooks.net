namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record Team
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public string? NodeId { get; init; }

    [JsonPropertyName("slug")]
    public string? Slug { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("privacy")]
    [JsonConverter(typeof(StringEnumConverter<TeamPrivacy>))]
    public StringEnum<TeamPrivacy>? Privacy { get; init; }

    [JsonPropertyName("url")]
    public string? Url { get; init; }

    [JsonPropertyName("html_url")]
    public string? HtmlUrl { get; init; }

    [JsonPropertyName("members_url")]
    public string? MembersUrl { get; init; }

    [JsonPropertyName("repositories_url")]
    public string? RepositoriesUrl { get; init; }

    [JsonPropertyName("permission")]
    public string? Permission { get; init; }

    [JsonPropertyName("parent")]
    public TeamParent? Parent { get; init; }
}
