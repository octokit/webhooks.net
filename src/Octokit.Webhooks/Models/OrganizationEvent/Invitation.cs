namespace Octokit.Webhooks.Models.OrganizationEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record Invitation
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; init; } = null!;

        [JsonPropertyName("login")]
        public string Login { get; init; } = null!;

        [JsonPropertyName("email")]
        public string? Email { get; init; }

        [JsonPropertyName("role")]
        public string Role { get; init; } = null!;

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; init; } = null!;

        [JsonPropertyName("failed_at")]
        public string? FailedAt { get; init; }

        [JsonPropertyName("failed_reason")]
        public string? FailedReason { get; init; }

        [JsonPropertyName("inviter")]
        public User Inviter { get; init; } = null!;

        [JsonPropertyName("team_count")]
        public int TeamCount { get; init; }

        [JsonPropertyName("invitation_teams_url")]
        public string InvitationTeamsUrl { get; init; } = null!;
    }
}
