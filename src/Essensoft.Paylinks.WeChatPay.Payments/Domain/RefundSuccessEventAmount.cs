using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

public class RefundSuccessEventAmount
{
    /// <summary>，单位为分，只能为整数
    /// </summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }

    /// <summary>
    /// 退款金额，币种的最小单位，只能为整数，不能超过原订单支付金额，如果有使用券，后台会按比例退。
    /// </summary>
    [JsonPropertyName("refund")]
    public int Refund { get; set; }

    /// <summary>
    /// 用户实际支付金额，单位为分，只能为整数
    /// </summary>
    [JsonPropertyName("payer_total")]
    public int PayerTotal { get; set; }

    /// <summary>
    /// 退款给用户的金额，不包含所有优惠券金额
    /// </summary>
    [JsonPropertyName("payer_refund")]
    public int PayerRefund { get; set; }
}
