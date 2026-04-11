namespace Octokit.Webhooks.Events.ProjectsV2StatusUpdate;

[PublicAPI]
public sealed record ProjectsV2StatusUpdateAction : WebhookEventAction
{
    public static readonly ProjectsV2StatusUpdateAction Created = new(ProjectsV2StatusUpdateActionValue.Created);

    public static readonly ProjectsV2StatusUpdateAction Deleted = new(ProjectsV2StatusUpdateActionValue.Deleted);

    public static readonly ProjectsV2StatusUpdateAction Edited = new(ProjectsV2StatusUpdateActionValue.Edited);

    private ProjectsV2StatusUpdateAction(string value)
        : base(value)
    {
    }
}
