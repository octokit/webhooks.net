namespace Octokit.Webhooks.Events.CustomPropertyValues;

[PublicAPI]
[WebhookActionType(CustomPropertyValuesActionValue.Updated)]
public sealed record CustomPropertyValuesUpdatedEvent : CustomPropertyValuesEvent
{
    [JsonPropertyName("action")]
    public override string Action => CustomPropertyValuesAction.Updated;
}
