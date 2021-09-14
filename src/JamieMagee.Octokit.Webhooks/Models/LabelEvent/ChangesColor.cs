namespace JamieMagee.Octokit.Webhooks.Models.LabelEvent
{
    using System.Text.Json.Serialization;

    public sealed record ChangesColor
    {
        [JsonPropertyName("from")]
        public string From { get; init; } = null!;
    };
}
