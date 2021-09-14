namespace JamieMagee.Octokit.Webhooks.Models.MemberEvent
{
    using System.Text.Json.Serialization;

    public sealed record Changes
    {
        [JsonPropertyName("permission")]
        public ChangesPermission? Permission { get; init; }

        [JsonPropertyName("old_permission")]
        public ChangesPermission? OldPermission { get; init; }
    };
}
