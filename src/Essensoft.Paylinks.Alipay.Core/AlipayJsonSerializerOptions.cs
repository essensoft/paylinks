using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using Essensoft.Paylinks.Alipay.Core.JsonConverters;

namespace Essensoft.Paylinks.Alipay.Core;

public static class AlipayJsonSerializerOptions
{
    public static readonly JsonSerializerOptions Default = new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        AllowTrailingCommas = true,
        Converters = { new AlipayDateTimeOffsetConverter() }
    };
}
