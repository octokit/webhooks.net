namespace JamieMagee.Octokit.Webhooks.Events.Star
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(StarActionValue.Created)]
    public sealed record StarCreatedEvent : StarEvent
    {
        [JsonPropertyName("action")]
        public override string Action => StarAction.Created;
    }
}
