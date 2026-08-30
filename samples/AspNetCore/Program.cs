#pragma warning disable CA1852
using System.Text.Json;
using System.Threading.Tasks;
using AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Octokit.Webhooks;
using Octokit.Webhooks.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<WebhookEventProcessor, MyWebhookEventProcessor>();
builder.Services.Configure<GitHubWebhookOptions>(options =>
{
    options.ExceptionHandler = (exception, context) =>
    {
        if (exception is JsonException)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            return ValueTask.FromResult(true);
        }

        return ValueTask.FromResult(false);
    };
});

var app = builder.Build();

app.UseRouting()
    .UseEndpoints(endpoints => endpoints.MapGitHubWebhooks());

app.Run();
