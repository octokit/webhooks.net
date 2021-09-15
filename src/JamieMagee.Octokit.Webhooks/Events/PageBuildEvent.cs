namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models.PageBuildEvent;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.PageBuild)]
    public sealed record PageBuildEvent : WebhookEvent
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("build")]
        public Build Build { get; init; } = null!;
    }
}
