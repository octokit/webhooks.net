namespace Octokit.Webhooks.Events.ProjectColumn;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(ProjectColumnActionValue.Moved)]
public sealed record ProjectColumnMovedEvent : ProjectColumnEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectColumnAction.Moved;
}
