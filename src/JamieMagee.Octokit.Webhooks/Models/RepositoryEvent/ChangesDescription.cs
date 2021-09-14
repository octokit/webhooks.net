namespace JamieMagee.Octokit.Webhooks.Models.RepositoryEvent
{
    using System.Text.Json.Serialization;

    public sealed record ChangesDescription
    {
        [JsonPropertyName("from")]
        public string? From { get; init; }
    };
}
