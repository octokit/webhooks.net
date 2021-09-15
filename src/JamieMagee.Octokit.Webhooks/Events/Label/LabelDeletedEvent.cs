namespace JamieMagee.Octokit.Webhooks.Events.Label
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(LabelActionValue.Deleted)]
    public sealed record LabelDeletedEvent : LabelEvent
    {
        [JsonPropertyName("action")]
        public override string Action => LabelAction.Deleted;
    }
}
