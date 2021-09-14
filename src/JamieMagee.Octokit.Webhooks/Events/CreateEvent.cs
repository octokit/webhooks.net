namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookEventType(WebhookEventType.Create)]
    public sealed record CreateEvent : WebhookEvent
    {
        [JsonPropertyName("ref")]
        public string Ref { get; init; } = null!;

        [JsonPropertyName("ref_type")]
        public RefType RefType { get; init; }

        [JsonPropertyName("master_branch")]
        public string MasterBranch { get; init; } = null!;

        [JsonPropertyName("description")]
        public string? Description { get; init; }

        [JsonPropertyName("pusher_type")]
        public string PusherType { get; init; } = null!;
    }
}
