namespace Octokit.Webhooks.Events.Issues;

[PublicAPI]
[WebhookActionType(IssuesActionValue.Closed)]
public sealed record IssuesClosedEvent : IssuesEvent
{
    [JsonPropertyName("action")]
    public override string Action => IssuesAction.Closed;
}
