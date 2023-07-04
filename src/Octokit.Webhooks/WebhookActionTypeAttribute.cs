namespace Octokit.Webhooks;

[PublicAPI]
[AttributeUsage(AttributeTargets.Class)]
public sealed class WebhookActionTypeAttribute : Attribute
{
    public WebhookActionTypeAttribute(string actionType) => this.ActionType = actionType;

    public string ActionType { get; }
}
