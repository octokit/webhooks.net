namespace Octokit.Webhooks.Events.CheckRun
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(CheckRunActionValue.Completed)]
    public sealed record CheckRunCompletedEvent : CheckRunEvent
    {
        [JsonPropertyName("action")]
        public override string Action => CheckRunAction.Completed;
    }
}
