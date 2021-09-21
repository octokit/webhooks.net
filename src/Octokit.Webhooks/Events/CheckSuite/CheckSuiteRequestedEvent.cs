namespace Octokit.Webhooks.Events.CheckSuite
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(CheckSuiteActionValue.Requested)]
    public sealed record CheckSuiteRequestedEvent : CheckSuiteEvent
    {
        [JsonPropertyName("action")]
        public override string Action => CheckSuiteAction.Requested;
    }
}
