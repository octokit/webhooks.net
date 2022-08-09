namespace Octokit.Webhooks.Events.MergeGroup;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(MergeGroupActionValue.ChecksRequested)]
public sealed record MergeGroupChecksRequestedEvent : MergeGroupEvent
{
    [JsonPropertyName("action")]
    public override string Action => MergeGroupAction.ChecksRequested;
}
