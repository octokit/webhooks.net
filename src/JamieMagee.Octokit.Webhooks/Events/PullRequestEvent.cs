namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using Models;

    public abstract class PullRequestEvent : WebhookEvent
    {
        [JsonPropertyName("number")] public int Number { get; set; }

        [JsonPropertyName("pull_request")] public Models.PullRequest PullRequest { get; set; } = null!;

        [JsonPropertyName("repository")] public Repository Repository { get; set; } = null!;

        [JsonPropertyName("installation")] public InstallationLite? Installation { get; set; }

        [JsonPropertyName("organization")] public Organization? Organization { get; set; }

        [JsonPropertyName("sender")] public User Sender { get; set; } = null!;
    }
}
