namespace Octokit.Webhooks.Extensions;

using System;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed class StringEnum<TEnum> : IEquatable<StringEnum<TEnum>>
    where TEnum : struct
{
    private TEnum? parsedValue;

    public StringEnum(string stringValue)
    {
        this.StringValue = stringValue;
        this.parsedValue = null;
    }

    public StringEnum(TEnum parsedValue)
    {
        if (!Enum.IsDefined(typeof(TEnum), parsedValue))
        {
            throw GetArgumentException(parsedValue.ToString());
        }

        this.StringValue = ToEnumString(parsedValue);
        this.parsedValue = parsedValue;
    }

    public string StringValue { get; }

    public TEnum Value => this.parsedValue ??= this.ParseValue();

    public static implicit operator StringEnum<TEnum>(string value) => new(value);

    public static implicit operator StringEnum<TEnum>(TEnum parsedValue) => new(parsedValue);

    public static bool operator ==(StringEnum<TEnum>? left, StringEnum<TEnum>? right)
    {
        if (ReferenceEquals(left, right))
        {
            return true;
        }

        if (left is null || right is null)
        {
            return false;
        }

        return left.Equals(right);
    }

    public static bool operator !=(StringEnum<TEnum>? left, StringEnum<TEnum>? right) => !(left == right);

    public bool TryParse(out TEnum value)
    {
        if (this.parsedValue is not null)
        {
            value = this.parsedValue.Value;
            return true;
        }

        try
        {
            value = ToEnum(this.StringValue);
            this.parsedValue = value;
            return true;
        }
        catch (ArgumentException)
        {
            value = default;
            return false;
        }
    }

    public override bool Equals(object? obj) => this.Equals(obj as StringEnum<TEnum>);

    public bool Equals(StringEnum<TEnum>? other)
    {
        if (other is null)
        {
            return false;
        }

        var canParseThis = this.TryParse(out var thisValue);
        var canParseOther = other.TryParse(out var otherValue);

        // If both can be parsed to enum values, compare the enum values
        if (canParseThis && canParseOther)
        {
            return thisValue.Equals(otherValue);
        }

        // If neither can be parsed, compare string values
        if (!canParseThis && !canParseOther)
        {
            return this.StringValue.Equals(other.StringValue, StringComparison.OrdinalIgnoreCase);
        }

        // If one can parse and one cannot, they're not equal
        return false;
    }

    public override int GetHashCode()
    {
        // Use enum value for hash code if it can be parsed, otherwise use string value
        if (this.TryParse(out var value))
        {
            return value.GetHashCode();
        }

        return this.StringValue.GetHashCode();
    }

    public override string ToString() => this.StringValue;

    private static ArgumentException GetArgumentException(string? value) => new(string.Format(
        CultureInfo.InvariantCulture,
        "Value '{0}' is not a valid '{1}' enum value.",
        value,
        typeof(TEnum).Name));

    private static string ToEnumString(TEnum type)
    {
        var enumType = typeof(TEnum);
        var name = Enum.GetName(enumType, type);
        if (name is not null)
        {
            var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name)!.GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
            return enumMemberAttribute.Value!;
        }

        throw new ArgumentException(type.ToString());
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

        throw new ArgumentException(str);
    }

    private TEnum ParseValue()
    {
        if (this.TryParse(out var value))
        {
            return value;
        }

        throw GetArgumentException(this.StringValue);
    }
}
