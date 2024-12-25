using System.Text.Json.Serialization;
using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Domain;

namespace Essensoft.Paylinks.WeChatPay.Payments.Notify;

/// <summary>
/// 支付成功通知
/// </summary>
/// <para>
/// https://pay.weixin.qq.com/docs/merchant/apis/jsapi-payment/payment-notice.html
/// 支付通知
/// 更新时间：2023.08.16
/// </para>
public class WeChatPayTransactionSuccessNotify : IWeChatPayNotifyResource
{
    /// <summary>
    /// 支付成功通知
    /// </summary>
    public const string EventType = "TRANSACTION.SUCCESS";

    /// <summary>
    /// 直连商户申请的公众号或移动应用AppID。
    /// </summary>
    [JsonPropertyName("appid")]
    public string AppId { get; set; }

    /// <summary>
    /// 商户的商户号，由微信支付生成并下发。
    /// </summary>
    [JsonPropertyName("mchid")]
    public string MchId { get; set; }

    /// <summary>
    /// 商户系统内部订单号，可以是数字、大小写字母_-*的任意组合且在同一个商户号下唯一。
    /// </summary>
    [JsonPropertyName("out_trade_no")]
    public string OutTradeNo { get; set; }

    /// <summary>
    /// 微信支付系统生成的订单号。
    /// </summary>
    [JsonPropertyName("transaction_id")]
    public string TransactionId { get; set; }

    /// <summary>
    /// 交易类型
    /// </summary>
    [JsonPropertyName("trade_type")]
    public string TradeType { get; set; }

    /// <summary>
    /// 交易状态
    /// </summary>
    [JsonPropertyName("trade_state")]
    public string TradeState { get; set; }

    /// <summary>
    /// 交易状态描述。
    /// </summary>
    [JsonPropertyName("trade_state_desc")]
    public string TradeStateDesc { get; set; }

    /// <summary>
    /// 银行类型
    /// </summary>
    [JsonPropertyName("bank_type")]
    public string? BankType { get; set; }

    /// <summary>
    /// 附加数据
    /// </summary>
    [JsonPropertyName("attach")]
    public string? Attach { get; set; }

    /// <summary>
    /// 支付完成时间
    /// </summary>
    [JsonPropertyName("success_time")]
    public DateTimeOffset? SuccessTime { get; set; }

    /// <summary>
    /// 支付者。
    /// </summary>
    [JsonPropertyName("payer")]
    public EventPayer Payer { get; set; }

    /// <summary>
    /// 订单金额
    /// </summary>
    [JsonPropertyName("amount")]
    public EventAmount Amount { get; set; }

    /// <summary>
    /// 场景信息
    /// </summary>
    [JsonPropertyName("scene_info")]
    public EventSceneInfo? SceneInfo { get; set; }

    /// <summary>
    /// 优惠功能
    /// </summary>
    [JsonPropertyName("promotion_detail")]
    public List<PromotionDetail>? PromotionDetail { get; set; }
}
