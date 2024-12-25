using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

/// <summary>
/// 订单金额信息
/// </summary>
public class RespAmount
{
    /// <summary>
    /// 总金额
    /// </summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }

    /// <summary>
    /// 用户支付金额
    /// </summary>
    [JsonPropertyName("payer_total")]
    public int? PayerTotal { get; set; }

    /// <summary>
    /// 货币类型
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <summary>
    /// 用户支付货币类型
    /// </summary>
    [JsonPropertyName("payer_currency")]
    public string? PayerCurrency { get; set; }
}
