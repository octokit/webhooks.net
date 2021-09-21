namespace Octokit.Webhooks.Events.DeployKey
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(DeployKeyActionValue.Created)]
    public sealed record DeployKeyCreatedEvent : DeployKeyEvent
    {
        [JsonPropertyName("action")]
        public override string Action => DeployKeyAction.Created;
    }
}
