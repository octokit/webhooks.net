namespace JamieMagee.Octokit.Webhooks.Events.OrgBlock
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(OrgBlockActionValue.Unblocked)]
    public sealed record OrgBlockUnblockedEvent : OrgBlockEvent
    {
        [JsonPropertyName("action")]
        public override string Action => OrgBlockAction.Unblocked;
    }
}
