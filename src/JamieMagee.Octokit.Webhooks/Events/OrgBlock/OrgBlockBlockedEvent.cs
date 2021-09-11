namespace JamieMagee.Octokit.Webhooks.Events.OrgBlock
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record OrgBlockBlockedEvent : OrgBlockEvent
    {
        [JsonPropertyName("action")]
        public override string Action => OrgBlockAction.Blocked;
    }
}
