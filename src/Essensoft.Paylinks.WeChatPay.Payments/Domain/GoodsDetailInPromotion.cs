using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

/// <summary>
/// 单品列表
/// </summary>
public class GoodsDetailInPromotion
{
    /// <summary>
    /// 商品编码。
    /// </summary>
    [JsonPropertyName("goods_id")]
    public int GoodsId { get; set; }

    /// <summary>
    /// 商品数量。
    /// </summary>
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    /// <summary>
    /// 商品单价
    /// </summary>
    [JsonPropertyName("unit_price")]
    public int UnitPrice { get; set; }

    /// <summary>
    /// 商品优惠金额。
    /// </summary>
    [JsonPropertyName("discount_amount")]
    public int DiscountAmount { get; set; }

    /// <summary>
    /// 商品备注。
    /// </summary>
    [JsonPropertyName("goods_remark")]
    public string? GoodsRemark { get; set; }
}
