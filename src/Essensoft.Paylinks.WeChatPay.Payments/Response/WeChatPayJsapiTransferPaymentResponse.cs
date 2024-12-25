using System.Text.Json.Serialization;
using Essensoft.Paylinks.WeChatPay.Core;

namespace Essensoft.Paylinks.WeChatPay.Payments.Response;

public class WeChatPayJsapiTransferPaymentResponse : WeChatPaySdkResponse
{
    /// <summary>
    /// 商户申请的公众号对应的AppID，由微信支付生成，可在公众号后台查看
    /// </summary>
    [JsonPropertyName("appId")]
    public string AppId { get; set; }

    /// <summary>
    /// 时间戳，标准北京时间，时区为东八区，自1970年1月1日 0点0分0秒以来的秒数。注意：部分系统取到的值为毫秒级，需要转换成秒(10位数字)。
    /// </summary>
    [JsonPropertyName("timeStamp")]
    public string TimeStamp { get; set; }

    /// <summary>
    /// 随机字符串，不长于32位。
    /// </summary>
    [JsonPropertyName("nonceStr")]
    public string NonceStr { get; set; }

    /// <summary>
    /// JSAPI下单接口返回的prepay_id参数值，提交格式如：prepay_id=***
    /// </summary>
    [JsonPropertyName("package")]
    public string Package { get; set; }

    /// <summary>
    /// 签名类型，默认为RSA，仅支持RSA。
    /// </summary>
    [JsonPropertyName("signType")]
    public string SignType { get; set; }

    /// <summary>
    /// 签名，使用字段AppId、TimeStamp、NonceStr、Package计算得出的签名值
    /// </summary>
    [JsonPropertyName("paySign")]
    public string PaySign { get; set; }
}
