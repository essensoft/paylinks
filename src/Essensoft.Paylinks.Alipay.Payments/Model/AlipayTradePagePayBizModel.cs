using System.Text.Json.Serialization;
using Essensoft.Paylinks.Alipay.Payments.Domain;

namespace Essensoft.Paylinks.Alipay.Payments.Model;

public class AlipayTradePagePayBizModel
{
    /// <summary>
    /// 商户网站唯一订单号。
    /// 由商家自定义，64个字符以内，仅支持字母、数字、下划线且需保证在商户端不重复。
    /// </summary>
    [JsonPropertyName("out_trade_no")]
    public string OutTradeNo { get; set; }

    /// <summary>
    /// 订单总金额，单位为元，精确到小数点后两位，取值范围[0.01,100000000]，金额不能为0
    /// </summary>
    [JsonPropertyName("total_amount")]
    public string TotalAmount { get; set; }

    /// <summary>
    /// 订单标题。
    /// 注意：不可使用特殊字符，如 /，=，& 等。
    /// </summary>
    [JsonPropertyName("subject")]
    public string Subject { get; set; }

    /// <summary>
    /// 销售产品码，与支付宝签约的产品码名称。注：目前电脑支付场景下仅支持FAST_INSTANT_TRADE_PAY
    /// </summary>
    [JsonPropertyName("product_code")]
    public string ProductCode { get; set; }

    /// <summary>
    /// 支付宝服务器主动通知商户服务器里指定的页面http/https路径。在body参数中传递
    /// </summary>
    [JsonPropertyName("notify_url")]
    public string? NotifyUrl { get; set; }

    /// <summary>
    /// PC扫码支付的方式。
    /// 支持前置模式和跳转模式。
    /// 前置模式是将二维码前置到商户的订单确认页的模式。需要商户在自己的页面中以 iframe 方式请求支付宝页面。具体支持的枚举值有以下几种：
    /// 0：订单码-简约前置模式，对应 iframe 宽度不能小于600px，高度不能小于300px；
    /// 1：订单码-前置模式，对应iframe 宽度不能小于 300px，高度不能小于600px；
    /// 3：订单码-迷你前置模式，对应 iframe 宽度不能小于 75px，高度不能小于75px；
    /// 4：订单码-可定义宽度的嵌入式二维码，商户可根据需要设定二维码的大小。
    /// 跳转模式下，用户的扫码界面是由支付宝生成的，不在商户的域名下。支持传入的枚举值有：
    /// 2：订单码-跳转模式
    /// </summary>
    [JsonPropertyName("qr_pay_mode")]
    public string? QrPayMode { get; set; }

    /// <summary>
    /// 商户自定义二维码宽度。
    /// 注：qr_pay_mode=4时该参数有效
    /// </summary>
    [JsonPropertyName("qrcode_width")]
    public string? QrcodeWidth { get; set; }

    /// <summary>
    /// 订单包含的商品列表信息，json格式，其它说明详见商品明细说明
    /// </summary>
    [JsonPropertyName("goods_detail")]
    public List<GoodsDetail>? GoodsDetail { get; set; }

    /// <summary>
    /// 订单绝对超时时间。
    /// 格式为yyyy-MM-dd HH:mm:ss。超时时间范围：1m~15d。
    /// 注：time_expire和timeout_express两者只需传入一个或者都不传，两者均传入时，优先使用time_expire。
    /// </summary>
    [JsonPropertyName("time_expire")]
    public DateTimeOffset? TimeExpire { get; set; }

    /// <summary>
    /// 二级商户信息。
    /// 直付通模式和机构间连模式下必传，其它场景下不需要传入。
    /// </summary>
    [JsonPropertyName("sub_merchant")]
    public string? SubMerchant { get; set; }

    /// <summary>
    /// 业务扩展参数
    /// </summary>
    [JsonPropertyName("extend_params")]
    public ExtendParams? ExtendParams { get; set; }

    /// <summary>
    /// 商户传入业务信息，具体值要和支付宝约定，应用于安全，营销等参数直传场景，格式为json格式
    /// </summary>
    [JsonPropertyName("business_params")]
    public string? BusinessParams { get; set; }

    /// <summary>
    /// 优惠参数。为 JSON 格式。注：仅与支付宝协商后可用
    /// </summary>
    [JsonPropertyName("promo_params")]
    public string? PromoParams { get; set; }

    /// <summary>
    /// 请求后页面的集成方式。
    /// 枚举值：
    /// ALIAPP：支付宝钱包内
    /// PCWEB：PC端访问
    /// 默认值为PCWEB。
    /// </summary>
    [JsonPropertyName("integration_type")]
    public string? IntegrationType { get; set; }

    /// <summary>
    /// 请求来源地址。如果使用ALIAPP的集成方式，用户中途取消支付会返回该地址。
    /// </summary>
    [JsonPropertyName("request_from_url")]
    public string? RequestFromUrl { get; set; }

    /// <summary>
    /// 商户门店编号。
    /// 指商户创建门店时输入的门店编号。
    /// </summary>
    [JsonPropertyName("store_id")]
    public string? StoreId { get; set; }

    /// <summary>
    /// 商户原始订单号，最大长度限制32位
    /// </summary>
    [JsonPropertyName("merchant_order_no")]
    public string? MerchantOrderNo { get; set; }

    /// <summary>
    /// 外部指定买家
    /// </summary>
    [JsonPropertyName("ext_user_info")]
    public ExtUserInfo? ExtUserInfo { get; set; }

    /// <summary>
    /// 开票信息
    /// </summary>
    [JsonPropertyName("invoice_info")]
    public InvoiceInfo? InvoiceInfo { get; set; }
}
