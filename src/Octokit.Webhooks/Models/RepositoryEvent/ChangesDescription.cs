namespace Octokit.Webhooks.Models.RepositoryEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record ChangesDescription
    {
        [JsonPropertyName("from")]
        public string? From { get; init; }
    };
}
