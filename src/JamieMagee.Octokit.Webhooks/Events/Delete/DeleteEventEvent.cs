namespace JamieMagee.Octokit.Webhooks.Events.Delete
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(DeleteActionValue.Event)]
    public sealed record DeleteEventEvent : DeleteEvent
    {
        [JsonPropertyName("action")]
        public override string Action => DeleteAction.Event;
    }
}
