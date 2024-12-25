using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

/// <summary>
/// 优惠功能
/// </summary>
public class OrderDetail
{
    /// <summary>
    /// 订单原价
    /// </summary>
    [JsonPropertyName("cost_price")]
    public int? CostPrice { get; set; }

    /// <summary>
    /// 商品小票ID
    /// </summary>
    [JsonPropertyName("invoice_id")]
    public string? InvoiceId { get; set; }

    /// <summary>
    /// 单品列表
    /// </summary>
    [JsonPropertyName("goods_detail")]
    public List<GoodsDetail> GoodsDetail { get; set; }
}
