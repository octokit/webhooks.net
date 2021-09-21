namespace Octokit.Webhooks.Events.ProjectCard
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(ProjectCardActionValue.Deleted)]
    public sealed record ProjectCardDeletedEvent : ProjectCardEvent
    {
        [JsonPropertyName("action")]
        public override string Action => ProjectCardAction.Deleted;
    }
}
