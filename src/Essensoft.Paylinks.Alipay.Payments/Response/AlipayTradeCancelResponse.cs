using System.Text.Json.Serialization;
using Essensoft.Paylinks.Alipay.Core;

namespace Essensoft.Paylinks.Alipay.Payments.Response;

public class AlipayTradeCancelResponse : AlipayResponse
{
    /// <summary>
    /// 商户订单号
    /// </summary>
    [JsonPropertyName("out_trade_no")]
    public string OutTradeNo { get; set; }

    /// <summary>
    /// 是否需要重试
    /// </summary>
    [JsonPropertyName("retry_flag")]
    public string RetryFlag { get; set; }

    /// <summary>
    /// 支付宝交易号，和商户订单号不能同时为空
    /// </summary>
    [JsonPropertyName("trade_no")]
    public string? TradeNo { get; set; }

    /// <summary>
    /// 本次撤销触发的交易动作,接口调用成功且交易存在时返回。可能的返回值：close：交易未支付，触发关闭交易动作，无退款； refund：交易已支付，触发交易退款动作； 未返回：未查询到交易，或接口调用失败；
    /// </summary>
    [JsonPropertyName("action")]
    public string? Action { get; set; }
}
