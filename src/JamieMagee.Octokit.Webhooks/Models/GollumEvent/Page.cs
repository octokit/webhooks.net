namespace JamieMagee.Octokit.Webhooks.Models.GollumEvent
{
    using System.Text.Json.Serialization;

    public sealed record Page
    {
        [JsonPropertyName("page_name")]
        public string PageName { get; init; } = null!;

        [JsonPropertyName("title")]
        public string Title { get; init; } = null!;

        [JsonPropertyName("summary")]
        public string? Summary { get; init; }

        [JsonPropertyName("action")]
        public PageAction Action { get; init; }

        [JsonPropertyName("sha")]
        public string Sha { get; init; } = null!;

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; init; } = null!;
    }
}
