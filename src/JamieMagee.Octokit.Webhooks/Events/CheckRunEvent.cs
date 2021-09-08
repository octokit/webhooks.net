namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public abstract record CheckRunEvent : WebhookEvent
    {
        [JsonPropertyName("check_run")]
        public Models.CheckRun CheckRun { get; set; } = null!;

        [JsonPropertyName("requested_action")]
        public CheckRunRequestedAction? RequestedAction { get; set; }
    }
}
