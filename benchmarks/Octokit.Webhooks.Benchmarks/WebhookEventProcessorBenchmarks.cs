namespace Octokit.Webhooks.Benchmarks;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Primitives;
using Octokit.Webhooks.TestUtils;

[MemoryDiagnoser]
public class WebhookEventProcessorBenchmarks
{
    private BenchmarkWebhookEventProcessor processor = null!;

    private IDictionary<string, StringValues> pushHeaders = null!;
    private string pushBody = null!;

    private IDictionary<string, StringValues> pullRequestHeaders = null!;
    private string pullRequestBody = null!;

    private IDictionary<string, StringValues> issuesHeaders = null!;
    private string issuesBody = null!;

    [GlobalSetup]
    public void Setup()
    {
        this.processor = new BenchmarkWebhookEventProcessor();

        this.pushBody = ResourceUtils.ReadResource("push/payload.json");
        this.pushHeaders = CreateHeaders("push");

        this.pullRequestBody = ResourceUtils.ReadResource("pull_request/opened.payload.json");
        this.pullRequestHeaders = CreateHeaders("pull_request");

        this.issuesBody = ResourceUtils.ReadResource("issues/opened.payload.json");
        this.issuesHeaders = CreateHeaders("issues");
    }

    [Benchmark]
    public async Task ProcessPushWebhookAsync()
        => await this.processor.ProcessWebhookAsync(this.pushHeaders, this.pushBody).ConfigureAwait(false);

    [Benchmark]
    public async Task ProcessPullRequestWebhookAsync()
        => await this.processor.ProcessWebhookAsync(this.pullRequestHeaders, this.pullRequestBody).ConfigureAwait(false);

    [Benchmark]
    public async Task ProcessIssuesWebhookAsync()
        => await this.processor.ProcessWebhookAsync(this.issuesHeaders, this.issuesBody).ConfigureAwait(false);

    private static Dictionary<string, StringValues> CreateHeaders(string eventName) =>
        new()
        {
            ["X-GitHub-Event"] = eventName,
            ["X-GitHub-Delivery"] = Guid.NewGuid().ToString(),
            ["X-GitHub-Hook-ID"] = "12345",
        };
}
