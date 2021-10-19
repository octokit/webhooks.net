namespace AspNetCore
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Octokit.Webhooks;
    using Octokit.Webhooks.AspNetCore;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) => services.AddSingleton<WebhookEventProcessor, MyWebhookEventProcessor>();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGitHubWebhooks();
            });
        }
    }
}
