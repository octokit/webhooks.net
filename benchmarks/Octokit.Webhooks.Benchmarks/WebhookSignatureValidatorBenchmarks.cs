namespace Octokit.Webhooks.Benchmarks;

using System;
using System.Security.Cryptography;
using System.Text;
using BenchmarkDotNet.Attributes;
using Octokit.Webhooks.TestUtils;

[MemoryDiagnoser]
public class WebhookSignatureValidatorBenchmarks
{
    private const string Secret = "benchmark-webhook-secret";

    private string smallBody = null!;
    private string smallSignature = null!;

    private string largeBody = null!;
    private string largeSignature = null!;

    [GlobalSetup]
    public void Setup()
    {
        this.smallBody = ResourceUtils.ReadResource("issues/opened.payload.json");
        this.smallSignature = ComputeSignature(Secret, this.smallBody);

        this.largeBody = ResourceUtils.ReadResource("pull_request/opened.payload.json");
        this.largeSignature = ComputeSignature(Secret, this.largeBody);
    }

    [Benchmark(Description = "Verify (small payload)")]
    public WebhookSignatureValidationResult VerifySmallPayload()
        => WebhookSignatureValidator.Verify(this.smallSignature, Secret, this.smallBody);

    [Benchmark(Description = "Verify (large payload)")]
    public WebhookSignatureValidationResult VerifyLargePayload()
        => WebhookSignatureValidator.Verify(this.largeSignature, Secret, this.largeBody);

    private static string ComputeSignature(string secret, string body)
    {
        var keyBytes = Encoding.UTF8.GetBytes(secret);
        var bodyBytes = Encoding.UTF8.GetBytes(body);
        var hash = HMACSHA256.HashData(keyBytes, bodyBytes);
        return $"sha256={Convert.ToHexString(hash).ToLowerInvariant()}";
    }
}
