namespace JamieMagee.Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;

    [WebhookActionType(PullRequestActionValue.ConvertedToDraft)]
    public sealed record PullRequestConvertedToDraftEvent : PullRequestEvent
    {
        [JsonPropertyName("action")]
        public override string Action => PullRequestAction.ConvertedToDraft;
    }
}
