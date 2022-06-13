namespace Octokit.Webhooks.Events.Project;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(ProjectActionValue.Reopened)]
public sealed record ProjectReopenedEvent : ProjectEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectAction.Reopened;
}