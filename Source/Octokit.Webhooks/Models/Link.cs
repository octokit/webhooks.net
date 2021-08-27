namespace Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public class Link
    {
        [JsonPropertyName("href")] public string Href { get; set; } = null!;
    }
}
