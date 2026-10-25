namespace Octokit.Webhooks.Converter;

using System.Text.Json.Serialization.Metadata;

/// <summary>
/// Allows the concrete payload type of a webhook event to be resolved before it is deserialized, so that
/// a payload can be deserialized in a single pass rather than once to find the action and again for the payload.
/// </summary>
internal interface IWebhookConverter
{
    /// <summary>
    /// Resolves the <see cref="JsonTypeInfo"/> for the concrete payload type of the specified UTF-8 JSON payload.
    /// </summary>
    /// <param name="utf8Json">The UTF-8 encoded JSON payload.</param>
    /// <param name="options">The serializer options the payload will be deserialized with.</param>
    /// <returns>
    /// The <see cref="JsonTypeInfo"/> for the concrete payload type, or <see langword="null"/> if it cannot be resolved, in which case
    /// the payload should be deserialized with the type info for the event type so that the converter reports the problem.
    /// </returns>
    public JsonTypeInfo? ResolvePayloadTypeInfo(ReadOnlySpan<byte> utf8Json, JsonSerializerOptions options);
}
