using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using Essensoft.Paylinks.WeChatPay.Core.JsonConverters;

namespace Essensoft.Paylinks.WeChatPay.Core;

public static class WeChatPayJsonSerializerOptions
{
    public static readonly JsonSerializerOptions Default = new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        AllowTrailingCommas = true,
        Converters = { new WeChatPayDateTimeOffsetConverter() }
    };
}
