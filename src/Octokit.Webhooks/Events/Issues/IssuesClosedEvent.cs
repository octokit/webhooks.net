namespace Octokit.Webhooks.Events.Issues
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(IssuesActionValue.Closed)]
    public sealed record IssuesClosedEvent : IssuesEvent
    {
        [JsonPropertyName("action")]
        public override string Action => IssuesAction.Closed;
    }
}
