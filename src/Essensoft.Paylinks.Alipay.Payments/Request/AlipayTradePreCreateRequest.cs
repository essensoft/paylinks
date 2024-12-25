using Essensoft.Paylinks.Alipay.Core;
using Essensoft.Paylinks.Alipay.Payments.Response;

namespace Essensoft.Paylinks.Alipay.Payments.Request;

/// <summary>
/// 统一收单线下交易预创建
/// </summary>
/// <para>
/// https://opendocs.alipay.com/open-v3/fa0c2141_alipay.trade.precreate
/// 统一收单线下交易预创建
/// 更新时间：2024-06-05 13:47:08
/// </para>
public class AlipayTradePreCreateRequest : IAlipayRequest<AlipayTradePreCreateResponse>
{
    #region IAlipayRequest Members

    public AlipayRequestMethod GetRequestMethod() => AlipayRequestMethod.Post;

    public string GetRequestUrl() => "/v3/alipay/trade/precreate";

    private bool _needVerify = true;

    public void SetNeedVerify(bool value) => _needVerify = value;

    public bool GetNeedVerify() => _needVerify;

    private object? _queryModel;

    public void SetQueryModel(object queryModel) => _queryModel = queryModel;

    public object? GetQueryModel() => _queryModel;

    private object? _bodyModel;

    public void SetBodyModel(object bodyModel) => _bodyModel = bodyModel;

    public object? GetBodyModel() => _bodyModel;

    private bool _needEncrypt;

    public bool GetNeedEncrypt() => _needEncrypt;

    public void SetNeedEncrypt(bool value) => _needEncrypt = value;

    #endregion
}
