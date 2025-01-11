using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Response;

namespace Essensoft.Paylinks.WeChatPay.Payments.Request;

/// <summary>
/// 下载账单
/// </summary>
/// <para>
/// 下载账单
/// https://pay.weixin.qq.com/doc/v3/merchant/4012791868
/// https://pay.weixin.qq.com/doc/v3/merchant/4013070401
/// https://pay.weixin.qq.com/doc/v3/merchant/4012810615
/// https://pay.weixin.qq.com/doc/v3/merchant/4012791889
/// https://pay.weixin.qq.com/doc/v3/merchant/4012791909
/// https://pay.weixin.qq.com/doc/v3/merchant/4012085923
/// https://pay.weixin.qq.com/doc/v3/merchant/4013071238
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
