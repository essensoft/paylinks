using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.Alipay.Payments.Model;

public class AlipayTradeCancelBodyModel
{
    /// <summary>
    /// 原支付请求的商户订单号,和支付宝交易号不能同时为空
    /// </summary>
    [JsonPropertyName("out_trade_no")]
    public string? OutTradeNo { get; set; }

    /// <summary>
    /// 支付宝交易号，和商户订单号不能同时为空
    /// </summary>
    [JsonPropertyName("trade_no")]
    public string? TradeNo { get; set; }
}
