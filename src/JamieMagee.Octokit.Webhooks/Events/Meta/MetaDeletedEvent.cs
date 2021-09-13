namespace JamieMagee.Octokit.Webhooks.Events.Meta
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(MetaActionValue.Deleted)]
    public sealed record MetaDeletedEvent : MetaEvent
    {
        [JsonPropertyName("action")]
        public override string Action => MetaAction.Deleted;
    }
}
