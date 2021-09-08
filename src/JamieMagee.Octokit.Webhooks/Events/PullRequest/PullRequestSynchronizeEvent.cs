namespace JamieMagee.Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;

    public sealed record PullRequestSynchronizeEvent : PullRequestEvent
    {
        [JsonPropertyName("action")]
        public override string Action => "opened";

        [JsonPropertyName("before")]
        public string Before { get; set; } = null!;

        [JsonPropertyName("after")]
        public string After { get; set; } = null!;
    }
}
