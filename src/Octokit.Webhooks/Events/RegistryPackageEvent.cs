namespace Octokit.Webhooks.Events;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;

[PublicAPI]
[WebhookEventType(WebhookEventType.RegistryPackage)]
[JsonConverter(typeof(WebhookConverter<RegistryPackageEvent>))]
public abstract record RegistryPackageEvent : WebhookEvent;
