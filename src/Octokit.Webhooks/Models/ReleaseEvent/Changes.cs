﻿namespace Octokit.Webhooks.Models.ReleaseEvent;

[PublicAPI]
public sealed record Changes
{
    [JsonPropertyName("name")]
    public ChangesName? Name { get; init; }

    [JsonPropertyName("body")]
    public ChangesBody? Body { get; init; }
}
