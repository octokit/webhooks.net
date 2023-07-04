namespace Octokit.Webhooks;

[PublicAPI]
public abstract record WebhookEventAction
{
    private readonly string value;

    protected WebhookEventAction(string value) => this.value = value;

    public static implicit operator string(WebhookEventAction action) => action.value;
}
