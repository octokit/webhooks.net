namespace Octokit.Webhooks;

[PublicAPI]
[AttributeUsage(AttributeTargets.Class)]
public sealed class WebhookEventTypeAttribute : Attribute
{
    public WebhookEventTypeAttribute(string eventType) => this.EventType = eventType;

    public string EventType { get; }
}
