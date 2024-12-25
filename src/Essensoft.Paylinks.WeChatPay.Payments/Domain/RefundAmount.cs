using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

public class RefundAmount
{
    /// <summary>
    /// 退款金额
    /// </summary>
    [JsonPropertyName("refund")]
    public int Refund { get; set; }

    /// <summary>
    /// 退款出资账户及金额
    /// </summary>
    [JsonPropertyName("from")]
    public List<FundsFromItem>? From { get; set; }

    /// <summary>
    /// 原订单金额
    /// </summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }

    /// <summary>
    /// 退款币种
    /// </summary>
    [JsonPropertyName("currency")]
    public string Currency { get; set; }
}
