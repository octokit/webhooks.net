namespace System.Text.Json.Serialization;

public sealed class JsonStringEnumMemberConverterWithFallback : JsonStringEnumMemberConverter
{
    private static readonly JsonStringEnumMemberConverterOptions Options = new()
    {
        DeserializationFailureFallbackValue = 0,
    };

    public JsonStringEnumMemberConverterWithFallback()
        : base(Options)
    {
    }
}
