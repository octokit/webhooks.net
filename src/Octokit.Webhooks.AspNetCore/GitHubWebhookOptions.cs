namespace Octokit.Webhooks.AspNetCore;

public sealed record GitHubWebhookOptions
{
    public string? Secret { get; set; }
}
