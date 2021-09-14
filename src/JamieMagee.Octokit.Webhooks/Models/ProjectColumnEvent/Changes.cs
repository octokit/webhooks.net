namespace JamieMagee.Octokit.Webhooks.Models.ProjectColumnEvent
{
    using System.Text.Json.Serialization;

    public record Changes
    {
        [JsonPropertyName("name")]
        public ChangesName? Name { get; init; }
    };
}
