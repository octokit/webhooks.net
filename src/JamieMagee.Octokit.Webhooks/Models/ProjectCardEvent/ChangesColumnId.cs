namespace JamieMagee.Octokit.Webhooks.Models.ProjectCardEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record ChangesColumnId
    {
        [JsonPropertyName("from")]
        public int From { get; init; }
    }
}
