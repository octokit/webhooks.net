namespace Octokit.Webhooks.AspNetCore
{
    using System;
    using Octokit.Webhooks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.DependencyInjection;

    public static class GitHubWebhookExtensions
    {
        public static void MapGitHubWebhooks(this IEndpointRouteBuilder endpoints, string path = "/api/github/webhooks", string secret = null!) =>
            endpoints.MapPost(path, async context =>
            {
                WebhookUtilities.VerifyResult<string> maybeBody = WebhookUtilities.GetBodyChecked(context.Request);
                if (maybeBody.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    context.Response.StatusCode = maybeBody.StatusCode;
                    await context.Response.WriteAsync(maybeBody.StatusBody).ConfigureAwait(false);
                    return;
                }

                // Process body
                try
                {
                    var service = context.RequestServices.GetRequiredService<WebhookEventProcessor>();
                    await service.ProcessWebhookAsync(context.Request.Headers, maybeBody.Value)
                        .ConfigureAwait(false);
                    context.Response.StatusCode = 200;
                }
                catch (Exception)
                {
                    context.Response.StatusCode = 500;
                }
            });
    }
}
