namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Octokit.Webhooks.Converter;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.ProjectColumn)]
    [JsonConverter(typeof(WebhookConverter<ProjectColumnEvent>))]
    public abstract record ProjectColumnEvent : WebhookEvent
    {
        [JsonPropertyName("project_column")]
        public Models.ProjectColumn ProjectColumn { get; init; } = null!;
    }
}
