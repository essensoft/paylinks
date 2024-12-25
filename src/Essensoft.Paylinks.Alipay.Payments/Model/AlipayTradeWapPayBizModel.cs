using System.Text.Json.Serialization;
using Essensoft.Paylinks.Alipay.Payments.Domain;

namespace Essensoft.Paylinks.Alipay.Payments.Model;

public class AlipayTradeWapPayBizModel
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
    /// 销售产品码，商家和支付宝签约的产品码。手机网站支付为：QUICK_WAP_WAY
    /// </summary>
    [JsonPropertyName("product_code")]
    public string ProductCode { get; set; }

    /// <summary>
    /// 支付宝服务器主动通知商户服务器里指定的页面http/https路径。在body参数中传递
    /// </summary>
    [JsonPropertyName("notify_url")]
    public string? NotifyUrl { get; set; }

    /// <summary>
    /// 针对用户授权接口，获取用户相关数据时，用于标识用户授权关系
    /// </summary>
    [JsonPropertyName("auth_token")]
    public string? auth_token { get; set; }

    /// <summary>
    /// 用户付款中途退出返回商户网站的地址quit_url。
    /// </summary>
    [JsonPropertyName("quit_url")]
    public string? quit_url { get; set; }

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
    /// 公用回传参数，如果请求时传递了该参数，则返回给商户时会回传该参数。支付宝只会在同步返回（包括跳转回商户网站）和异步通知时将该参数原样返回。本参数必须进行UrlEncode之后才可以发送给支付宝。
    /// </summary>
    [JsonPropertyName("passback_params")]
    public string? PassBackParams { get; set; }

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
}
