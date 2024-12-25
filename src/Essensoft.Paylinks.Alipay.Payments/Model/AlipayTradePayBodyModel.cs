using System.Text.Json.Serialization;
using Essensoft.Paylinks.Alipay.Payments.Domain;

namespace Essensoft.Paylinks.Alipay.Payments.Model;

public class AlipayTradePayBodyModel
{
    /// <summary>
    /// 商户订单号。由商家自定义，64个字符以内，仅支持字母、数字、下划线且需保证在商户端不重复。
    /// </summary>
    [JsonPropertyName("out_trade_no")]
    public string OutTradeNo { get; set; }

    /// <summary>
    /// 订单总金额。 单位为元，精确到小数点后两位，取值范围：[0.01,100000000] 。
    /// </summary>
    [JsonPropertyName("total_amount")]
    public string TotalAmount { get; set; }

    /// <summary>
    /// 订单标题。 注意：不可使用特殊字符，如 /，=，& 等。
    /// </summary>
    [JsonPropertyName("subject")]
    public string Subject { get; set; }

    /// <summary>
    /// 支付授权码。 当面付场景传买家的付款码（25~30开头的长度为16~24位的数字，实际字符串长度以开发者获取的付款码长度为准）或者刷脸标识串（fp开头的35位字符串）； 周期扣款或代扣场景无需传入，协议号通过agreement_params参数传递；  支付宝预授权和新当面资金授权场景无需传入，授权订单号通过 auth_no字段传入。 注：交易的买家与卖家不能相同。
    /// </summary>
    [JsonPropertyName("auth_code")]
    public string AuthCode { get; set; }

    /// <summary>
    /// 支付场景。枚举值：bar_code：当面付条码支付场景； security_code：当面付刷脸支付场景，对应的auth_code为fp开头的刷脸标识串； 周期扣款或代扣场景无需传入，协议号通过agreement_params参数传递；  支付宝预授权和新当面资金授权场景无需传入，授权订单号通过 auth_no字段传入。 默认值为bar_code。
    /// </summary>
    [JsonPropertyName("scene")]
    public string Scene { get; set; }

    /// <summary>
    /// 通知地址。支付宝服务器主动通知商户服务器里指定的页面http/https路径。在body参数中传递
    /// </summary>
    [JsonPropertyName("notify_url")]
    public string? NotifyUrl { get; set; }

    /// <summary>
    /// 产品码。
    /// 商家和支付宝签约的产品码。
    /// 当面付场景下，如果签约的是当面付快捷版，则传 OFFLINE_PAYMENT;
    /// 其它支付宝当面付产品传 FACE_TO_FACE_PAYMENT；
    /// 不传则默认使用FACE_TO_FACE_PAYMENT。
    /// </summary>
    [JsonPropertyName("product_code")]
    public string? ProductCode { get; set; }

    /// <summary>
    /// 卖家支付宝用户ID。
    /// 当需要指定收款账号时，通过该参数传入，如果该值为空，则默认为商户签约账号对应的支付宝用户ID。
    /// 收款账号优先级规则：门店绑定的收款账户>请求传入的seller_id>商户签约账号对应的支付宝用户ID；
    /// 注：直付通和机构间联场景下seller_id无需传入或者保持跟pid一致；如果传入的seller_id与pid不一致，需要联系支付宝小二配置收款关系；
    /// </summary>
    [JsonPropertyName("seller_id")]
    public string? SellerId { get; set; }

    /// <summary>
    /// 订单包含的商品列表信息，json格式。
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
    /// 优惠明细参数，通过此属性补充营销参数。 注：仅与支付宝协商后可用。
    /// </summary>
    [JsonPropertyName("promo_params")]
    public PromoParam? PromoParams { get; set; }

    /// <summary>
    /// 商户门店编号。 指商户创建门店时输入的门店编号。
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
    /// 返回参数选项。
    /// 商户通过传递该参数来定制同步需要额外返回的信息字段，数组格式。如：["fund_bill_list","voucher_detail_list","discount_goods_detail"]
    /// </summary>
    [JsonPropertyName("query_options")]
    public List<string>? QueryOptions { get; set; }
}
