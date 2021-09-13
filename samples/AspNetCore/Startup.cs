namespace AspNetCore
{
    using JamieMagee.Octokit.Webhooks;
    using JamieMagee.Octokit.Webhooks.AspNetCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) => services.AddSingleton<WebhookProcessor, MyWebhookProcessor>();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapGitHubWebhook();
            });
        }
    }
}
