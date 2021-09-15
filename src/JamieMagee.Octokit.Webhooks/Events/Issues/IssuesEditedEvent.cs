namespace JamieMagee.Octokit.Webhooks.Events.Issues
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;
    using JamieMagee.Octokit.Webhooks.Models.IssuesEvent;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(IssuesActionValue.Edited)]
    public sealed record IssuesEditedEvent : IssuesEvent
    {
        [JsonPropertyName("action")]
        public override string Action => IssuesAction.Edited;

        [JsonPropertyName("label")]
        public Label? Label { get; init; }

        [JsonPropertyName("changes")]
        public Changes? Changes { get; init; }
    }
}
