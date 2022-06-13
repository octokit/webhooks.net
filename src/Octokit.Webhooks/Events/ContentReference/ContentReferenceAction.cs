namespace Octokit.Webhooks.Events.ContentReference;

using JetBrains.Annotations;

[PublicAPI]
public sealed record ContentReferenceAction : WebhookEventAction
{
    public static readonly ContentReferenceAction Created = new(ContentReferenceActionValue.Created);

    private ContentReferenceAction(string value)
        : base(value)
    {
    }
}