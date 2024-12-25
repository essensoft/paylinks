using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

/// <summary>
/// 优惠信息
/// </summary>
public class PromotionDetail
{
    /// <summary>
    /// 券ID
    /// </summary>
    [JsonPropertyName("coupon_id")]
    public string CouponId { get; set; }

    /// <summary>
    /// 优惠名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// 优惠范围
    /// </summary>
    [JsonPropertyName("scope")]
    public string? Scope { get; set; }

    /// <summary>
    /// 优惠类型
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// 优惠券面额。
    /// </summary>
    [JsonPropertyName("amount")]
    public int Amount { get; set; }

    /// <summary>
    /// 活动ID
    /// </summary>
    [JsonPropertyName("stock_id")]
    public string? StockId { get; set; }

    /// <summary>
    /// 微信出资
    /// </summary>
    [JsonPropertyName("WeChatPay_contribute")]
    public int? WeChatPayContribute { get; set; }

    /// <summary>
    /// 商户出资
    /// </summary>
    [JsonPropertyName("merchant_contribute")]
    public int? MerchantContribute { get; set; }

    /// <summary>
    /// 其他出资
    /// </summary>
    [JsonPropertyName("other_contribute")]
    public int? OtherContribute { get; set; }

    /// <summary>
    /// 优惠货币类型
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <summary>
    /// 单品列表。
    /// </summary>
    [JsonPropertyName("goods_detail")]
    public List<GoodsDetailInPromotion>? GoodsDetail { get; set; }
}
