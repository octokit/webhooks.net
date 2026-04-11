namespace Octokit.Webhooks.Events.MergeGroup;

[PublicAPI]
[WebhookActionType(MergeGroupActionValue.Destroyed)]
public sealed record MergeGroupDestroyedEvent : MergeGroupEvent
{
    [JsonPropertyName("action")]
    public override string Action => MergeGroupAction.Destroyed;

    [JsonPropertyName("reason")]
    public required string Reason { get; init; }
}
