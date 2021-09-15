namespace JamieMagee.Octokit.Webhooks.Models.ReleaseEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record Changes
    {
        [JsonPropertyName("name")]
        public ChangesName? Name { get; init; }

        [JsonPropertyName("body")]
        public ChangesBody? Body { get; init; }
    };
}
