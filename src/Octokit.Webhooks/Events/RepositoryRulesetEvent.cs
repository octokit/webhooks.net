using Octokit.Webhooks.Models.RepositoryRulesetEvent;

namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.RepositoryRuleset)]
[JsonConverter(typeof(WebhookConverter<RepositoryRulesetEvent>))]
public abstract record RepositoryRulesetEvent : WebhookEvent
{
    [JsonPropertyName("repository_ruleset")]
    public Models.RepositoryRulesetEvent.RepositoryRuleset? RepositoryRuleset { get; init; }
}
