using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.Alipay.Payments.Domain;

public class RefundGoodsDetail
{
    /// <summary>
    /// 商品编号。 对应支付时传入的goods_id
    /// </summary>
    [JsonPropertyName("goods_id")]
    public string GoodsId { get; set; }

    /// <summary>
    /// 商家侧小程序商品ID，对应支付时传入的out_item_id
    /// </summary>
    [JsonPropertyName("out_item_id")]
    public string? OutItemId { get; set; }

    /// <summary>
    /// 商家侧小程序商品sku ID，对应支付时传入的out_sku_id
    /// </summary>
    [JsonPropertyName("out_sku_id")]
    public string? OutSkuId { get; set; }

    /// <summary>
    /// 该商品的退款总金额，单位为元
    /// </summary>
    [JsonPropertyName("refund_amount")]
    public string RefundAmount { get; set; }
}
