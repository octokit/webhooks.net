namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record Installation
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("account")]
    public required User Account { get; init; }

    [JsonPropertyName("repository_selection")]
    [JsonConverter(typeof(StringEnumConverter<InstallationRepositorySelection>))]
    public required StringEnum<InstallationRepositorySelection> RepositorySelection { get; init; }

    [JsonPropertyName("access_tokens_url")]
    public required string AccessTokensUrl { get; init; }

    [JsonPropertyName("repositories_url")]
    public required string RepositoriesUrl { get; init; }

    [JsonPropertyName("html_url")]
    public required string HtmlUrl { get; init; }

    [JsonPropertyName("app_id")]
    public long AppId { get; init; }

    [JsonPropertyName("app_slug")]
    public string? AppSlug { get; init; }

    [JsonPropertyName("target_id")]
    public long TargetId { get; init; }

    [JsonPropertyName("target_type")]
    [JsonConverter(typeof(StringEnumConverter<InstallationTargetType>))]
    public required StringEnum<InstallationTargetType> TargetType { get; init; }

    [JsonPropertyName("permissions")]
    public AppPermissions? Permissions { get; init; }

    [JsonPropertyName("events")]
    [JsonConverter(typeof(StringEnumReadOnlyListConverter<AppEvent>))]
    public IReadOnlyList<StringEnum<AppEvent>>? Events { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("single_file_name")]
    public string? SingleFileName { get; init; }

    [JsonPropertyName("has_multiple_single_files")]
    public bool? HasMultipleSingleFiles { get; init; }

    [JsonPropertyName("single_file_paths")]
    public IReadOnlyList<string>? SingleFilePaths { get; init; }

    [JsonPropertyName("suspended_by")]
    public User? SuspendedBy { get; init; }

    [JsonPropertyName("suspended_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? SuspendedAt { get; init; }
}
