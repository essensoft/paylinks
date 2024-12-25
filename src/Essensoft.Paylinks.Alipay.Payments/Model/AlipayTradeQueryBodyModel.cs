using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.Alipay.Payments.Model;

public class AlipayTradeQueryBodyModel
{
    /// <summary>
    /// 订单支付时传入的商户订单号,和支付宝交易号不能同时为空。
    /// trade_no,out_trade_no如果同时存在优先取trade_no
    /// </summary>
    [JsonPropertyName("out_trade_no")]
    public string? OutTradeNo { get; set; }

    /// <summary>
    /// 支付宝交易号，和商户订单号不能同时为空
    /// </summary>
    [JsonPropertyName("trade_no")]
    public string? TradeNo { get; set; }

    /// <summary>
    /// 查询选项，商户通过上送该参数来定制同步需要额外返回的信息字段，数组格式。
    /// </summary>
    [JsonPropertyName("query_options")]
    public List<string>? QueryOptions { get; set; }
}
