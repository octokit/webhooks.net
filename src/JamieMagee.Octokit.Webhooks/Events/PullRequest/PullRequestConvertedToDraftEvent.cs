namespace JamieMagee.Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;

    public sealed record PullRequestConvertedToDraftEvent : PullRequestEvent
    {
        [JsonPropertyName("action")]
        public override string Action => PullRequestEventAction.ConvertedToDraft;
    }
}
