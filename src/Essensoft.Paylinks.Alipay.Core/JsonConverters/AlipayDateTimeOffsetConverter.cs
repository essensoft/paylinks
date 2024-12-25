using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.Alipay.Core.JsonConverters;

public class AlipayDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
{
    private const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (!reader.TryGetDateTimeOffset(out var value))
        {
            value = DateTimeOffset.ParseExact(reader.GetString()!, DateTimeFormat, CultureInfo.InvariantCulture);
        }

        return value;
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(DateTimeFormat));
    }
}
