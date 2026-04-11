namespace Octokit.Webhooks.Events.PersonalAccessTokenRequest;

[PublicAPI]
public sealed record PersonalAccessTokenRequestAction : WebhookEventAction
{
    public static readonly PersonalAccessTokenRequestAction Approved = new(PersonalAccessTokenRequestActionValue.Approved);

    public static readonly PersonalAccessTokenRequestAction Cancelled = new(PersonalAccessTokenRequestActionValue.Cancelled);

    public static readonly PersonalAccessTokenRequestAction Created = new(PersonalAccessTokenRequestActionValue.Created);

    public static readonly PersonalAccessTokenRequestAction Denied = new(PersonalAccessTokenRequestActionValue.Denied);

    private PersonalAccessTokenRequestAction(string value)
        : base(value)
    {
    }
}
