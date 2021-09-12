namespace JamieMagee.Octokit.Webhooks
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Extensions.Primitives;

    public sealed class WebhookHeaders
    {
        public string UserAgent { get; init; }

        public string Delivery { get; init; }

        public string Event { get; init; }

        public string HookId { get; init; }

        public string HookInstallationTargetId { get; init; }

        public string HookInstallationTargetType { get; init; }

        public static WebhookHeaders Parse(IDictionary<string, StringValues> headers)
        {
            if (headers is null)
            {
                throw new ArgumentNullException(nameof(headers));
            }

            headers.TryGetValue("User-Agent", out var userAgent);
            headers.TryGetValue("X-GitHub-Delivery", out var delivery);
            headers.TryGetValue("X-GitHub-Event", out var eventName);
            headers.TryGetValue("X-GitHub-Hook-ID", out var hookId);
            headers.TryGetValue("X-GitHub-Hook-Installation-Target-ID", out var hookInstallationTargetId);
            headers.TryGetValue("X-GitHub-Hook-Installation-Target-Type", out var hookInstallationTargetType);

            return new WebhookHeaders
            {
                UserAgent = userAgent.ToString(),
                Delivery = delivery.ToString(),
                Event = eventName.ToString(),
                HookId = hookId.ToString(),
                HookInstallationTargetId = hookInstallationTargetId.ToString(),
                HookInstallationTargetType = hookInstallationTargetType.ToString(),
            };
        }
    }
}
