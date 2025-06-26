namespace Octokit.Webhooks.Events.Issues;

[PublicAPI]
[WebhookActionType(IssuesActionValue.Typed)]
public sealed record IssuesTypedEvent : IssuesEvent
{
    [JsonPropertyName("action")]
    public override string Action => IssuesAction.Typed;

    [JsonPropertyName("type")]
    public IssueType? Type { get; init; }
}
