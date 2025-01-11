using Essensoft.Paylinks.WeChatPay.Certificates.Response;
using Essensoft.Paylinks.WeChatPay.Core;

namespace Essensoft.Paylinks.WeChatPay.Certificates.Request;

[Obsolete("Use WeChatPayCertificatesRequest")]
public class WeChatPayGetCertificatesRequest : WeChatPayCertificatesRequest;

/// <summary>
/// 下载平台证书
/// </summary>
/// <para>
/// 下载平台证书 - 更新时间：2024.09.13
/// https://pay.weixin.qq.com/doc/v3/merchant/4012551764
/// </para>
public class WeChatPayCertificatesRequest : IWeChatPayRequest<WeChatPayCertificatesResponse>
{
    #region IWeChatPayRequest Members

    public WeChatPayRequestMethod GetRequestMethod() => WeChatPayRequestMethod.Get;

    public string GetRequestUrl() => "/v3/certificates";

    private bool _needVerify = true;

    public bool GetNeedVerify() => _needVerify;

    public void SetNeedVerify(bool value) => _needVerify = value;

    private object? _queryModel;

    public void SetQueryModel(object queryModel) => _queryModel = queryModel;

    public object? GetQueryModel() => _queryModel;

    private object? _bodyModel;

    public void SetBodyModel(object bodyModel) => _bodyModel = bodyModel;

    public object? GetBodyModel() => _bodyModel;

    #endregion
}
