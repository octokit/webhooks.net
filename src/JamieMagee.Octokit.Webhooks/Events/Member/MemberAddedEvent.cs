namespace JamieMagee.Octokit.Webhooks.Events.Member
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(MemberActionValue.Added)]
    public sealed record MemberAddedEvent : MemberEvent
    {
        [JsonPropertyName("action")]
        public override string Action => MemberAction.Added;
    }
}
