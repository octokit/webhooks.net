namespace Octokit.Webhooks.Events.ProjectColumn;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(ProjectColumnActionValue.Deleted)]
public sealed record ProjectColumnDeletedEvent : ProjectColumnEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectColumnAction.Deleted;
}
