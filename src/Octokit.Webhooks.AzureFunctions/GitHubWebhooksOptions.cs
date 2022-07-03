namespace Octokit.Webhooks.AzureFunctions;

public record GitHubWebhooksOptions
{
    public string? Secret { get; set; }
}
