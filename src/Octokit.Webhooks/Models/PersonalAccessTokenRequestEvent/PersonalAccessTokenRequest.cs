namespace Octokit.Webhooks.Models.PersonalAccessTokenRequestEvent;

[PublicAPI]
public sealed record PersonalAccessTokenRequest
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("owner")]
    public User Owner { get; init; } = null!;

    [JsonPropertyName("permissions_added")]
    public AppPermissions PermissionsAdded { get; init; } = null!;

    [JsonPropertyName("permissions_upgraded")]
    public AppPermissions PermissionsUpgraded { get; init; } = null!;

    [JsonPropertyName("permissions_result")]
    public AppPermissions PermissionsResult { get; init; } = null!;

    [JsonPropertyName("repository_selection")]
    [JsonConverter(typeof(StringEnumConverter<PersonalAccessTokenRequestRepositorySelection>))]
    public StringEnum<PersonalAccessTokenRequestRepositorySelection> RepositorySelection { get; init; } = null!;

    [JsonPropertyName("repository_count")]
    public long? RepositoryCount { get; init; }

    [JsonPropertyName("repositories")]
    public IEnumerable<RepositoryLite>? Repositories { get; init; }

    [JsonPropertyName("created_at")]
    public string CreatedAt { get; init; } = null!;

    [JsonPropertyName("token_expired")]
    public bool TokenExpired { get; init; }

    [JsonPropertyName("token_expires_at")]
    public string? TokenExpiresAt { get; init; }

    [JsonPropertyName("token_last_used_at")]
    public string? TokenLastUsedAt { get; init; }
}
