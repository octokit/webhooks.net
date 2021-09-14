namespace JamieMagee.Octokit.Webhooks.Models.RepositoryEvent
{
    using System.Text.Json.Serialization;

    public record ChangesOwner
    {
        [JsonPropertyName("from")]
        public ChangesOwnerFrom? From { get; init; }
    };
}
