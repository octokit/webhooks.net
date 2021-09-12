namespace JamieMagee.Octokit.Webhooks
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Extensions.Primitives;

    public class WebhookPayload
    {
        public WebhookHeaders Headers { get; init; }

        public WebhookEvent Body { get; init; }

        public static WebhookPayload Parse(IDictionary<string, StringValues> headers, string body)
        {
            if (headers is null)
            {
                throw new ArgumentNullException(nameof(headers));
            }

            if (body is null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            return new WebhookPayload
            {
                Headers = WebhookHeaders.Parse(headers),
                Body = WebhookEvent.Parse(body)!,
            };
        }

        public override string ToString() => $"{this.Headers?.Event}, {this.Body}";
    }
}
