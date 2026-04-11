namespace Octokit.Webhooks.Benchmarks;

using System.Text.Json;
using BenchmarkDotNet.Attributes;
using Octokit.Webhooks.Events;
using Octokit.Webhooks.Events.Issues;
using Octokit.Webhooks.Events.PullRequest;
using Octokit.Webhooks.TestUtils;

[MemoryDiagnoser]
public class WebhookDeserializationBenchmarks
{
    private string pushBody = null!;
    private string pullRequestBody = null!;
    private string issuesBody = null!;

    [GlobalSetup]
    public void Setup()
    {
        this.pushBody = ResourceUtils.ReadResource("push/payload.json");
        this.pullRequestBody = ResourceUtils.ReadResource("pull_request/opened.payload.json");
        this.issuesBody = ResourceUtils.ReadResource("issues/opened.payload.json");
    }

    [Benchmark]
    public PushEvent? DeserializePushEvent()
        => JsonSerializer.Deserialize<PushEvent>(this.pushBody);

    [Benchmark]
    public PullRequestEvent? DeserializePullRequestEvent()
        => JsonSerializer.Deserialize<PullRequestEvent>(this.pullRequestBody);

    [Benchmark]
    public IssuesEvent? DeserializeIssuesEvent()
        => JsonSerializer.Deserialize<IssuesEvent>(this.issuesBody);
}
