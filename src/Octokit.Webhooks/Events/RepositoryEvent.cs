namespace Octokit.Webhooks.Events;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;

[PublicAPI]
[WebhookEventType(WebhookEventType.Repository)]
[JsonConverter(typeof(WebhookConverter<RepositoryEvent>))]
public abstract record RepositoryEvent : WebhookEvent;
