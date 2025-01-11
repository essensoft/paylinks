using System.Text.Json.Serialization;
using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Domain;

namespace Essensoft.Paylinks.WeChatPay.Payments.Response;

public class WeChatPayTransactionsCodePayResponse : WeChatPayResponse
{
    /// <summary>
    /// 应用AppID
    /// </summary>
    [JsonPropertyName("appid")]
    public string? AppId { get; set; }

    /// <summary>
    /// 商户号
    /// </summary>
    [JsonPropertyName("mchid")]
    public string MchId { get; set; }

    /// <summary>
    /// 商户订单号
    /// 商户系统内部订单号，只能是数字、大小写字母_-*且在同一个商户号下唯一
    /// </summary>
    [JsonPropertyName("out_trade_no")]
    public string OutTradeNo { get; set; }

    /// <summary>
    /// 微信支付订单号
    /// 微信支付系统生成的订单号。
    /// </summary>
    [JsonPropertyName("transaction_id")]
    public string? TransactionId { get; set; }

    /// <summary>
    /// 交易类型
    /// 交易类型，如下：
    /// * MICROPAY：付款码支付
    /// * FACEPAY：刷脸支付
    /// </summary>
    [JsonPropertyName("trade_type")]
    public string? TradeType { get; set; }

    /// <summary>
    /// 银行类型，采用字符串类型的银行标识。 银行标识请参考<a href="https://pay.weixin.qq.com/doc/v3/partner/4012082814" target="_blank">《银行类型对照表》</a>。
    /// </summary>
    [JsonPropertyName("bank_type")]
    public string? BankType { get; set; }

    /// <summary>
    /// 支付完成时间。
    /// </summary>
    [JsonPropertyName("success_time")]
    public DateTimeOffset? SuccessTime { get; set; }

    /// <summary>
    /// 交易状态，如下：
    /// * SUCCESS：支付成功
    /// * REFUND：转入退款
    /// * NOTPAY：未支付
    /// * REVOKED：已撤销
    /// * USERPAYING：用户支付中
    /// * PAYERROR：支付失败
    /// </summary>
    [JsonPropertyName("trade_state")]
    public string TradeState { get; set; }

    /// <summary>
    /// 交易状态描述。
    /// </summary>
    [JsonPropertyName("trade_state_desc")]
    public string? TradeStateDesc { get; set; }

    /// <summary>
    /// 附加数据，在返回消息和查单API中原样返回，可作为自定义参数使用，实际情况下只有支付完成状态才会返回该字段。
    /// </summary>
    [JsonPropertyName("attach")]
    public string? Attach { get; set; }

    /// <summary>
    /// 支付者。
    /// </summary>
    [JsonPropertyName("payer")]
    public RespPayer? Payer { get; set; }

    /// <summary>
    /// 订单金额
    /// </summary>
    [JsonPropertyName("amount")]
    public RespAmount? Amount { get; set; }

    /// <summary>
    /// 优惠信息
    /// </summary>
    [JsonPropertyName("promotion_detail")]
    public List<PromotionDetail>? PromotionDetail { get; set; }
}
