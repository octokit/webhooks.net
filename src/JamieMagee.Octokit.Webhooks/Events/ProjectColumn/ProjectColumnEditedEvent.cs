namespace JamieMagee.Octokit.Webhooks.Events.ProjectColumn
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;
    using JamieMagee.Octokit.Webhooks.Models.ProjectColumnEvent;

    [WebhookActionType(ProjectColumnActionValue.Edited)]
    public sealed record ProjectColumnEditedEvent : ProjectColumnEvent
    {
        [JsonPropertyName("action")]
        public override string Action => ProjectColumnAction.Edited;

        [JsonPropertyName("changes")]
        public Changes Changes { get; init; } = null!;
    }
}
