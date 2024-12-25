using System.Text.Json.Serialization;
using Essensoft.Paylinks.WeChatPay.Payments.Domain;

namespace Essensoft.Paylinks.WeChatPay.Payments.Model;

public class WeChatPayRefundBodyModel
{
    /// <summary>
    /// 微信支付订单号
    /// </summary>
    [JsonPropertyName("transaction_id")]
    public string? TransactionId { get; set; }

    /// <summary>
    /// 商户订单号
    /// </summary>
    [JsonPropertyName("out_trade_no")]
    public string? OutTradeNo { get; set; }

    /// <summary>
    /// 商户退款单号
    /// </summary>
    [JsonPropertyName("out_refund_no")]
    public string OutRefundNo { get; set; }

    /// <summary>
    /// 退款原因
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    /// <summary>
    /// 退款结果回调url
    /// </summary>
    [JsonPropertyName("notify_url")]
    public string? NotifyUrl { get; set; }

    /// <summary>
    /// 退款资金来源
    /// </summary>
    [JsonPropertyName("funds_account")]
    public string? FundsAccount { get; set; }

    /// <summary>
    /// 金额信息
    /// </summary>
    [JsonPropertyName("amount")]
    public RefundAmount Amount { get; set; }

    /// <summary>
    /// 退款商品
    /// </summary>
    [JsonPropertyName("goods_detail")]
    public List<RefundGoodsDetail>? GoodsDetail { get; set; }
}
