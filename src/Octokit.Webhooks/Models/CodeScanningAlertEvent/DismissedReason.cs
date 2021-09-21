namespace Octokit.Webhooks.Models.CodeScanningAlertEvent
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum DismissedReason
    {
        [EnumMember(Value = "false positive")]
        FalsePositive,
        [EnumMember(Value = "won't fix")]
        WontFix,
        [EnumMember(Value = "used in tests")]
        UsedInTests,
    }
}
