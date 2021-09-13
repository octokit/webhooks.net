namespace JamieMagee.Octokit.Webhooks.Events.CheckRun
{
    using System.Text.Json.Serialization;

    [WebhookActionType(CheckRunActionValue.Created)]
    public sealed record CheckRunCreatedEvent : CheckRunEvent
    {
        [JsonPropertyName("action")]
        public override string Action => CheckRunAction.Created;
    }
}
