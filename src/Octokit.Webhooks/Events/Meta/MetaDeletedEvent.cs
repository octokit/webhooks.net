namespace Octokit.Webhooks.Events.Meta
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(MetaActionValue.Deleted)]
    public sealed record MetaDeletedEvent : MetaEvent
    {
        [JsonPropertyName("action")]
        public override string Action => MetaAction.Deleted;
    }
}
