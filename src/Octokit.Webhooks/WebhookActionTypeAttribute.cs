namespace Octokit.Webhooks;

[AttributeUsage(AttributeTargets.Class)]
internal sealed class WebhookActionTypeAttribute(string actionType) : Attribute
{
    public string ActionType { get; } = actionType;
}
