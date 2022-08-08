namespace Octokit.Webhooks.Events.MergeGroup;

using JetBrains.Annotations;

[PublicAPI]
public sealed record MergeGroupAction : WebhookEventAction
{
    public static readonly MergeGroupAction ChecksRequested = new(MergeGroupActionValue.ChecksRequested);

    private MergeGroupAction(string value)
        : base(value)
    {
    }
}
