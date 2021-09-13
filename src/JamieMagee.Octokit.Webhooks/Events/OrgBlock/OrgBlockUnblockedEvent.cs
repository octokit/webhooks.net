namespace JamieMagee.Octokit.Webhooks.Events.OrgBlock
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(OrgBlockActionValue.Unblocked)]
    public sealed record OrgBlockUnblockedEvent : OrgBlockEvent
    {
        [JsonPropertyName("action")]
        public override string Action => OrgBlockAction.Unblocked;
    }
}
