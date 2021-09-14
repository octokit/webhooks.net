namespace JamieMagee.Octokit.Webhooks.Models.RepositoryEvent
{
    using System.Text.Json.Serialization;

    public class ChangesRepository
    {
        [JsonPropertyName("name")]
        public ChangesRepositoryName? Name { get; init; } = null!;
    }
}
