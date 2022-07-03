namespace Octokit.Webhooks.Events;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;

[PublicAPI]
[WebhookEventType(WebhookEventType.Organization)]
[JsonConverter(typeof(WebhookConverter<OrganizationEvent>))]
public abstract record OrganizationEvent : WebhookEvent;
