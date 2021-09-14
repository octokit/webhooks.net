namespace JamieMagee.Octokit.Webhooks.Events.Issues
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;
    using JamieMagee.Octokit.Webhooks.Models.IssuesEvent;

    [WebhookActionType(IssuesActionValue.Opened)]
    public sealed record IssuesOpenedEvent : IssuesEvent
    {
        [JsonPropertyName("action")]
        public override string Action => IssuesAction.Opened;

        [JsonPropertyName("changes")]
        public Changes? Changes { get; init; }
    }
}
