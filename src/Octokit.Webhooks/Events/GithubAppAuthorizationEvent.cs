namespace Octokit.Webhooks.Events;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;

[PublicAPI]
[WebhookEventType(WebhookEventType.GithubAppAuthorization)]
[JsonConverter(typeof(WebhookConverter<GithubAppAuthorizationEvent>))]
public abstract record GithubAppAuthorizationEvent : WebhookEvent;
