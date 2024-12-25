using System.Text.Json.Serialization;
using Essensoft.Paylinks.Alipay.Core;

namespace Essensoft.Paylinks.Alipay.Payments.Response;

public class AlipayTradeCloseResponse : AlipayResponse
{
    /// <summary>
    /// 支付宝交易号
    /// </summary>
    [JsonPropertyName("trade_no")]
    public string? TradeNo { get; set; }

    /// <summary>
    /// 创建交易传入的商户订单号
    /// </summary>
    [JsonPropertyName("out_trade_no")]
    public string? OutTradeNo { get; set; }
}
