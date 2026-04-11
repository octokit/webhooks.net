namespace Octokit.Webhooks.Models.ProjectsV2ProjectEvent;

[PublicAPI]
public sealed record ProjectsV2
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public string NodeId { get; init; } = null!;

    [JsonPropertyName("owner")]
    public User Owner { get; init; } = null!;

    [JsonPropertyName("creator")]
    public User Creator { get; init; } = null!;

    [JsonPropertyName("title")]
    public string Title { get; init; } = null!;

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("public")]
    public bool Public { get; init; }

    [JsonPropertyName("closed_at")]
    public DateTimeOffset? ClosedAt { get; init; }

    [JsonPropertyName("created_at")]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("number")]
    public long Number { get; init; }

    [JsonPropertyName("short_description")]
    public string? ShortDescription { get; init; }

    [JsonPropertyName("deleted_at")]
    public DateTimeOffset? DeletedAt { get; init; }

    [JsonPropertyName("deleted_by")]
    public User? DeletedBy { get; init; }
}
