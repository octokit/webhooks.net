namespace JamieMagee.Octokit.Webhooks.Models.ProjectColumnEvent
{
    using System.Text.Json.Serialization;

    public sealed record Changes
    {
        [JsonPropertyName("name")]
        public ChangesName? Name { get; init; }
    };
}
