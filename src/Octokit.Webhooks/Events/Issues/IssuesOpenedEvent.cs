namespace Octokit.Webhooks.Events.Issues
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Models.IssuesEvent;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(IssuesActionValue.Opened)]
    public sealed record IssuesOpenedEvent : IssuesEvent
    {
        [JsonPropertyName("action")]
        public override string Action => IssuesAction.Opened;

        [JsonPropertyName("changes")]
        public Changes? Changes { get; init; }
    }
}
