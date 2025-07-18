namespace Octokit.Webhooks.Extensions;

using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record StringEnum<TEnum>
    where TEnum : struct
{
    private static readonly ConcurrentDictionary<TEnum, string> EnumToStringCache = new();
    private static readonly ConcurrentDictionary<string, TEnum> StringToEnumCache = new();
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

    private static ArgumentException GetArgumentException(string? value) => new(string.Format(
        CultureInfo.InvariantCulture,
        "Value '{0}' is not a valid '{1}' enum value.",
        value,
        typeof(TEnum).Name));

    private TEnum ParseValue()
    {
        if (this.TryParse(out var value))
        {
            return value;
        }

        throw GetArgumentException(this.StringValue);
    }

    private static string ToEnumString(TEnum type) =>
        EnumToStringCache.GetOrAdd(type, static enumValue =>
        {
            var enumType = typeof(TEnum);
            var name = Enum.GetName(enumType, enumValue);
            if (name is not null)
            {
                var field = enumType.GetField(name)!;
                var enumMemberAttribute = field.GetCustomAttributes(typeof(EnumMemberAttribute), true)
                    .Cast<EnumMemberAttribute>()
                    .FirstOrDefault();

                if (enumMemberAttribute?.Value is not null)
                {
                    return enumMemberAttribute.Value;
                }
            }

            throw new ArgumentException($"Enum value '{enumValue}' does not have a valid EnumMemberAttribute");
        });

    private static TEnum ToEnum(string str) =>
        StringToEnumCache.GetOrAdd(str, static stringValue =>
        {
            var enumType = typeof(TEnum);
            foreach (var name in Enum.GetNames(enumType))
            {
                var field = enumType.GetField(name)!;
                var enumMemberAttribute = field.GetCustomAttributes(typeof(EnumMemberAttribute), true)
                    .Cast<EnumMemberAttribute>()
                    .FirstOrDefault();

                if (enumMemberAttribute?.Value == stringValue)
                {
                    return (TEnum)Enum.Parse(enumType, name);
                }
            }

            throw new ArgumentException($"String value '{stringValue}' is not a valid '{enumType.Name}' enum value");
        });
}
