using Essensoft.Paylinks.Alipay.Core;
using Essensoft.Paylinks.Alipay.Payments.Response;

namespace Essensoft.Paylinks.Alipay.Payments.Request;

/// <summary>
/// 统一收单交易撤销
/// </summary>
/// <para>
/// https://opendocs.alipay.com/open-v3/cd7d54d2_alipay.trade.cancel
/// 统一收单交易撤销
/// 更新时间：2024-07-09 17:32:20
/// </para>
public class AlipayTradeCancelRequest : IAlipayRequest<AlipayTradeCancelResponse>
{
    #region IAlipayRequest Members

    public AlipayRequestMethod GetRequestMethod() => AlipayRequestMethod.Post;

    public string GetRequestUrl() => "/v3/alipay/trade/cancel";

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
