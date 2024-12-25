using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Core.JsonConverters;

public class WeChatPayDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
{
    /// <summary>
    /// 示例值：2018-06-08T10:34:56+08:00
    /// </summary>
    private const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ssK";

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
