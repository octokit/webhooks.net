namespace Octokit.Webhooks.Events.ProjectColumn
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(ProjectColumnActionValue.Created)]
    public sealed record ProjectColumnCreatedEvent : ProjectColumnEvent
    {
        [JsonPropertyName("action")]
        public override string Action => ProjectColumnAction.Created;
    }
}
