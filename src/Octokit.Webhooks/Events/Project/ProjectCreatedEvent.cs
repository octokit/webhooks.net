namespace Octokit.Webhooks.Events.Project;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(ProjectActionValue.Created)]
public sealed record ProjectCreatedEvent : ProjectEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectAction.Created;
}
