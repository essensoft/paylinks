using Essensoft.Paylinks.Alipay.Core;
using Essensoft.Paylinks.Alipay.Payments.Response;

namespace Essensoft.Paylinks.Alipay.Payments.Request;

/// <summary>
/// 统一收单交易退款查询
/// </summary>
/// <para>
/// https://opendocs.alipay.com/open-v3/b9ef37bd_alipay.trade.fastpay.refund.query
/// 统一收单交易退款查询
/// 更新时间：2024-05-08 10:30:27
/// </para>
public class AlipayTradeFastPayRefundQueryRequest : IAlipayRequest<AlipayTradeFastPayRefundQueryResponse>
{
    #region IAlipayRequest Members

    public AlipayRequestMethod GetRequestMethod() => AlipayRequestMethod.Post;

    public string GetRequestUrl() => "/v3/alipay/trade/fastpay/refund/query";

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
