using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

public class RespSubOrderCompatible
{
    /// <summary>
    /// 子单商户号
    /// </summary>
    [JsonPropertyName("mchid")]
    public string MchId { get; set; }

    /// <summary>
    /// 交易类型
    /// </summary>
    [JsonPropertyName("trade_type")]
    public string? TradeType { get; set; }

    /// <summary>
    /// 交易状态
    /// </summary>
    [JsonPropertyName("trade_state")]
    public string TradeState { get; set; }

    /// <summary>
    /// 付款银行
    /// </summary>
    [JsonPropertyName("bank_type")]
    public string? BankType { get; set; }

    /// <summary>
    /// 附加数据
    /// </summary>
    [JsonPropertyName("attach")]
    public string? Attach { get; set; }

    /// <summary>
    /// 支付完成时间。
    /// </summary>
    [JsonPropertyName("success_time")]
    public DateTimeOffset? SuccessTime { get; set; }

    /// <summary>
    /// 订单金额
    /// </summary>
    [JsonPropertyName("amount")]
    public AmountInfo Amount { get; set; }

    /// <summary>
    /// 微信支付订单号
    /// </summary>
    [JsonPropertyName("transaction_id")]
    public string TransactionId { get; set; }

    /// <summary>
    /// 子单商户订单号
    /// </summary>
    [JsonPropertyName("out_trade_no")]
    public string OutTradeNo { get; set; }

    /// <summary>
    /// 优惠退款信息
    /// </summary>
    [JsonPropertyName("promotion_detail")]
    public List<PromotionDetail>? PromotionDetail { get; set; }
}
