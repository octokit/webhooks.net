namespace Octokit.Webhooks.Events.Star
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(StarActionValue.Deleted)]
    public sealed record StarDeletedEvent : StarEvent
    {
        [JsonPropertyName("action")]
        public override string Action => StarAction.Deleted;
    }
}
