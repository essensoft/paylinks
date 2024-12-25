using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Response;

namespace Essensoft.Paylinks.WeChatPay.Payments.Request;

/// <summary>
/// 下载账单
/// </summary>
/// <para>
/// https://pay.weixin.qq.com/docs/merchant/apis/jsapi-payment/download-bill.html
/// 下载账单
/// 更新时间：2024.01.17
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/in-app-payment/download-bill.html
/// 下载账单
/// 更新时间：2024.01.17
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/h5-payment/download-bill.html
/// 下载账单
/// 更新时间：2024.01.17
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/native-payment/download-bill.html
/// 下载账单
/// 更新时间：2024.01.17
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/mini-program-payment/download-bill.html
/// 下载账单
/// 更新时间：2024.01.17
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/combine-payment/bill-download/download-bill.html
/// 下载账单
/// 更新时间：2024.01.17
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/bill-download/download-bill.html
/// 下载账单
/// 更新时间：2024.01.17
/// </para>
public class WeChatPayDownloadBillRequest : IWeChatPayRequest<WeChatPayDownloadBillResponse>
{
    #region IWeChatPayRequest Members

    public WeChatPayRequestMethod GetRequestMethod() => WeChatPayRequestMethod.Get;

    public string GetRequestUrl() => DownloadUrl;

    public bool GetNeedVerify() => false;

    public void SetNeedVerify(bool value) => throw new NotImplementedException();

    private object? _queryModel;

    public void SetQueryModel(object queryModel) => _queryModel = queryModel;

    public object? GetQueryModel() => _queryModel;

    private object? _bodyModel;

    public void SetBodyModel(object bodyModel) => _bodyModel = bodyModel;

    public object? GetBodyModel() => _bodyModel;

    #endregion

    private string _downloadUrl;

    public string DownloadUrl
    {
        get => _downloadUrl;
        set => _downloadUrl = value.Contains(Uri.SchemeDelimiter) ? new Uri(value).PathAndQuery : value;
    }
}
