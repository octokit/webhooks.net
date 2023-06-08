namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record Team
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public string NodeId { get; init; } = null!;

    [JsonPropertyName("slug")]
    public string Slug { get; init; } = null!;

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("privacy")]
    [JsonConverter(typeof(StringEnumConverter<TeamPrivacy>))]
    public StringEnum<TeamPrivacy> Privacy { get; init; } = null!;

    [JsonPropertyName("url")]
    public string Url { get; init; } = null!;

    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; init; } = null!;

    [JsonPropertyName("members_url")]
    public string MembersUrl { get; init; } = null!;

    [JsonPropertyName("repositories_url")]
    public string RepositoriesUrl { get; init; } = null!;

    [JsonPropertyName("permission")]
    public string Permission { get; init; } = null!;

    [JsonPropertyName("parent")]
    public TeamParent? Parent { get; init; }
}
