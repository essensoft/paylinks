using System.Text.Json.Serialization;
using Essensoft.Paylinks.Alipay.Payments.Domain;

namespace Essensoft.Paylinks.Alipay.Payments.Model;

public class AlipayTradePreCreateBodyModel
{
    /// <summary>
    /// 商户订单号。由商家自定义，64个字符以内，仅支持字母、数字、下划线且需保证在商户端不重复。
    /// </summary>
    [JsonPropertyName("out_trade_no")]
    public string OutTradeNo { get; set; }

    /// <summary>
    /// 订单总金额，单位为元，精确到小数点后两位，取值范围为 [0.01,100000000]，金额不能为 0。如果同时传入了【可打折金额】，【不可打折金额】，【订单总金额】三者，则必须满足如下条件：【订单总金额】=【可打折金额】+【不可打折金额】
    /// </summary>
    [JsonPropertyName("total_amount")]
    public string TotalAmount { get; set; }

    /// <summary>
    /// 订单标题。注意：不可使用特殊字符，如 /，=，& 等。
    /// </summary>
    [JsonPropertyName("subject")]
    public string Subject { get; set; }

    /// <summary>
    /// 支付宝服务器主动通知商户服务器里指定的页面http/https路径。在body参数中传递
    /// </summary>
    [JsonPropertyName("notify_url")]
    public string? NotifyUrl { get; set; }

    /// <summary>
    /// 销售产品码。如果签约的是当面付快捷版，则传 OFFLINE_PAYMENT；其它支付宝当面付产品传 FACE_TO_FACE_PAYMENT；不传则默认使用 FACE_TO_FACE_PAYMENT。
    /// </summary>
    [JsonPropertyName("product_code")]
    public string? ProductCode { get; set; }

    /// <summary>
    /// 卖家支付宝用户 ID。 如果该值为空，则默认为商户签约账号对应的支付宝用户 ID。不允许收款账号与付款方账号相同
    /// </summary>
    [JsonPropertyName("seller_id")]
    public string? SellerId { get; set; }

    /// <summary>
    /// 订单附加信息。如果请求时传递了该参数，将在异步通知、对账单中原样返回，同时会在商户和用户的pc账单详情中作为交易描述展示
    /// </summary>
    [JsonPropertyName("body")]
    public string? Body { get; set; }

    /// <summary>
    /// 订单包含的商品列表信息，为 JSON 格式，其它说明详见商品明细说明
    /// </summary>
    [JsonPropertyName("goods_detail")]
    public List<GoodsDetail>? GoodsDetail { get; set; }

    /// <summary>
    /// 业务扩展参数
    /// </summary>
    [JsonPropertyName("extend_params")]
    public ExtendParams? ExtendParams { get; set; }

    /// <summary>
    /// 商户传入业务信息，具体值要和支付宝约定，应用于安全，营销等参数直传场景，格式为json格式
    /// </summary>
    [JsonPropertyName("business_params")]
    public BusinessParams? BusinessParams { get; set; }

    /// <summary>
    /// 可打折金额。参与优惠计算的金额，单位为元，精确到小数点后两位，取值范围为 [0.01,100000000]。如果该值未传入，但传入了【订单总金额】和【不可打折金额】，则该值默认为【订单总金额】-【不可打折金额】
    /// </summary>
    [JsonPropertyName("discountable_amount")]
    public string? DiscountableAmount { get; set; }

    /// <summary>
    /// 商户门店编号。指商户创建门店时输入的门店编号。
    /// </summary>
    [JsonPropertyName("store_id")]
    public string? StoreId { get; set; }

    /// <summary>
    /// 商户操作员编号。
    /// </summary>
    [JsonPropertyName("operator_id")]
    public string? OperatorId { get; set; }

    /// <summary>
    /// 商户机具终端编号。
    /// </summary>
    [JsonPropertyName("terminal_id")]
    public string? TerminalId { get; set; }

    /// <summary>
    /// 商户原始订单号，最大长度限制 32 位
    /// </summary>
    [JsonPropertyName("merchant_order_no")]
    public string? MerchantOrderNo { get; set; }
}
