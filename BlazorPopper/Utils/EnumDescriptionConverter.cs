﻿using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorPopper.Utils;

public class EnumDescriptionConverter<T> : JsonConverter<T> where T : IComparable, IFormattable, IConvertible
{
    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        FieldInfo? fi = value.GetType().GetField(value.ToString()!);
        if (fi == null) return;
        var description = (DescriptionAttribute?)fi.GetCustomAttribute(typeof(DescriptionAttribute), false);
        writer.WriteStringValue(description?.Description);
    }
}
