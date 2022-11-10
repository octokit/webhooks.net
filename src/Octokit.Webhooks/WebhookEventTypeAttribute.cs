namespace Octokit.Webhooks;

[AttributeUsage(AttributeTargets.Class)]
internal sealed class WebhookEventTypeAttribute : Attribute
{
    public WebhookEventTypeAttribute(string eventType) => this.EventType = eventType;

    public string EventType { get; }
}
