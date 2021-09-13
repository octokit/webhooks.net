namespace JamieMagee.Octokit.Webhooks.Events.Membership
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(MembershipActionValue.Added)]
    public sealed record MembershipAddedEvent : MembershipEvent
    {
        [JsonPropertyName("action")]
        public override string Action => MembershipAction.Added;
    }
}
