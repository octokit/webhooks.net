# Octokit.Webhooks.SourceGenerator

This project is an internal source generator for Octokit.Webhooks.

It contains the following generators:

- `WebhookActionTypeGenerator` - generates the mapping of `action` values to the payload types decorated with `[WebhookActionType]`.
- `WebhookEventTypeGenerator` - generates the mapping of `X-GitHub-Event` values to the event types decorated with `[WebhookEventType]`.
- `InitOnlyPropertyGenerator` - generates accessors for the `init`-only properties of the models so that `System.Text.Json`
  deserializes them with its default object converter, rather than the slower path it uses for types whose properties it cannot set.
