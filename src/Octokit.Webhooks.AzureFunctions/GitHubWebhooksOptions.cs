namespace Octokit.Webhooks.AzureFunctions;

public sealed record GitHubWebhooksOptions
{
    public string? Secret { get; set; }
}
