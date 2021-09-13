namespace JamieMagee.Octokit.Webhooks.Events.CheckRun
{
    using System.Text.Json.Serialization;

    [WebhookActionType(CheckRunActionValue.RequestedAction)]
    public sealed record CheckRunRequestedActionEvent : CheckRunEvent
    {
        [JsonPropertyName("action")]
        public override string Action => CheckRunAction.RequestedAction;
    }
}
