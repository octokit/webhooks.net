namespace JamieMagee.Octokit.Webhooks.Models.RepositoryEvent
{
    using System.Text.Json.Serialization;

    public class ChangesHomepage
    {
        [JsonPropertyName("from")]
        public string? From { get; init; }
    }
}
