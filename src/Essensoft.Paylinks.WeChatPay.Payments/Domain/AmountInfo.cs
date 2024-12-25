using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

public class AmountInfo
{
    /// <summary>
    /// 标价金额
    /// </summary>
    [JsonPropertyName("total_amount")]
    public int TotalAmount { get; set; }

    /// <summary>
    /// 现金支付金额
    /// </summary>
    [JsonPropertyName("payer_amount")]
    public int PayerAmount { get; set; }

    /// <summary>
    /// 标价币种
    /// </summary>
    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    /// <summary>
    /// 现金支付币种
    /// </summary>
    [JsonPropertyName("payer_currency")]
    public string PayerCurrency { get; set; }

    /// <summary>
    /// 结算汇率
    /// </summary>
    [JsonPropertyName("settlement_rate")]
    public int? SettlementRate { get; set; }
}
