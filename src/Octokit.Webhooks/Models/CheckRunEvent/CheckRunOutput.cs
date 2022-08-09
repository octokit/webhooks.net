namespace Octokit.Webhooks.Models.CheckRunEvent;

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
    public long AnnotationsCount { get; init; }

    [JsonPropertyName("annotations_url")]
    public string AnnotationsUrl { get; init; } = null!;
}
