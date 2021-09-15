namespace JamieMagee.Octokit.Webhooks.Events.Issues
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models.IssuesEvent;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(IssuesActionValue.Transferred)]
    public sealed record IssuesTransferredEvent : IssuesEvent
    {
        [JsonPropertyName("action")]
        public override string Action => IssuesAction.Transferred;

        [JsonPropertyName("changes")]
        public Changes? Changes { get; init; }
    }
}
