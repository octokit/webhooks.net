namespace Octokit.Webhooks.Events.Team;

using JetBrains.Annotations;

[PublicAPI]
public sealed record TeamAction : WebhookEventAction
{
    public static readonly TeamAction AddedToRepository = new(TeamActionValue.AddedToRepository);

    public static readonly TeamAction Created = new(TeamActionValue.Created);

    public static readonly TeamAction Deleted = new(TeamActionValue.Deleted);

    public static readonly TeamAction Edited = new(TeamActionValue.Edited);

    public static readonly TeamAction RemovedFromRepository = new(TeamActionValue.RemovedFromRepository);

    private TeamAction(string value)
        : base(value)
    {
    }
}
