namespace Octokit.Webhooks.Events.Project
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(ProjectActionValue.Closed)]
    public sealed record ProjectClosedEvent : ProjectEvent
    {
        [JsonPropertyName("action")]
        public override string Action => ProjectAction.Closed;
    }
}
