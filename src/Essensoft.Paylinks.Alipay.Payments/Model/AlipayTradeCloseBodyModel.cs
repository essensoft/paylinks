using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.Alipay.Payments.Model;

public class AlipayTradeCloseBodyModel
{
    /// <summary>
    /// 该交易在支付宝系统中的交易流水号。最短 16 位，最长 64 位。和out_trade_no不能同时为空，如果同时传了 out_trade_no和 trade_no，则以 trade_no为准。
    /// </summary>
    [JsonPropertyName("trade_no")]
    public string? TradeNo { get; set; }

    /// <summary>
    /// 订单支付时传入的商户订单号,和支付宝交易号不能同时为空。 trade_no,out_trade_no如果同时存在优先取trade_no
    /// </summary>
    [JsonPropertyName("out_trade_no")]
    public string? OutTradeNo { get; set; }

    /// <summary>
    /// 支付宝服务器主动通知商户服务器里指定的页面http/https路径。在body参数中传递
    /// </summary>
    [JsonPropertyName("notify_url")]
    public string? NotifyUrl { get; set; }

    /// <summary>
    /// 商家操作员编号 id，由商家自定义。
    /// </summary>
    [JsonPropertyName("operator_id")]
    public string? OperatorId { get; set; }
}
