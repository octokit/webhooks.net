namespace Octokit.Webhooks.Events.Project;

[PublicAPI]
[WebhookActionType(ProjectActionValue.Closed)]
public sealed record ProjectClosedEvent : ProjectEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectAction.Closed;
}
