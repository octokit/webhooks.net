namespace JamieMagee.Octokit.Webhooks.Events.DeployKey
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(DeployKeyActionValue.Deleted)]
    public sealed record DeployKeyDeletedEvent : DeployKeyEvent
    {
        [JsonPropertyName("action")]
        public override string Action => DeployKeyAction.Deleted;
    }
}
