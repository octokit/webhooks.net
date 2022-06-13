namespace Octokit.Webhooks.Events;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;

[PublicAPI]
[WebhookEventType(WebhookEventType.Watch)]
[JsonConverter(typeof(WebhookConverter<WatchEvent>))]
public abstract record WatchEvent : WebhookEvent;