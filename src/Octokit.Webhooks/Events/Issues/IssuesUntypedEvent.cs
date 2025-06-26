namespace Octokit.Webhooks.Events.Issues;

[PublicAPI]
[WebhookActionType(IssuesActionValue.Untyped)]
public sealed record IssuesUntypedEvent : IssuesEvent
{
    [JsonPropertyName("action")]
    public override string Action => IssuesAction.Untyped;

    [JsonPropertyName("type")]
    public IssueType? Type { get; init; }
}
