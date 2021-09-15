namespace JamieMagee.Octokit.Webhooks.Models.ProjectColumnEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record Changes
    {
        [JsonPropertyName("name")]
        public ChangesName? Name { get; init; }
    };
}
