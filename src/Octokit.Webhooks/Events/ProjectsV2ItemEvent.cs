namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Octokit.Webhooks.Converter;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.ProjectsV2Item)]
    [JsonConverter(typeof(WebhookConverter<ProjectsV2ItemEvent>))]
    public abstract record ProjectsV2ItemEvent : WebhookEvent
    {
        [JsonPropertyName("projects_v2_item")]
        public Models.ProjectsV2Item ProjectsV2Item { get; init; } = null!;
    }
}
