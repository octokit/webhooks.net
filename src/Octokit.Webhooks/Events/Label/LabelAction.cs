namespace Octokit.Webhooks.Events.Label;

using JetBrains.Annotations;

[PublicAPI]
public sealed record LabelAction : WebhookEventAction
{
    public static readonly LabelAction Created = new(LabelActionValue.Created);

    public static readonly LabelAction Deleted = new(LabelActionValue.Deleted);

    public static readonly LabelAction Edited = new(LabelActionValue.Edited);

    private LabelAction(string value)
        : base(value)
    {
    }
}