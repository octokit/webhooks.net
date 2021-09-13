namespace JamieMagee.Octokit.Webhooks.Events
{
    [WebhookEventType(WebhookEventType.WorkflowDispatch)]
    public sealed record WorkflowDispatchEvent : WebhookEvent
    {
        // TODO: special case
    }
}
