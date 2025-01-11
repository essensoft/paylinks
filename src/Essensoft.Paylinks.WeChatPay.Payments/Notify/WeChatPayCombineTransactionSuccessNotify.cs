using System.Text.Json.Serialization;
using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Domain;

namespace Essensoft.Paylinks.WeChatPay.Payments.Notify;

/// <summary>
/// 合单订单支付成功回调通知
/// </summary>
/// <para>
/// 合单订单支付成功回调通知 - 更新时间：2025.01.08
/// https://pay.weixin.qq.com/doc/v3/merchant/4012158598
/// </para>
public class WeChatPayCombineTransactionSuccessNotify : IWeChatPayNotifyResource
{
    /// <summary>
    /// 合单发起方的AppID
    /// </summary>
    [JsonPropertyName("combine_appid")]
    public string CombineAppId { get; set; }

    /// <summary>
    /// 合单发起方商户号
    /// </summary>
    [JsonPropertyName("combine_mchid")]
    public string CombineMchId { get; set; }

    /// <summary>
    /// 合单支付总订单号
    /// </summary>
    [JsonPropertyName("combine_out_trade_no")]
    public string CombineOutTradeNo { get; set; }

    /// <summary>
    /// 场景信息
    /// </summary>
    [JsonPropertyName("scene_info")]
    public EventCombineSceneInfo? SceneInfo { get; set; }

    /// <summary>
    /// 子单信息
    /// </summary>
    [JsonPropertyName("sub_orders")]
    public List<EventSubOrder> SubOrders { get; set; }

    /// <summary>
    /// 支付者
    /// </summary>
    [JsonPropertyName("combine_payer_info")]
    public PayerInfo CombinePayerInfo { get; set; }
}
