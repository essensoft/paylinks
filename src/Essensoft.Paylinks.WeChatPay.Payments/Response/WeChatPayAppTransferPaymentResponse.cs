using System.Text.Json.Serialization;
using Essensoft.Paylinks.WeChatPay.Core;

namespace Essensoft.Paylinks.WeChatPay.Payments.Response;

public class WeChatPayAppTransferPaymentResponse : WeChatPaySdkResponse
{
    /// <summary>
    /// 填写下单时传入的【公众账号ID】appid。
    /// </summary>
    [JsonPropertyName("appId")]
    public string AppId { get; set; }

    /// <summary>
    /// 填写下单时传入的【商户号】mchid。
    /// </summary>
    [JsonPropertyName("partnerId")]
    public string PartnerId { get; set; }

    /// <summary>
    /// 预支付交易会话标识。APP下单接口返回的prepay_id，该值有效期为2小时，超过有效期需要重新请求APP下单接口以获取新的prepay_id。
    /// </summary>
    [JsonPropertyName("prepayId")]
    public string PrepayId { get; set; }

    /// <summary>
    /// 填写固定值Sign=WXPay
    /// </summary>
    [JsonPropertyName("packageValue")]
    public string PackageValue { get; set; }

    /// <summary>
    /// 随机字符串，不长于32位。该值建议使用随机数算法生成。
    /// </summary>
    [JsonPropertyName("nonceStr")]
    public string NonceStr { get; set; }

    /// <summary>
    /// Unix时间戳，是从1970年1月1日（UTC/GMT的午夜）开始所经过的秒数。
    /// 注意：常见时间戳为秒级或毫秒级，该处必需传秒级时间戳。
    /// </summary>
    [JsonPropertyName("timeStamp")]
    public string TimeStamp { get; set; }

    /// <summary>
    /// 签名，使用字段appId、timeStamp、nonceStr、prepayId以及商户API证书私钥生成的RSA签名值，详细参考APP调起支付签名。
    /// </summary>
    [JsonPropertyName("sign")]
    public string Sign { get; set; }
}
