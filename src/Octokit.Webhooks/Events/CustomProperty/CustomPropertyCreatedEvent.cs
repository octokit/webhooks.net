namespace Octokit.Webhooks.Events.CustomProperty;

[PublicAPI]
[WebhookActionType(CustomPropertyActionValue.Created)]
public sealed record CustomPropertyCreatedEvent : CustomPropertyEvent
{
    [JsonPropertyName("action")]
    public override string Action => CustomPropertyAction.Created;

    [JsonPropertyName("definition")]
    public Models.CustomPropertyEvent.CustomProperty CustomProperty { get; init; } = null!;
}
