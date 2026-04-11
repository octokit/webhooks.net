namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record DiscussionCategory
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("repository_id")]
    public long RepositoryId { get; init; }

    [JsonPropertyName("emoji")]
    public required string Emoji { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("description")]
    public required string Description { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("slug")]
    public required string Slug { get; init; }

    [JsonPropertyName("is_answerable")]
    public bool IsAnswerable { get; init; }
}
