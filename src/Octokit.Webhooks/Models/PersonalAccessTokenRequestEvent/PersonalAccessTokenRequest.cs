namespace Octokit.Webhooks.Models.PersonalAccessTokenRequestEvent;

[PublicAPI]
public sealed record PersonalAccessTokenRequest
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("owner")]
    public required User Owner { get; init; }

    [JsonPropertyName("permissions_added")]
    public required AppPermissions PermissionsAdded { get; init; }

    [JsonPropertyName("permissions_upgraded")]
    public required AppPermissions PermissionsUpgraded { get; init; }

    [JsonPropertyName("permissions_result")]
    public required AppPermissions PermissionsResult { get; init; }

    [JsonPropertyName("repository_selection")]
    [JsonConverter(typeof(StringEnumConverter<PersonalAccessTokenRequestRepositorySelection>))]
    public required StringEnum<PersonalAccessTokenRequestRepositorySelection> RepositorySelection { get; init; }

    [JsonPropertyName("repository_count")]
    public long? RepositoryCount { get; init; }

    [JsonPropertyName("repositories")]
    public IReadOnlyList<RepositoryLite>? Repositories { get; init; }

    [JsonPropertyName("created_at")]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("token_expired")]
    public bool TokenExpired { get; init; }

    [JsonPropertyName("token_expires_at")]
    public DateTimeOffset? TokenExpiresAt { get; init; }

    [JsonPropertyName("token_last_used_at")]
    public DateTimeOffset? TokenLastUsedAt { get; init; }
}
