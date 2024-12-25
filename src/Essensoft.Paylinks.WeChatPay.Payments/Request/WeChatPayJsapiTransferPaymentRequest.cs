using Essensoft.Paylinks.Security;
using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Response;

namespace Essensoft.Paylinks.WeChatPay.Payments.Request;

/// <summary>
/// JSAPI调起支付 / 小程序调起支付
/// </summary>
/// <para>
/// https://pay.weixin.qq.com/docs/merchant/apis/jsapi-payment/jsapi-transfer-payment.html
/// JSAPI调起支付
/// 更新时间：2023.08.16
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/mini-program-payment/mini-transfer-payment.html
/// 小程序调起支付
/// 更新时间：2023.08.16
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/combine-payment/orders/jsapi-transfer-payment.html
/// JSAPI调起支付
/// 更新时间：2023.12.28
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/combine-payment/orders/mini-transfer-payment.html
/// 小程序调起支付
/// 更新时间：2023.12.12
/// </para>
public class WeChatPayJsapiTransferPaymentRequest : IWeChatPaySdkRequest<WeChatPayJsapiTransferPaymentResponse>
{
    /// <summary>
    /// 商户申请的公众号对应的AppID，由微信支付生成，可在公众号后台查看
    /// </summary>
    public string AppId { get; set; }

    /// <summary>
    /// 时间戳，标准北京时间，时区为东八区，自1970年1月1日 0点0分0秒以来的秒数。注意：部分系统取到的值为毫秒级，需要转换成秒(10位数字)。
    /// </summary>
    public string TimeStamp { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();

    /// <summary>
    /// 随机字符串，不长于32位。
    /// </summary>
    public string NonceStr { get; set; } = Guid.NewGuid().ToString("N");

    /// <summary>
    /// JSAPI下单接口返回的prepay_id参数值，提交格式如：prepay_id=***
    /// </summary>
    public string Package { get; set; }

    /// <summary>
    /// 签名类型，默认为RSA，仅支持RSA。
    /// </summary>
    public string SignType { get; set; } = "RSA";

    private string BuildSignatureSourceData()
    {
        return $"{AppId}\n{TimeStamp}\n{NonceStr}\n{Package}\n";
    }

    public WeChatPayJsapiTransferPaymentResponse SignatureHandler(string privateKey)
    {
        var signatureSourceData = BuildSignatureSourceData();
        return new WeChatPayJsapiTransferPaymentResponse
        {
            AppId = AppId,
            TimeStamp = TimeStamp,
            NonceStr = NonceStr,
            Package = Package,
            SignType = SignType,
            PaySign = SHA256WithRSA.Sign(signatureSourceData, privateKey)
        };
    }
}
