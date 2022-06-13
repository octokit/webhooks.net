namespace Octokit.Webhooks.Events.Milestone;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(MilestoneActionValue.Deleted)]
public sealed record MilestoneDeletedEvent : MilestoneEvent
{
    [JsonPropertyName("action")]
    public override string Action => MilestoneAction.Deleted;
}
