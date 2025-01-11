using System.Text.Json.Serialization;
using Essensoft.Paylinks.Security;
using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Response;

namespace Essensoft.Paylinks.WeChatPay.Payments.Request;

/// <summary>
/// APP调起支付
/// </summary>
/// <para>
/// APP调起支付 - 更新时间：2024.11.25
/// https://pay.weixin.qq.com/doc/v3/merchant/4013070351
/// APP调起支付 - 更新时间：2025.01.08
/// https://pay.weixin.qq.com/doc/v3/merchant/4012266043
/// </para>
public class WeChatPayAppTransferPaymentRequest : IWeChatPaySdkRequest<WeChatPayAppTransferPaymentResponse>
{
    /// <summary>
    /// 微信开放平台审核通过的移动应用AppID。
    /// </summary>
    [JsonPropertyName("appId")]
    public string AppId { get; set; }

    /// <summary>
    /// 请填写商户号mchid对应的值。
    /// </summary>
    [JsonPropertyName("partnerId")]
    public string PartnerId { get; set; }

    /// <summary>
    /// 微信返回的支付交易会话ID，该值有效期为2小时。
    /// </summary>
    [JsonPropertyName("prepayId")]
    public string PrepayId { get; set; }

    /// <summary>
    /// 暂填写固定值Sign=WXPay
    /// </summary>
    [JsonPropertyName("packageValue")]
    public string PackageValue { get; set; } = "Sign=WXPay";

    /// <summary>
    /// 随机字符串，不长于32位。推荐随机数生成算法。
    /// </summary>
    [JsonPropertyName("nonceStr")]
    public string NonceStr { get; set; } = Guid.NewGuid().ToString("N");

    /// <summary>
    /// 时间戳，标准北京时间，时区为东八区，自1970年1月1日 0点0分0秒以来的秒数。注意：部分系统取到的值为毫秒级，需要转换成秒(10位数字)。
    /// </summary>
    [JsonPropertyName("timeStamp")]
    public string TimeStamp { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();

    private string BuildSignatureSourceData()
    {
        return $"{AppId}\n{TimeStamp}\n{NonceStr}\n{PrepayId}\n";
    }

    public WeChatPayAppTransferPaymentResponse SignatureHandler(string privateKey)
    {
        var signatureSourceData = BuildSignatureSourceData();
        return new WeChatPayAppTransferPaymentResponse
        {
            AppId = AppId,
            PartnerId = PartnerId,
            PrepayId = PrepayId,
            PackageValue = PackageValue,
            NonceStr = NonceStr,
            TimeStamp = TimeStamp,
            Sign = SHA256WithRSA.Sign(signatureSourceData, privateKey)
        };
    }
}
