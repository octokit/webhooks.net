namespace Octokit.Webhooks.Events;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;

[PublicAPI]
[WebhookEventType(WebhookEventType.ProjectCard)]
[JsonConverter(typeof(WebhookConverter<ProjectCardEvent>))]
public abstract record ProjectCardEvent : WebhookEvent
{
    [JsonPropertyName("project_card")]
    public Models.ProjectCard ProjectCard { get; init; } = null!;
}
