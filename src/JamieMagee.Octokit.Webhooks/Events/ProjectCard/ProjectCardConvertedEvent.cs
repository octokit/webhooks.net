namespace JamieMagee.Octokit.Webhooks.Events.ProjectCard
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;
    using JamieMagee.Octokit.Webhooks.Models.ProjectCardEvent;

    [WebhookActionType(ProjectCardActionValue.Converted)]
    public sealed record ProjectCardConvertedEvent : ProjectCardEvent
    {
        [JsonPropertyName("action")]
        public override string Action => ProjectCardAction.Converted;

        [JsonPropertyName("changes")]
        public Changes Changes { get; init; } = null!;
    }
}
