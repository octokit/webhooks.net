namespace System.Text.Json.Serialization;

public sealed class JsonStringEnumMemberConverterWithFallback : JsonStringEnumMemberConverter
{
    private static readonly JsonStringEnumMemberConverterOptions Options = new()
    {
        DeserializationFailureFallbackValue = -1, // By convention, we use -1 to represent unknown values in all enums.
    };

    public JsonStringEnumMemberConverterWithFallback()
        : base(Options)
    {
    }
}
