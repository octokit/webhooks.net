namespace JamieMagee.Octokit.Webhooks.Events.CheckSuite
{
    using System.Text.Json.Serialization;

    [WebhookActionType(CheckSuiteActionValue.Requested)]
    public sealed record CheckSuiteRequestedEvent : CheckSuiteEvent
    {
        [JsonPropertyName("action")]
        public override string Action => CheckSuiteAction.Requested;
    }
}
