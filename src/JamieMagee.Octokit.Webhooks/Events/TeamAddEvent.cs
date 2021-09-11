namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Events.TeamAdd;

    public sealed record TeamAddEvent : WebhookEvent
    {
        [JsonPropertyName("action")]
        public override string Action => TeamAddAction.Event;
    }
}
