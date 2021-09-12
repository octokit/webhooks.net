namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public sealed record CheckRunPullRequestBase
    {
        [JsonPropertyName("ref")]
        public string Ref { get; init; } = null!;

        [JsonPropertyName("sha")]
        public string Sha { get; init; } = null!;

        [JsonPropertyName("repo")]
        public RepoRef Repo { get; init; } = null!;
    }
}
