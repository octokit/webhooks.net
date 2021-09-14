namespace JamieMagee.Octokit.Webhooks.Events.Issues
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(IssuesActionValue.Unlabeled)]
    public sealed record IssuesUnlabeledEvent : IssuesEvent
    {
        [JsonPropertyName("action")]
        public override string Action => IssuesAction.Unlabeled;

        [JsonPropertyName("label")]
        public Label? Label { get; init; }
    }
}
