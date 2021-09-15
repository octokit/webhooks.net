namespace JamieMagee.Octokit.Webhooks.Models.RepositoryEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record Changes
    {
        [JsonPropertyName("description")]
        public ChangesDescription? Description { get; init; }

        [JsonPropertyName("default_branch")]
        public ChangesDefaultBranch? DefaultBranch { get; init; }

        [JsonPropertyName("homepage")]
        public ChangesHomepage? Homepage { get; init; }

        [JsonPropertyName("repository")]
        public ChangesRepository? Repository { get; init; }

        [JsonPropertyName("owner")]
        public ChangesOwner? Owner { get; init; }
    }
}
