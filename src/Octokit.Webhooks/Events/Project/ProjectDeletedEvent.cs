namespace Octokit.Webhooks.Events.Project
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(ProjectActionValue.Deleted)]
    public sealed record ProjectDeletedEvent : ProjectEvent
    {
        [JsonPropertyName("action")]
        public override string Action => ProjectAction.Deleted;
    }
}
