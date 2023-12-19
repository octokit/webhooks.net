namespace Octokit.Webhooks.Events.CustomPropertyValues;

[PublicAPI]
public sealed record CustomPropertyValuesAction : WebhookEventAction
{
    public static readonly CustomPropertyValuesAction Updated = new(CustomPropertyValuesActionValue.Updated);

    private CustomPropertyValuesAction(string value)
        : base(value)
    {
    }
}
