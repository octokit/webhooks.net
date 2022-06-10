namespace Octokit.Webhooks.Events.ProjectsV2Item
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Octokit.Webhooks.Models.ProjectsV2ItemEvent;

    [PublicAPI]
    [WebhookActionType(ProjectsV2ItemActionValue.Edited)]
    public sealed record ProjectsV2ItemEditedEvent : ProjectsV2ItemEvent
    {
        [JsonPropertyName("action")]
        public override string Action => ProjectsV2ItemAction.Edited;

        [JsonPropertyName("changes")]
        public Changes Changes { get; init; } = null!;
    }
}
