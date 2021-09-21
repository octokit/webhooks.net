namespace Octokit.Webhooks
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    internal class WebhookEventTypeAttribute : Attribute
    {
        public WebhookEventTypeAttribute(string eventType) => this.EventType = eventType;

        public string EventType { get; }
    }
}
