namespace Octokit.Webhooks.Events.Release
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(ReleaseActionValue.Unpublished)]
    public sealed record ReleaseUnpublishedEvent : ReleaseEvent
    {
        [JsonPropertyName("action")]
        public override string Action => ReleaseAction.Unpublished;
    }
}
