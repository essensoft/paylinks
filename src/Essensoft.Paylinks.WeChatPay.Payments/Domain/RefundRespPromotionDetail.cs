using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

public class RefundRespPromotionDetail
{
    /// <summary>
    /// 券ID
    /// </summary>
    [JsonPropertyName("promotion_id")]
    public string PromotionId { get; set; }

    /// <summary>
    /// 优惠范围
    /// </summary>
    [JsonPropertyName("scope")]
    public string Scope { get; set; }

    /// <summary>
    /// 优惠类型
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }

    /// <summary>
    /// 优惠券面额
    /// </summary>
    [JsonPropertyName("amount")]
    public int Amount { get; set; }

    /// <summary>
    /// 优惠退款金额
    /// </summary>
    [JsonPropertyName("refund_amount")]
    public int RefundAmount { get; set; }

    /// <summary>
    /// 商品列表
    /// </summary>
    [JsonPropertyName("goods_detail")]
    public List<RefundGoodsDetail>? GoodsDetail { get; set; }
}
