namespace JamieMagee.Octokit.Webhooks.Events.DeployKey
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(DeployKeyActionValue.Created)]
    public sealed record DeployKeyCreatedEvent : DeployKeyEvent
    {
        [JsonPropertyName("action")]
        public override string Action => DeployKeyAction.Created;
    }
}
