using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

/// <summary>
/// 优惠功能
/// </summary>
public class Detail
{
    /// <summary>
    /// 订单原价】
    /// 1、商户侧一张小票订单可能被分多次支付，订单原价用于记录整张小票的交易金额。
    /// 2、当订单原价与支付金额不相等，则不享受优惠。
    /// 3、该字段主要用于防止同一张小票分多次支付，以享受多次优惠的情况，正常支付订单不必上传此参数。
    /// </summary>
    [JsonPropertyName("cost_price")]
    public int CostPrice { get; set; }

    /// <summary>
    /// 商品小票ID
    /// </summary>
    [JsonPropertyName("invoice_id")]
    public string? InvoiceId { get; set; }

    /// <summary>
    /// 单品列表
    /// 单品列表信息
    /// 条目个数限制：【1，6000】
    /// </summary>
    [JsonPropertyName("goods_detail")]
    public List<GoodsDetail> GoodsDetail { get; set; }
}
