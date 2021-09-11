namespace JamieMagee.Octokit.Webhooks
{
    public abstract class WebhookEventAction
    {
        private readonly string value;

        private protected WebhookEventAction(string value) => this.value = value;

        public static implicit operator string(WebhookEventAction action) => action.value;
    }
}
