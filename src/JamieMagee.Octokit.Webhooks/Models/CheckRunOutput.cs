namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public class CheckRunOutput
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("summary")]
        public string? Summary { get; set; }

        [JsonPropertyName("text")]
        public string? Text { get; set; }

        [JsonPropertyName("annotations_count")]
        public int AnnotationsCount { get; set; }

        [JsonPropertyName("annotations_url")]
        public string AnnotationsUrl { get; set; } = null!;
    }
}
