namespace Octokit.Webhooks.Events.CustomProperty;

[PublicAPI]
[WebhookActionType(CustomPropertyActionValue.Updated)]
public sealed record CustomPropertyUpdatedEvent : CustomPropertyEvent
{
    [JsonPropertyName("action")]
    public override string Action => CustomPropertyAction.Updated;

    [JsonPropertyName("definition")]
    public required Models.CustomPropertyEvent.CustomProperty CustomProperty { get; init; }
}
