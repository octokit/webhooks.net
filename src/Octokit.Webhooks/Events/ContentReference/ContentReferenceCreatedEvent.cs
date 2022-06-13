namespace Octokit.Webhooks.Events.ContentReference;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(ContentReferenceActionValue.Created)]
public sealed record ContentReferenceCreatedEvent : ContentReferenceEvent
{
    [JsonPropertyName("action")]
    public override string Action => ContentReferenceAction.Created;
}
