using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

public class ReqAmountInfo
{
    /// <summary>
    /// 标价金额
    /// </summary>
    [JsonPropertyName("total_amount")]
    public int TotalAmount { get; set; }

    /// <summary>
    /// 标价币种
    /// </summary>
    [JsonPropertyName("currency")]
    public string Currency { get; set; }
}
