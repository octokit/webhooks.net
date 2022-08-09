namespace Octokit.Webhooks.Events.Meta;

[PublicAPI]
[WebhookActionType(MetaActionValue.Deleted)]
public sealed record MetaDeletedEvent : MetaEvent
{
    [JsonPropertyName("action")]
    public override string Action => MetaAction.Deleted;
}
