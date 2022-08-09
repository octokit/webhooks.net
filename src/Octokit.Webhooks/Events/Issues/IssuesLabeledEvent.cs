namespace Octokit.Webhooks.Events.Issues;

[PublicAPI]
[WebhookActionType(IssuesActionValue.Labeled)]
public sealed record IssuesLabeledEvent : IssuesEvent
{
    [JsonPropertyName("action")]
    public override string Action => IssuesAction.Labeled;

    [JsonPropertyName("label")]
    public Label? Label { get; init; }
}
