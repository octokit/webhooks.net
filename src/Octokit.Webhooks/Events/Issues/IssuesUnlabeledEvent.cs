namespace Octokit.Webhooks.Events.Issues;

[PublicAPI]
[WebhookActionType(IssuesActionValue.Unlabeled)]
public sealed record IssuesUnlabeledEvent : IssuesEvent
{
    [JsonPropertyName("action")]
    public override string Action => IssuesAction.Unlabeled;

    [JsonPropertyName("label")]
    public Label? Label { get; init; }
}
