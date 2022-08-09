namespace Octokit.Webhooks.Models.OrganizationEvent;

[PublicAPI]
public sealed record Invitation
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public string NodeId { get; init; } = null!;

    [JsonPropertyName("login")]
    public string Login { get; init; } = null!;

    [JsonPropertyName("email")]
    public string? Email { get; init; }

    [JsonPropertyName("role")]
    public string Role { get; init; } = null!;

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("failed_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? FailedAt { get; init; }

    [JsonPropertyName("failed_reason")]
    public string? FailedReason { get; init; }

    [JsonPropertyName("inviter")]
    public User Inviter { get; init; } = null!;

    [JsonPropertyName("team_count")]
    public long TeamCount { get; init; }

    [JsonPropertyName("invitation_teams_url")]
    public string InvitationTeamsUrl { get; init; } = null!;
}
