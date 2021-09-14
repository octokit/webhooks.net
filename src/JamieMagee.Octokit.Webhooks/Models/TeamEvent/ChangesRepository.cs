namespace JamieMagee.Octokit.Webhooks.Models.TeamEvent
{
    using System.Text.Json.Serialization;

    public sealed record ChangesRepository
    {
        [JsonPropertyName("permissions")]
        public ChangesRepositoryPermissions Permissions { get; init; }
    }
}
