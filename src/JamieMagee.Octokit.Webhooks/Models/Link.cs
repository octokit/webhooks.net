namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public sealed record Link
    {
        [JsonPropertyName("href")]
        public string Href { get; set; } = null!;
    }
}
