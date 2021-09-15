namespace JamieMagee.Octokit.Webhooks.Events.ProjectColumn
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models.ProjectColumnEvent;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(ProjectColumnActionValue.Edited)]
    public sealed record ProjectColumnEditedEvent : ProjectColumnEvent
    {
        [JsonPropertyName("action")]
        public override string Action => ProjectColumnAction.Edited;

        [JsonPropertyName("changes")]
        public Changes Changes { get; init; } = null!;
    }
}
