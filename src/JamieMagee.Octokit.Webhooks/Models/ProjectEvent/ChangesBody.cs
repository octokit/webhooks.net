namespace JamieMagee.Octokit.Webhooks.Models.ProjectEvent
{
    using System.Text.Json.Serialization;

    public record ChangesBody
    {
        [JsonPropertyName("from")]
        public string From { get; init; } = null!;
    };
}
