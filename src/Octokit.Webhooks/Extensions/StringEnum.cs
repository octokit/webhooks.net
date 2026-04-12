namespace Octokit.Webhooks.Extensions;

using System;
using System.Collections.Frozen;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record StringEnum<TEnum> : IEquatable<StringEnum<TEnum>>
    where TEnum : struct, Enum
{
    private static readonly FrozenDictionary<string, TEnum> StringToEnum = BuildStringToEnum();
    private static readonly FrozenDictionary<TEnum, string> EnumToString = BuildEnumToString();

    private readonly TEnum? parsedValue;
    private readonly bool isValidEnum;

    public StringEnum(string stringValue)
    {
        ArgumentNullException.ThrowIfNull(stringValue);
        this.StringValue = stringValue;
        if (StringToEnum.TryGetValue(stringValue, out var enumValue))
        {
            this.parsedValue = enumValue;
            this.isValidEnum = true;
        }
        else
        {
            this.parsedValue = null;
            this.isValidEnum = false;
        }
    }

    public StringEnum(TEnum parsedValue)
    {
        if (!EnumToString.TryGetValue(parsedValue, out var stringValue))
        {
            _ = ThrowArgumentException(parsedValue.ToString());
        }

        this.StringValue = stringValue!;
        this.parsedValue = parsedValue;
        this.isValidEnum = true;
    }

    public string StringValue { get; }

    public TEnum Value => this.parsedValue ?? ThrowArgumentException(this.StringValue);

    public static implicit operator StringEnum<TEnum>(string value) => new(value);

    public static implicit operator StringEnum<TEnum>(TEnum parsedValue) => new(parsedValue);

    public bool TryParse([NotNullWhen(true)] out TEnum? value)
    {
        if (this.isValidEnum && this.parsedValue is not null)
        {
            value = this.parsedValue.Value;
            return true;
        }

        value = null;
        return false;
    }

    public bool Equals(StringEnum<TEnum>? other)
    {
        if (ReferenceEquals(this, other))
        {
            return true;
        }

        var canParseThis = this.TryParse(out var thisValue);

        TEnum? otherValue = null;
        var canParseOther = other != null && other.TryParse(out otherValue);

        return canParseThis switch
        {
            // If both can be parsed to enum values, compare the enum values
            true when canParseOther => EqualityComparer<TEnum>.Default.Equals(thisValue!.Value, otherValue!.Value),

            // If neither can be parsed, compare string values
            false when !canParseOther => string.Equals(this.StringValue, other?.StringValue, StringComparison.OrdinalIgnoreCase),

            // If one can parse and one cannot, they're not equal
            _ => false,
        };
    }

    public override int GetHashCode() =>

        // Use enum value for hash code if it can be parsed, otherwise use string value
        this.TryParse(out var value) ? value.GetHashCode() : StringComparer.OrdinalIgnoreCase.GetHashCode(this.StringValue);

    public override string ToString() => this.StringValue;

    [DoesNotReturn]
    private static TEnum ThrowArgumentException(string? value) => throw new ArgumentException(
        $"Value '{value}' is not a valid '{typeof(TEnum).Name}' enum value.");

    private static FrozenDictionary<string, TEnum> BuildStringToEnum()
    {
        var enumType = typeof(TEnum);
        return Enum.GetNames(enumType)
            .ToFrozenDictionary(
                name => ((EnumMemberAttribute[])enumType.GetField(name)!.GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single().Value!,
                name => (TEnum)Enum.Parse(enumType, name));
    }

    private static FrozenDictionary<TEnum, string> BuildEnumToString()
    {
        var enumType = typeof(TEnum);
        return Enum.GetNames(enumType)
            .ToFrozenDictionary(
                name => (TEnum)Enum.Parse(enumType, name),
                name => ((EnumMemberAttribute[])enumType.GetField(name)!.GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single().Value!);
    }
}
