namespace JamieMagee.Octokit.Webhooks.Models.RepositoryEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record ChangesRepositoryName
    {
        [JsonPropertyName("from")]
        public string From { get; init; } = null!;
    }
}
