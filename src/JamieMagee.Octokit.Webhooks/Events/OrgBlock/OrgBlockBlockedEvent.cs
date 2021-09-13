namespace JamieMagee.Octokit.Webhooks.Events.OrgBlock
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(OrgBlockActionValue.Blocked)]
    public sealed record OrgBlockBlockedEvent : OrgBlockEvent
    {
        [JsonPropertyName("action")]
        public override string Action => OrgBlockAction.Blocked;
    }
}
