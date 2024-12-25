using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

public class ReqSubOrderCompatible
{
    /// <summary>
    /// 子单商户号
    /// </summary>
    [JsonPropertyName("mchid")]
    public string MchId { get; set; }

    /// <summary>
    /// 附加数据
    /// </summary>
    [JsonPropertyName("attach")]
    public string Attach { get; set; }

    /// <summary>
    /// 订单金额
    /// </summary>
    [JsonPropertyName("amount")]
    public ReqAmountInfo Amount { get; set; }

    /// <summary>
    /// 子单商户订单号
    /// </summary>
    [JsonPropertyName("out_trade_no")]
    public string OutTradeNo { get; set; }

    /// <summary>
    /// 商品详情
    /// </summary>
    [JsonPropertyName("detail")]
    public string? Detail { get; set; }

    /// <summary>
    /// 商品描述
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// 结算信息
    /// </summary>
    [JsonPropertyName("settle_info")]
    public CombineSettleInfo? SettleInfo { get; set; }

    /// <summary>
    /// 订单优惠标记
    /// </summary>
    [JsonPropertyName("goods_tag")]
    public string? GoodsTag { get; set; }
}
