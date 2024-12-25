using System.Text.Json.Serialization;
using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Domain;

namespace Essensoft.Paylinks.WeChatPay.Payments.Response;

public class WeChatPayRefundResponse : WeChatPayResponse
{
    /// <summary>
    /// 微信支付退款号
    /// </summary>
    [JsonPropertyName("refund_id")]
    public string RefundId { get; set; }

    /// <summary>
    /// 商户退款单号
    /// </summary>
    [JsonPropertyName("out_refund_no")]
    public string OutRefundNo { get; set; }

    /// <summary>
    /// 微信支付订单号
    /// </summary>
    [JsonPropertyName("transaction_id")]
    public string TransactionId { get; set; }

    /// <summary>
    /// 商户订单号
    /// </summary>
    [JsonPropertyName("out_trade_no")]
    public string OutTradeNo { get; set; }

    /// <summary>
    /// 退款渠道
    /// </summary>
    [JsonPropertyName("channel")]
    public string Channel { get; set; }

    /// <summary>
    /// 退款入账账户
    /// </summary>
    [JsonPropertyName("user_received_account")]
    public string UserReceivedAccount { get; set; }

    /// <summary>
    /// 退款成功时间
    /// </summary>
    [JsonPropertyName("success_time")]
    public DateTimeOffset? SuccessTime { get; set; }

    /// <summary>
    /// 退款创建时间
    /// </summary>
    [JsonPropertyName("create_time")]
    public DateTimeOffset CreateTime { get; set; }

    /// <summary>
    /// 退款状态
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }

    /// <summary>
    /// 资金账户
    /// </summary>
    [JsonPropertyName("funds_account")]
    public string? FundsAccount { get; set; }

    /// <summary>
    /// 金额信息
    /// </summary>
    [JsonPropertyName("amount")]
    public RefundRespAmount Amount { get; set; }

    /// <summary>
    /// 优惠退款信息
    /// </summary>
    [JsonPropertyName("promotion_detail")]
    public List<RefundRespPromotionDetail>? PromotionDetail { get; set; }
}
