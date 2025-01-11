using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Model;

public class WeChatPayReverseBodyModel
{
    /// <summary>
    /// 应用AppID。
    /// </summary>
    [JsonPropertyName("appid")]
    public string AppId { get; set; }

    /// <summary>
    /// 商户号。
    /// </summary>
    [JsonPropertyName("mchid")]
    public string MchId { get; set; }
}
