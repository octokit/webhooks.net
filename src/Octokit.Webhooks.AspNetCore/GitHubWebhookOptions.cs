namespace Octokit.Webhooks.AspNetCore;

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public record GitHubWebhookOptions
{
    public string? Secret { get; set; }

    /// <summary>
    /// Gets or sets a callback for handling exceptions thrown while processing a webhook.
    /// </summary>
    /// <remarks>
    /// The callback must return <see langword="true"/> if it handled the exception and completed the HTTP response.
    /// Returning <see langword="false"/> uses the default behavior of logging the exception and returning HTTP 500.
    /// </remarks>
    public Func<Exception, HttpContext, ValueTask<bool>>? ExceptionHandler { get; set; }
}
