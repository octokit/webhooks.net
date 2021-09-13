namespace JamieMagee.Octokit.Webhooks.Events.CheckRun
{
    using System.Text.Json.Serialization;

    [WebhookActionType(CheckRunActionValue.Completed)]
    public sealed record CheckRunCompletedEvent : CheckRunEvent
    {
        [JsonPropertyName("action")]
        public override string Action => CheckRunAction.Completed;
    }
}
