namespace Octokit.Webhooks.Models.OrganizationEvent;

[PublicAPI]
public sealed record Invitation
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("login")]
    public required string Login { get; init; }

    [JsonPropertyName("email")]
    public string? Email { get; init; }

    [JsonPropertyName("role")]
    public required string Role { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("failed_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? FailedAt { get; init; }

    [JsonPropertyName("failed_reason")]
    public string? FailedReason { get; init; }

    [JsonPropertyName("inviter")]
    public required User Inviter { get; init; }

    [JsonPropertyName("team_count")]
    public long TeamCount { get; init; }

    [JsonPropertyName("invitation_teams_url")]
    public required string InvitationTeamsUrl { get; init; }
}
