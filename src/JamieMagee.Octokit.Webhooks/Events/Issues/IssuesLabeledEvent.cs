namespace JamieMagee.Octokit.Webhooks.Events.Issues
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(IssuesActionValue.Labeled)]
    public sealed record IssuesLabeledEvent : IssuesEvent
    {
        [JsonPropertyName("action")]
        public override string Action => IssuesAction.Labeled;

        [JsonPropertyName("label")]
        public Label? Label { get; init; }
    }
}
