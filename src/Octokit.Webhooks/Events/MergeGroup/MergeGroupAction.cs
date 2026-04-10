namespace Octokit.Webhooks.Events.MergeGroup;

[PublicAPI]
public sealed record MergeGroupAction : WebhookEventAction
{
    public static readonly MergeGroupAction ChecksRequested = new(MergeGroupActionValue.ChecksRequested);

    public static readonly MergeGroupAction Destroyed = new(MergeGroupActionValue.Destroyed);

    private MergeGroupAction(string value)
        : base(value)
    {
    }
}
