namespace Octokit.Webhooks.Events.Package
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(PackageActionValue.Published)]
    public sealed record PackagePublishedEvent : PackageEvent
    {
        [JsonPropertyName("action")]
        public override string Action => PackageAction.Published;
    }
}
