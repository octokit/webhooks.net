﻿namespace Octokit.Webhooks.Models.GollumEvent;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum PageAction
{
    [EnumMember(Value = "created")]
    Created,
    [EnumMember(Value = "edited")]
    Edited,
}
