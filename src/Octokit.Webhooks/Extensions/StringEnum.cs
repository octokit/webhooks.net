namespace Octokit.Webhooks.Extensions;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record StringEnum<TEnum> : IEquatable<StringEnum<TEnum>>
    where TEnum : struct, Enum
{
    private readonly TEnum? parsedValue;
    private readonly bool isValidEnum;

    public StringEnum(string stringValue)
    {
        this.StringValue = stringValue;
        if (TryParseEnum(stringValue, out var enumValue))
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
        if (!Enum.IsDefined(parsedValue))
        {
            _ = ThrowArgumentException(parsedValue.ToString());
        }

        this.StringValue = ToEnumString(parsedValue);
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
        var canParseThis = this.TryParse(out var thisValue);

        TEnum? otherValue = null;
        var canParseOther = other != null && other.TryParse(out otherValue);

        return canParseThis switch
        {
            // If both can be parsed to enum values, compare the enum values
            true when canParseOther => thisValue.Equals(otherValue),

            // If neither can be parsed, compare string values
            false when !canParseOther => this.StringValue.Equals(other?.StringValue, StringComparison.OrdinalIgnoreCase),

            // If one can parse and one cannot, they're not equal
            _ => false,
        };
    }

    public override int GetHashCode() =>

        // Use enum value for hash code if it can be parsed, otherwise use string value
        this.TryParse(out var value) ? value.GetHashCode() : StringComparer.OrdinalIgnoreCase.GetHashCode(this.StringValue);

    public override string ToString() => this.StringValue;

    private static bool TryParseEnum(string str, [NotNullWhen(true)] out TEnum? value)
    {
        try
        {
            value = ToEnum(str);
            return true;
        }
        catch (ArgumentException)
        {
            value = null;
            return false;
        }
    }

    [DoesNotReturn]
    private static TEnum ThrowArgumentException(string? value) => throw new ArgumentException(string.Format(
        CultureInfo.InvariantCulture,
        "Value '{0}' is not a valid '{1}' enum value.",
        value,
        typeof(TEnum).Name));

    private static string ToEnumString(TEnum type)
    {
        var enumType = typeof(TEnum);
        var name = Enum.GetName(enumType, type) ?? throw new ArgumentException(type.ToString());

        var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name)!.GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
        return enumMemberAttribute.Value!;
    }

    private static TEnum ToEnum(string str)
    {
        var enumType = typeof(TEnum);
        foreach (var name in Enum.GetNames(enumType))
        {
            var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name)!.GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
            if (enumMemberAttribute.Value == str)
            {
                return (TEnum)Enum.Parse(enumType, name);
            }
        }

        return ThrowArgumentException(str);
    }
}
