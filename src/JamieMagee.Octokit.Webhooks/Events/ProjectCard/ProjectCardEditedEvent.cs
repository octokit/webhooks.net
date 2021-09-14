namespace JamieMagee.Octokit.Webhooks.Events.ProjectCard
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;
    using JamieMagee.Octokit.Webhooks.Models.ProjectCardEvent;

    [WebhookActionType(ProjectCardActionValue.Edited)]
    public sealed record ProjectCardEditedEvent : ProjectCardEvent
    {
        [JsonPropertyName("action")]
        public override string Action => ProjectCardAction.Edited;

        [JsonPropertyName("changes")]
        public Changes Changes { get; init; } = null!;
    }
}
