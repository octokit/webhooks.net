namespace Octokit.Webhooks;

using Microsoft.Extensions.Primitives;

[PublicAPI]
public sealed class WebhookHeaders
{
    public string? UserAgent { get; init; }

    public string? Delivery { get; init; }

    public string? Event { get; init; }

    public string? HookId { get; init; }

    public string? HookInstallationTargetId { get; init; }

    public string? HookInstallationTargetType { get; init; }

    public string? Signature256 { get; init; }

    public static WebhookHeaders Parse(IDictionary<string, StringValues> headers)
    {
        ArgumentNullException.ThrowIfNull(headers);

        headers.TryGetValue("User-Agent", out var userAgent);
        headers.TryGetValue("X-GitHub-Delivery", out var delivery);
        headers.TryGetValue("X-GitHub-Event", out var eventName);
        headers.TryGetValue("X-GitHub-Hook-ID", out var hookId);
        headers.TryGetValue("X-GitHub-Hook-Installation-Target-ID", out var hookInstallationTargetId);
        headers.TryGetValue("X-GitHub-Hook-Installation-Target-Type", out var hookInstallationTargetType);
        headers.TryGetValue("X-Hub-Signature-256", out var signature256);

        return new WebhookHeaders
        {
            UserAgent = userAgent.ToString(),
            Delivery = delivery.ToString(),
            Event = eventName.ToString(),
            HookId = hookId.ToString(),
            HookInstallationTargetId = hookInstallationTargetId.ToString(),
            HookInstallationTargetType = hookInstallationTargetType.ToString(),
            Signature256 = signature256.ToString(),
        };
    }
}
