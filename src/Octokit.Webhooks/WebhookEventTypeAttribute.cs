namespace Octokit.Webhooks;

[AttributeUsage(AttributeTargets.Class)]
internal sealed class WebhookEventTypeAttribute(string eventType) : Attribute
{
    public string EventType { get; } = eventType;
}
