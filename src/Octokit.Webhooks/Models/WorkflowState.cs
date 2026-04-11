namespace Octokit.Webhooks.Models;

[PublicAPI]
public enum WorkflowState
{
    [EnumMember(Value = "active")]
    Active,
    [EnumMember(Value = "deleted")]
    Deleted,
    [EnumMember(Value = "disabled_fork")]
    DisabledFork,
    [EnumMember(Value = "disabled_inactivity")]
    DisabledInactivity,
    [EnumMember(Value = "disabled_manually")]
    DisabledManually,
}
