﻿namespace Octokit.Webhooks.Models;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum DiscussionState
{
    [EnumMember(Value = "open")]
    Open,
    [EnumMember(Value = "locked")]
    Locked,
    [EnumMember(Value = "converting")]
    Converting,
}
