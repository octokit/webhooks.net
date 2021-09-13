namespace JamieMagee.Octokit.Webhooks.Events.Membership
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(MembershipActionValue.Removed)]
    public sealed record MembershipRemovedEvent : MembershipEvent
    {
        [JsonPropertyName("action")]
        public override string Action => MembershipAction.Removed;
    }
}