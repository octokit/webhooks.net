namespace Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public class PullRequestHead
    {
        [JsonPropertyName("label")] public string Label { get; set; } = null!;

        [JsonPropertyName("ref")] public string Ref { get; set; } = null!;

        [JsonPropertyName("sha")] public string Sha { get; set; } = null!;

        [JsonPropertyName("user")] public User User { get; set; } = null!;

        [JsonPropertyName("repo")] public Repository Repo { get; set; } = null!;
    }
}
