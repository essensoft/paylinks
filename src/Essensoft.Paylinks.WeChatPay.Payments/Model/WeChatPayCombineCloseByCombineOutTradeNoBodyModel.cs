using System.Text.Json.Serialization;
using Essensoft.Paylinks.WeChatPay.Payments.Domain;

namespace Essensoft.Paylinks.WeChatPay.Payments.Model;

public class WeChatPayCombineCloseByCombineOutTradeNoBodyModel
{
    /// <summary>
    /// 合单Appid
    /// </summary>
    [JsonPropertyName("combine_appid")]
    public string CombineAppid { get; set; }

    /// <summary>
    /// 子单信息
    /// </summary>
    [JsonPropertyName("sub_orders")]
    public List<ReqCloseSubOrder>? SubOrders { get; set; }
}
