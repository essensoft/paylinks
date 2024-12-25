using System.Text.Json.Serialization;
using Essensoft.Paylinks.WeChatPay.Core;

namespace Essensoft.Paylinks.WeChatPay.Payments.Response;

public class WeChatPayAppTransferPaymentResponse : WeChatPaySdkResponse
{
    /// <summary>
    /// 微信开放平台审核通过的移动应用AppID。
    /// </summary>
    [JsonPropertyName("appid")]
    public string AppId { get; set; }

    /// <summary>
    /// 请填写商户号mchid对应的值。
    /// </summary>
    [JsonPropertyName("partnerid")]
    public string PartnerId { get; set; }

    /// <summary>
    /// 微信返回的支付交易会话ID，该值有效期为2小时。
    /// </summary>
    [JsonPropertyName("prepayid")]
    public string PrepayId { get; set; }

    /// <summary>
    /// 暂填写固定值Sign=WXPay
    /// </summary>
    [JsonPropertyName("package")]
    public string Package { get; set; }

    /// <summary>
    /// 随机字符串，不长于32位。推荐随机数生成算法。
    /// </summary>
    [JsonPropertyName("noncestr")]
    public string NonceStr { get; set; }

    /// <summary>
    /// 时间戳，标准北京时间，时区为东八区，自1970年1月1日 0点0分0秒以来的秒数。注意：部分系统取到的值为毫秒级，需要转换成秒(10位数字)。
    /// </summary>
    [JsonPropertyName("timestamp")]
    public string TimeStamp { get; set; }

    /// <summary>
    /// 签名，使用字段AppId、TimeStamp、NonceStr、PrepayId计算得出的签名值 注意：取值RSA格式
    /// </summary>
    [JsonPropertyName("sign")]
    public string Sign { get; set; }
}
