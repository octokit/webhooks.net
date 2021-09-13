namespace JamieMagee.Octokit.Webhooks.Events.Package
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(PackageActionValue.Published)]
    public sealed record PackagePublishedEvent : PackageEvent
    {
        [JsonPropertyName("action")]
        public override string Action => PackageAction.Published;
    }
}