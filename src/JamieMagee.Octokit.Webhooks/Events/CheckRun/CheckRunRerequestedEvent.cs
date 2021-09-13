namespace JamieMagee.Octokit.Webhooks.Events.CheckRun
{
    using System.Text.Json.Serialization;

    [WebhookActionType(CheckRunActionValue.Rerequested)]
    public sealed record CheckRunRerequestedEvent : CheckRunEvent
    {
        [JsonPropertyName("action")]
        public override string Action => CheckRunAction.Rerequested;
    }
}
