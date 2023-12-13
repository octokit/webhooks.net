namespace Octokit.Webhooks.Events.CustomProperty;

[PublicAPI]
[WebhookActionType(CustomPropertyActionValue.Deleted)]
public sealed record CustomPropertyDeletedEvent : CustomPropertyEvent
{
    [JsonPropertyName("action")]
    public override string Action => CustomPropertyAction.Deleted;
}
