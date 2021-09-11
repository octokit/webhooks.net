namespace JamieMagee.Octokit.Webhooks.Events.Issues
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record IssuesUnlockedEvent : IssuesEvent
    {
        [JsonPropertyName("action")]
        public override string Action => IssuesAction.Unlocked;
    }
}
