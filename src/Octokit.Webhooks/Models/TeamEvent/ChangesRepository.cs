namespace Octokit.Webhooks.Models.TeamEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record ChangesRepository
    {
        [JsonPropertyName("permissions")]
        public ChangesRepositoryPermissions Permissions { get; init; }
    }
}
