using AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Octokit.Webhooks;
using Octokit.Webhooks.AspNetCore;

#pragma warning disable CA1852

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<WebhookEventProcessor, MyWebhookEventProcessor>();

var app = builder.Build();

app.UseRouting()
    .UseEndpoints(endpoints => endpoints.MapGitHubWebhooks());

app.Run();
