using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Model;

public class WeChatPayQueryByOutTradeNoQueryModel
{
    /// <summary>
    /// 商户号
    /// </summary>
    [JsonPropertyName("mchid")]
    public string MchId { get; set; }
}
