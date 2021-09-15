namespace JamieMagee.Octokit.Webhooks.Models.ProjectCardEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record ChangesNote
    {
        [JsonPropertyName("from")]
        public string From { get; init; } = null!;
    }
}
