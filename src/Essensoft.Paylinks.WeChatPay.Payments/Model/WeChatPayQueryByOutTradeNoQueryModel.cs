using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Model;

public class WeChatPayQueryByOutTradeNoQueryModel
{
    /// <summary>
    /// 直连商户号
    /// </summary>
    [JsonPropertyName("mchid")]
    public string MchId { get; set; }
}
