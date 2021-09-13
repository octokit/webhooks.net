namespace JamieMagee.Octokit.Webhooks.Events.Watch
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(WatchActionValue.Started)]
    public sealed record WatchStartedEvent : WatchEvent
    {
        [JsonPropertyName("action")]
        public override string Action => WatchAction.Started;
    }
}
