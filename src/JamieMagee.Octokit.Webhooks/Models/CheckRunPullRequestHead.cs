namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public sealed record CheckRunPullRequestHead
    {
        [JsonPropertyName("ref")]
        public string Ref { get; set; } = null!;

        [JsonPropertyName("sha")]
        public string Sha { get; set; } = null!;

        [JsonPropertyName("repo")]
        public RepoRef Repo { get; set; } = null!;
    }
}
