namespace Octokit.Webhooks.Events.CustomProperty;

[PublicAPI]
public sealed record CustomPropertyAction : WebhookEventAction
{
    public static readonly CustomPropertyAction Created = new(CustomPropertyActionValue.Created);

    public static readonly CustomPropertyAction Updated = new(CustomPropertyActionValue.Updated);

    public static readonly CustomPropertyAction Deleted = new(CustomPropertyActionValue.Deleted);

    private CustomPropertyAction(string value)
        : base(value)
    {
    }
}
