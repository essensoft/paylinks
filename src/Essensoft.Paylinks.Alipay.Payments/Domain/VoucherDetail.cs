using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.Alipay.Payments.Domain;

public class VoucherDetail
{
    /// <summary>
    /// 优惠券面额，它应该会等于商家出资加上其他出资方出资
    /// </summary>
    [JsonPropertyName("amount")]
    public string Amount { get; set; }

    /// <summary>
    /// 券id
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// 优惠券备注信息
    /// </summary>
    [JsonPropertyName("memo")]
    public string Memo { get; set; }

    /// <summary>
    /// 商家出资（特指发起交易的商家出资金额）
    /// </summary>
    [JsonPropertyName("merchant_contribute")]
    public string MerchantContribute { get; set; }

    /// <summary>
    /// 券名称
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// 其他出资方出资金额，可能是支付宝，可能是品牌商，或者其他方，也可能是他们的一起出资
    /// </summary>
    [JsonPropertyName("other_contribute")]
    public string OtherContribute { get; set; }

    /// <summary>
    /// 优惠券的其他出资方明细
    /// </summary>
    [JsonPropertyName("other_contribute_detail")]
    public List<ContributeDetail> OtherContributeDetail { get; set; }

    /// <summary>
    /// 如果使用的这张券是用户购买的，则该字段代表用户在购买这张券时平台优惠的金额
    /// </summary>
    [JsonPropertyName("purchase_ant_contribute")]
    public string PurchaseAntContribute { get; set; }

    /// <summary>
    /// 如果使用的这张券是用户购买的，则该字段代表用户在购买这张券时用户实际付款的金额
    /// </summary>
    [JsonPropertyName("purchase_buyer_contribute")]
    public string PurchaseBuyerContribute { get; set; }

    /// <summary>
    /// 如果使用的这张券是用户购买的，则该字段代表用户在购买这张券时商户优惠的金额
    /// </summary>
    [JsonPropertyName("purchase_merchant_contribute")]
    public string PurchaseMerchantContribute { get; set; }

    /// <summary>
    /// 券模板id
    /// </summary>
    [JsonPropertyName("template_id")]
    public string TemplateId { get; set; }

    /// <summary>
    /// 券类型
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }
}
