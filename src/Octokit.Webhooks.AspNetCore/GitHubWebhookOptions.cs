namespace Octokit.Webhooks.AspNetCore;

public record GitHubWebhookOptions
{
    public string? Secret { get; set; }
}
