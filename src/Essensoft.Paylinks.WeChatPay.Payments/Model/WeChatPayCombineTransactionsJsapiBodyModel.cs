using System.Text.Json.Serialization;
using Essensoft.Paylinks.WeChatPay.Payments.Domain;

namespace Essensoft.Paylinks.WeChatPay.Payments.Model;

[Obsolete("Use WeChatPayCombineTransactionsJsapiBodyModel")]
public class WeChatPayCombineJsapiPrepayBodyModel : WeChatPayCombineTransactionsJsapiBodyModel;

public class WeChatPayCombineTransactionsJsapiBodyModel
{
    /// <summary>
    /// 合单商户公众账号ID
    /// </summary>
    [JsonPropertyName("combine_appid")]
    public string CombineAppId { get; set; }

    /// <summary>
    /// 合单商户订单号
    /// </summary>
    [JsonPropertyName("combine_out_trade_no")]
    public string CombineOutTradeNo { get; set; }

    /// <summary>
    /// 合单商户号
    /// </summary>
    [JsonPropertyName("combine_mchid")]
    public string CombineMchId { get; set; }

    /// <summary>
    /// 场景信息
    /// </summary>
    [JsonPropertyName("scene_info")]
    public ReqSceneInfo? SceneInfo { get; set; }

    /// <summary>
    /// 子单信息
    /// </summary>
    [JsonPropertyName("sub_orders")]
    public List<ReqSubOrderCompatible> SubOrders { get; set; }

    /// <summary>
    /// 合单支付者信息
    /// </summary>
    [JsonPropertyName("combine_payer_info")]
    public ReqPayerInfo CombinePayerInfo { get; set; }

    /// <summary>
    /// 交易结束时间
    /// </summary>
    [JsonPropertyName("time_expire")]
    public DateTimeOffset? TimeExpire { get; set; }

    /// <summary>
    /// 通知地址
    /// </summary>
    [JsonPropertyName("notify_url")]
    public string NotifyUrl { get; set; }
}
