using System.Text.Json.Serialization;
using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Domain;

namespace Essensoft.Paylinks.WeChatPay.Payments.Response;

public class WeChatPayCombineQueryByCombineOutTradeNoResponse : WeChatPayResponse
{
    /// <summary>
    /// 合单商户Appid
    /// </summary>
    [JsonPropertyName("combine_appid")]
    public string CombineAppId { get; set; }

    /// <summary>
    /// 合单商户号
    /// </summary>
    [JsonPropertyName("combine_mchid")]
    public string CombineMchId { get; set; }

    /// <summary>
    /// 合单支付者
    /// </summary>
    [JsonPropertyName("combine_payer_info")]
    public PayerInfo CombinePayerInfo { get; set; }

    /// <summary>
    /// 子单信息
    /// </summary>
    [JsonPropertyName("sub_orders")]
    public List<RespSubOrderCompatible>? SubOrders { get; set; }

    /// <summary>
    /// 场景信息
    /// </summary>
    [JsonPropertyName("scene_info")]
    public RespSceneInfo? SceneInfo { get; set; }

    /// <summary>
    /// 合单商户订单号
    /// </summary>
    [JsonPropertyName("combine_out_trade_no")]
    public string CombineOutTradeNo { get; set; }
}
