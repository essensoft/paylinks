using System.Text.Json.Serialization;
using Essensoft.Paylinks.Alipay.Payments.Domain;

namespace Essensoft.Paylinks.Alipay.Payments.Model;

public class AlipayTradeAppPayBizModel
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
    /// 支付宝服务器主动通知商户服务器里指定的页面http/https路径。在body参数中传递
    /// </summary>
    [JsonPropertyName("notify_url")]
    public string? NotifyUrl { get; set; }

    /// <summary>
    /// 销售产品码，商家和支付宝签约的产品码
    /// </summary>
    [JsonPropertyName("product_code")]
    public string? ProductCode { get; set; }

    /// <summary>
    /// 订单包含的商品列表信息，json格式，其它说明详见商品明细说明
    /// </summary>
    [JsonPropertyName("goods_detail")]
    public List<GoodsDetail>? GoodsDetail { get; set; }

    /// <summary>
    /// 绝对超时时间，格式为yyyy-MM-dd HH:mm:ss
    /// </summary>
    [JsonPropertyName("time_expire")]
    public DateTimeOffset? TimeExpire { get; set; }

    /// <summary>
    /// 业务扩展参数
    /// </summary>
    [JsonPropertyName("extend_params")]
    public ExtendParams? ExtendParams { get; set; }

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

    /// <summary>
    /// 返回参数选项。 商户通过传递该参数来定制同步需要额外返回的信息字段，数组格式。包括但不限于：["hyb_amount","enterprise_pay_info"]
    /// </summary>
    [JsonPropertyName("query_options")]
    public List<string>? QueryOptions { get; set; }
}
