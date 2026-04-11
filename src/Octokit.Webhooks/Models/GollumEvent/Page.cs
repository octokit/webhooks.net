namespace Octokit.Webhooks.Models.GollumEvent;

[PublicAPI]
public sealed record Page
{
    [JsonPropertyName("page_name")]
    public required string PageName { get; init; }

    [JsonPropertyName("title")]
    public required string Title { get; init; }

    [JsonPropertyName("summary")]
    public string? Summary { get; init; }

    [JsonPropertyName("action")]
    [JsonConverter(typeof(StringEnumConverter<PageAction>))]
    public required StringEnum<PageAction> Action { get; init; }

    [JsonPropertyName("sha")]
    public required string Sha { get; init; }

    [JsonPropertyName("html_url")]
    public required string HtmlUrl { get; init; }
}
