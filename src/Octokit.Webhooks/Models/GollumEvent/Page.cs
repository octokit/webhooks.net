namespace Octokit.Webhooks.Models.GollumEvent;

[PublicAPI]
public sealed record Page
{
    [JsonPropertyName("page_name")]
    public string PageName { get; init; } = null!;

    [JsonPropertyName("title")]
    public string Title { get; init; } = null!;

    [JsonPropertyName("summary")]
    public string? Summary { get; init; }

    [JsonPropertyName("action")]
    [JsonConverter(typeof(StringEnumConverter<PageAction>))]
    public StringEnum<PageAction> Action { get; init; } = null!;

    [JsonPropertyName("sha")]
    public string Sha { get; init; } = null!;

    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; init; } = null!;
}
