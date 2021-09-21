namespace Octokit.Webhooks.Events.ProjectCard
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Models.ProjectCardEvent;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(ProjectCardActionValue.Edited)]
    public sealed record ProjectCardEditedEvent : ProjectCardEvent
    {
        [JsonPropertyName("action")]
        public override string Action => ProjectCardAction.Edited;

        [JsonPropertyName("changes")]
        public Changes Changes { get; init; } = null!;
    }
}
