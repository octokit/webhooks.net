namespace Octokit.Webhooks.Models.CheckRunEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record CheckRunOutput
    {
        [JsonPropertyName("title")]
        public string? Title { get; init; }

        [JsonPropertyName("summary")]
        public string? Summary { get; init; }

        [JsonPropertyName("text")]
        public string? Text { get; init; }

        [JsonPropertyName("annotations_count")]
        public int AnnotationsCount { get; init; }

        [JsonPropertyName("annotations_url")]
        public string AnnotationsUrl { get; init; } = null!;
    }
}
