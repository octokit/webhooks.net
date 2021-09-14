namespace JamieMagee.Octokit.Webhooks.Models.TeamEvent
{
    using System.Text.Json.Serialization;

    public sealed record ChangesRepositoryPermissions
    {
        [JsonPropertyName("from")]
        public ChangesRepositoryPermissionsFrom From { get; init; }
    }
}
