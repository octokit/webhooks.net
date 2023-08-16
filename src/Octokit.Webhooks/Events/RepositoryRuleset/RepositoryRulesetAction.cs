namespace Octokit.Webhooks.Events.RepositoryRuleset;

public sealed record RepositoryRulesetAction : WebhookEventAction
{
    public static readonly RepositoryRulesetAction Created = new(RepositoryRulesetActionValue.Created);

    public static readonly RepositoryRulesetAction Deleted = new(RepositoryRulesetActionValue.Deleted);

    public static readonly RepositoryRulesetAction Edited = new(RepositoryRulesetActionValue.Edited);

    private RepositoryRulesetAction(string value)
        : base(value)
    {
    }
}
