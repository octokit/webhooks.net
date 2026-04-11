namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record TeamParent
{
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("slug")]
    public required string Slug { get; init; }

    [JsonPropertyName("privacy")]
    [JsonConverter(typeof(StringEnumConverter<TeamParentPrivacy>))]
    public required StringEnum<TeamParentPrivacy> Privacy { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("html_url")]
    public required string HtmlUrl { get; init; }

    [JsonPropertyName("members_url")]
    public required string MembersUrl { get; init; }

    [JsonPropertyName("repositories_url")]
    public required string RepositoriesUrl { get; init; }

    [JsonPropertyName("permission")]
    public required string Permission { get; init; }
}
