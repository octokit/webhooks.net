namespace Octokit.Webhooks.Events.ContentReference;

[PublicAPI]
[WebhookActionType(ContentReferenceActionValue.Created)]
public sealed record ContentReferenceCreatedEvent : ContentReferenceEvent
{
    [JsonPropertyName("action")]
    public override string Action => ContentReferenceAction.Created;
}
