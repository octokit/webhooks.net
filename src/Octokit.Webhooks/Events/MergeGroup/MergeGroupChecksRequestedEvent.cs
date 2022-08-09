namespace Octokit.Webhooks.Events.MergeGroup;

[PublicAPI]
[WebhookActionType(MergeGroupActionValue.ChecksRequested)]
public sealed record MergeGroupChecksRequestedEvent : MergeGroupEvent
{
    [JsonPropertyName("action")]
    public override string Action => MergeGroupAction.ChecksRequested;
}
