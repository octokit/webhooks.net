namespace Octokit.Webhooks.Models.ProjectsV2ItemEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record ChangesPreviousProjectsV2ItemNodeId
    {
        [JsonPropertyName("from")]
        public string From { get; init; } = null!;

        [JsonPropertyName("to")]
        public string? To { get; init; }
    }
}
