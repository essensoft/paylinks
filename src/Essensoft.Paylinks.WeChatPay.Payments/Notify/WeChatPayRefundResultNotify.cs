using System.Text.Json.Serialization;
using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Domain;

namespace Essensoft.Paylinks.WeChatPay.Payments.Notify;

/// <summary>
/// 退款结果回调通知
/// </summary>
/// <para>
/// 退款结果回调通知 - 更新时间：2025.01.02
/// https://pay.weixin.qq.com/doc/v3/merchant/4012791865
/// 退款结果回调通知 - 更新时间：2025.01.08
/// https://pay.weixin.qq.com/doc/v3/merchant/4012085921
/// </para>
public class WeChatPayRefundResultNotify : IWeChatPayNotifyResource
{
    /// <summary>
    /// 直连商户的商户号，由微信支付生成并下发。
    /// </summary>
    [JsonPropertyName("mchid")]
    public string MchId { get; set; }

    /// <summary>
    /// 返回的商户订单号
    /// </summary>
    [JsonPropertyName("out_trade_no")]
    public string OutTradeNo { get; set; }

    /// <summary>
    /// 微信支付订单号
    /// </summary>
    [JsonPropertyName("transaction_id")]
    public string TransactionId { get; set; }

    /// <summary>
    /// 商户退款单号
    /// </summary>
    [JsonPropertyName("out_refund_no")]
    public string OutRefundNo { get; set; }

    /// <summary>
    /// 微信退款单号
    /// </summary>
    [JsonPropertyName("refund_id")]
    public string RefundId { get; set; }

    /// <summary>
    /// 退款状态
    /// </summary>
    [JsonPropertyName("refund_status")]
    public string RefundStatus { get; set; }

    /// <summary>
    /// 退款成功时间
    /// </summary>
    [JsonPropertyName("success_time")]
    public DateTimeOffset? SuccessTime { get; set; }

    /// <summary>
    /// 取当前退款单的退款入账方。
    /// </summary>
    [JsonPropertyName("user_received_account")]
    public string UserReceivedAccount { get; set; }

    /// <summary>
    /// 订单金额
    /// </summary>
    [JsonPropertyName("amount")]
    public RefundSuccessEventAmount Amount { get; set; }
}
