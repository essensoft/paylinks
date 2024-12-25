using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

public class RefundGoodsDetail
{
    /// <summary>
    /// 商户侧商品编码
    /// </summary>
    [JsonPropertyName("merchant_goods_id")]
    public string MerchantGoodsId { get; set; }

    /// <summary>
    /// 微信支付商品编码
    /// </summary>
    [JsonPropertyName("WeChatPay_goods_id")]
    public string? WechatPayGoodsId { get; set; }

    /// <summary>
    /// 商品名称
    /// </summary>
    [JsonPropertyName("goods_name")]
    public string? GoodsName { get; set; }

    /// <summary>
    /// 商品单价
    /// </summary>
    [JsonPropertyName("unit_price")]
    public int UnitPrice { get; set; }

    /// <summary>
    /// 商品退款金额
    /// </summary>
    [JsonPropertyName("refund_amount")]
    public int RefundAmount { get; set; }

    /// <summary>
    /// 商品退货数量
    /// </summary>
    [JsonPropertyName("refund_quantity")]
    public int RefundQuantity { get; set; }
}
