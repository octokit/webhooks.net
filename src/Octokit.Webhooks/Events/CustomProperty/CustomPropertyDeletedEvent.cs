namespace Octokit.Webhooks.Events.CustomProperty;

[PublicAPI]
[WebhookActionType(CustomPropertyActionValue.Deleted)]
public sealed record CustomPropertyDeletedEvent : CustomPropertyEvent
{
    [JsonPropertyName("action")]
    public override string Action => CustomPropertyAction.Deleted;

    [JsonPropertyName("definition")]
    public Models.CustomPropertyEvent.CustomPropertyLite CustomProperty { get; init; } = null!;
}
