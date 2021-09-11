namespace JamieMagee.Octokit.Webhooks.Events.ContentReference
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record ContentReferenceCreatedEvent : ContentReferenceEvent
    {
        [JsonPropertyName("action")]
        public override string Action => ContentReferenceAction.Created;
    }
}
