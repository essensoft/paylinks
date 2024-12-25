using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

/// <summary>
/// 单品列表
/// </summary>
public class GoodsDetail
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
    /// 商品数量
    /// </summary>
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    /// <summary>
    /// 商品单价
    /// </summary>
    [JsonPropertyName("unit_price")]
    public int UnitPrice { get; set; }
}
